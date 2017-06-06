using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDatabaseCSharp
{
    public class readFunctionFileClass
    {
        public string fileName = "";
        public string filePath = "";
        public string[] contentByLine;
        public string fileExtension = "";

        //Create an indexer list to fill with functions later
        public FunctionsIndexer fileFunctions = new FunctionsIndexer();

        //Set languageAttributes object for other language references.
        public LanguageAttributes fileLanguage = new LanguageAttributes();

        //object instantiation and file read-parse.  Fails to produce functions if no language discovered
        public readFunctionFileClass(string newFilePath)
        {
            getFileAttributes(newFilePath);
            extSetFileLanguage();

            if (this.fileLanguage.myLanguage != "")
            {
                getFunctionAttributes();
            }
        }

        public void userSetFileLanguage(string newLanguage)
        {
            this.fileLanguage.setLanguageAttributes(newLanguage);
        }

        public void extSetFileLanguage()
        {
            //set the file language based upon file extension
            for (int i = 0; i < this.fileLanguage.languageMatrix.GetLength(0); i++)
            {
                if (this.fileExtension == this.fileLanguage.languageMatrix[i, 1])
                {
                    this.fileLanguage.setLanguageAttributes(this.fileLanguage.languageMatrix[i, 0]);
                }
            }
        }

        public void getFileAttributes(string newFilePath)
        {
            //set the file name
            this.fileName = Path.GetFileName(newFilePath);

            //set the file path
            this.filePath = newFilePath;

            //set the file extension
            this.fileExtension = Path.GetExtension(newFilePath);

            //set the file contents as array by line
            //"by line" allows for easy line counts and iterations
            this.contentByLine = File.ReadAllLines(newFilePath);
        }

        public void getFunctionAttributes()
        {
            //Get function attributes, create a function object, add to indexer class???
            string[] commentedKeywords = new string[] { "Function Purpose:", "Function Imports:", "Function Tags:" };
            string[] functionAttributes = new string[6] { "", "", "", "", "", "" }; //Function Purpose, function imports, function Tags, function, prototype, language
            string updatedComment = "";
            int startFuncCtr = 0;
            int endFuncCtr = 0;

            // Look at lines.  if line contains keyword, use appropriate find function 
            foreach (var line in this.contentByLine)
            {
                if (line.Contains(this.fileLanguage.myStartFunction) && line.Contains(@"("))
                {
                    switch (this.fileLanguage.myFunctionType)
                    {
                        case "positional":
                            endFuncCtr = findPositionalFunctions(startFuncCtr, line);
                            break;
                        case "bracket":
                            endFuncCtr = findBracketedFunctions(startFuncCtr);
                            break;
                        case "declared":
                            endFuncCtr = findDeclaredFunctions(startFuncCtr);
                            break;
                    }
                    //Setting the function, prototype, and language attributes
                    string[] tempfunction = new string[endFuncCtr - startFuncCtr + 1];
                    Array.Copy(this.contentByLine, startFuncCtr, tempfunction, 0, endFuncCtr - startFuncCtr + 1);
                    functionAttributes[5] = this.fileLanguage.myLanguage;
                    functionAttributes[4] = line;
                    functionAttributes[3] = String.Join(Environment.NewLine, tempfunction);

                    //call createFunctionObject with attributes as arguments
                    createFunctionObject(functionAttributes);

                    //set array values equal to empyt string in preparation for next function
                    for (int i = 0; i < functionAttributes.Length; i++)
                    {
                        functionAttributes[i] = "";
                    }

                }
                //setting the purpose, imports, and tags attributes
                for (int ctr = 0; ctr < commentedKeywords.Length; ctr++)
                {
                    if (line.Contains(commentedKeywords[ctr]))
                    {
                        //Remove comments from string, remove preceding spaces, remove comment symbol; remove colon
                        updatedComment = line.Replace(commentedKeywords[ctr], "");
                        updatedComment = updatedComment.Replace(":", "");
                        updatedComment = updatedComment.Replace(this.fileLanguage.myCommentSymbol, "");
                        updatedComment = updatedComment.Trim();
                        functionAttributes[ctr] = updatedComment;
                    }
                }
                startFuncCtr += 1;
            }
        }

        public void createFunctionObject(params string[] attributes)
        {
            Console.WriteLine(attributes[1]);
            //create function object, add to list
            individualFunction newFunction = new individualFunction(imports: attributes[1], tags: attributes[2], function: attributes[3], prototype: attributes[4], language: attributes[5], purpose: attributes[0]);
            fileFunctions.addFunction(newFunction);
        }

        //ERROR, pythontest is returning an inappropriate figure??
        public int findPositionalFunctions(int startpos, string startline)
        {
            Console.WriteLine("here, in python search");
            //when function content position  is the start position function has ended
            //Note: requires forward looking because there may be empty lines inside of functions
            int endOfFile = this.contentByLine.Length - 1;
            int endpos = startpos;
            int startCount = startline.TakeWhile(Char.IsWhiteSpace).Count(); ;
            int matchCount = 0;

            for (int ctr = startpos + 1; endpos == startpos; ctr++)
            {
                matchCount = this.contentByLine[ctr].TakeWhile(Char.IsWhiteSpace).Count();
                if (matchCount == startCount)
                {
                    //loop through rest of file looking for text with more leading whitespace than starting whitespace
                    //Do a character count to determine if the line contains all whitespace
                    //Do a check to see if the end of the file has been reached
                    if (String.IsNullOrEmpty(this.contentByLine[ctr]) != true)
                    {
                        endpos = ctr - 1;
                    }
                }
                if (ctr == endOfFile)
                {
                    endpos = ctr-1;
                }
            }
            return endpos;
        }

        public int findBracketedFunctions(int startpos)
        {
            //when the number of opening brackets equals closing, the function has completed
            string openBrack = @"{";
            string closeBrack = @"}";
            int openBrackCount = 1;
            int closeBrackCount = 0;
            int endpos = startpos;

            for (int ctr = startpos + 1; endpos == startpos; ctr++)
            {
                if (!(string.IsNullOrWhiteSpace(this.contentByLine[ctr])))
                {
                    if (this.contentByLine[ctr].Contains(openBrack))
                    {
                        openBrackCount = openBrackCount + 1;
                    }
                    if (this.contentByLine[ctr].Contains(closeBrack))
                    {
                        closeBrackCount = closeBrackCount + 1;
                    }
                    if (openBrackCount == closeBrackCount)
                    {
                        endpos = ctr;
                    }
                }
            }
            return endpos;
        }

        public int findDeclaredFunctions(int startpos)
        {
            //uses text to determine start and end
            int endpos = startpos;

            for (int ctr = startpos + 1; endpos == startpos; ctr++)
            {
                if (this.contentByLine[ctr].Contains(this.fileLanguage.myEndFunction))
                {
                    endpos = ctr;
                }
            }
            return endpos;
        }
    }
}
