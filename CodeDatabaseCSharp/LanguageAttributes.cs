using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDatabaseCSharp
{
    public class LanguageAttributes
    {

        //in order: language, extension, comment symbol, start function text, end function text, and function type
        public string myLanguage = "";
        public string myExtension = "";
        public string myCommentSymbol = "";
        public string myStartFunction = "";
        public string myEndFunction = "";
        public string myFunctionType = "";
        public string myStartImports = "";
        public string myEndImports = "";
        public string mySyntaxRef = "";


        //Note: Ideally change this to dictionary for easy reference
        //In order:  language, extension, single-line-comment, startfunc reference, endfunc reference, type of function search, import start, import end, sytnaxref
        //Note: import statements have spaces intentially.  some languages like ruby require the import to be quoted
        public string[,] languageMatrix = {
        {"python",".py",@"#","def ","null","positional", "import ","","python"},
        {"csharp",".cs",@"//",@"{","null", "bracket","using ",@";","csharp"},
        {"vbfunction",".vb",@"'","Function","End Function", "declared", "Imports ","","vb"},
        {"vbsub",".vb",@"'","Sub","End Sub", "declared", "Imports ","","vb"},
        {"go",".go", @"//",@"{","null","bracket","import ","","csharp"},   //go functions can be preceeded by func too
        {"javascript",".js",@"//",@"{","null","bracket","import ",@";","js" },
        {"ruby",".rb",@"#","def ","end","declared","require '","'","python" }
        };

        public LanguageAttributes()
        {

        }

        public void setLanguageAttributes(string suppliedLanguage)
        {
            for (int i = 0; i < this.languageMatrix.GetLength(0); i++)
            {
                if (suppliedLanguage.ToLower() == this.languageMatrix[i, 0])
                {
                    myLanguage = this.languageMatrix[i, 0];
                    myExtension = this.languageMatrix[i, 1];
                    myCommentSymbol = this.languageMatrix[i, 2];
                    myStartFunction = this.languageMatrix[i, 3];
                    myEndFunction = this.languageMatrix[i, 4];
                    myFunctionType = this.languageMatrix[i, 5];
                    myStartImports = this.languageMatrix[i, 6];
                    myEndImports = this.languageMatrix[i, 7];
                    mySyntaxRef = this.languageMatrix[i,8];
                }
            }
        }

        public List<string> provideListOfAvailableLanguages()
        {
            List<string> thisList = new List<string>();

            for(int i = 0; i < this.languageMatrix.GetLength(0); i++)
            {
                thisList.Add(this.languageMatrix[i, 0]);
            }

            return thisList;
        }

        public void clearAllLangAttributes()
        {
            this.myLanguage = "";
            this.myExtension = "";
            this.myCommentSymbol = "";
            this.myStartFunction = "";
            this.myEndFunction = "";
            this.myFunctionType = "";
            this.myStartImports = "";
            this.myEndImports = "";
        }
    }
}
