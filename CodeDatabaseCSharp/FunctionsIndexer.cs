using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeDatabaseCSharp
{
    public class FunctionsIndexer
    {
        public List<string> tableImports = new List<string>();
        public List<individualFunction> functionList = new List<individualFunction>();
        public List<string> tablePrototypes = new List<string>();
        public int NumFunctions = 0;

        public LanguageAttributes indexerLanguage = new LanguageAttributes();

        public FunctionsIndexer()
        {

        }

        public void addFunction(individualFunction thisFunction)
        {
            this.functionList.Add(thisFunction);
            this.NumFunctions += 1;
            updateImportsList();
            updatePrototypesList();
        }

        //This method cycles through list and removes function
        //NOTE: this method was failing when only one function was present using a foreach method
        //To bypass this issue, upted for a 'for' loop with counter
        public void removeFunction(string thisPrototype)
        {
            int count = this.functionList.Count;
                
            for(int ctr = 0; ctr < count; ctr++)
            {
                if(this.functionList[ctr].myPrototype == thisPrototype)
                {
                    this.functionList.RemoveAt(ctr);
                    this.NumFunctions -= 1;
                    count = count - 1;
                    updateImportsList();
                    updatePrototypesList();
                }
            }
        }

        //Clears all variables: all functions and all variables related to funcions
        public void removeAllFunctions()
        {
            this.functionList.Clear();
            this.tableImports.Clear();
            this.tablePrototypes.Clear();
            this.NumFunctions = 0;
        }

        //Replace the current list of functions
        public void replaceFunctionsList(List<individualFunction> newFunctionList)
        {
            removeAllFunctions();
            foreach(individualFunction thisfunction in newFunctionList)
            {
                addFunction(thisfunction);
            }
        }

        //Accepts a properly formatted table to replace the function list
        //Used for SQL Select statements
        public void tableReplacesFunctionList(DataTable thistable)
        {
            removeAllFunctions();

            string Prototype = "";
            string Purpose = "";
            string WholeFunction = "";
            string Language = "";
            string Imports = "";
            string Tags = "";
            foreach (DataRow row in thistable.Rows)
            {
                Prototype = row["Prototype"].ToString();
                Purpose = row["Purpose"].ToString();
                WholeFunction = row["WholeFunction"].ToString();
                Language = row["Language"].ToString();
                Imports = row["Imports"].ToString();
                Tags = row["Tags"].ToString();

                individualFunction newFunction = new individualFunction(Prototype, Imports, Tags, Language, WholeFunction, Purpose);
                addFunction(newFunction);
            }
        }

        //Check whether any function in indexer contains a given prototype, return true or false
        public bool containsPrototype(string prototypeToFind)
        {
            bool myreturn = this.tablePrototypes.Contains(prototypeToFind);
            return myreturn;
        }

        //Set the language Attributes class of the indexer
        public void setIndexerLanguage(string thislanguage)
        {
            this.indexerLanguage.setLanguageAttributes(thislanguage);
        }

        //Print functions to file.
        //NOTE: CURRENTLY PRINT PUTS EMPTY LINES BETWEEN FUNCTION LINES.  CORRECT WITH TRIM?
        public void printFunctionsToFile(string fullFilePath)
        {

            //line below suggested by internet, don't understd it
            //string defaultDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            List<string> sb = new List<string>();

            string tempLine = "";

            string importsComment = "Function Imports: ";
            string tagsComment = "Function Tags: ";
            string purposeComment = "Function Purpose: ";

            // Add uncommented imports to the top of the file
            if(this.tableImports.Count > 0)
            {
                foreach (string thisimport in this.tableImports)
                {
                    tempLine = this.indexerLanguage.myStartImports + thisimport + this.indexerLanguage.myEndImports;
                    sb.Add(tempLine);
                }
                sb.Add("");
                sb.Add("");
            }


            // First create a string of data with our file contents
            foreach (individualFunction function in this.functionList)
            {
                if (!(string.IsNullOrWhiteSpace(function.myPurpose)))
                {
                    tempLine = this.indexerLanguage.myCommentSymbol + purposeComment + function.myPurpose;
                    sb.Add(tempLine);
                }
                if(function.myImports.Count > 0)
                {
                    tempLine = this.indexerLanguage.myCommentSymbol + importsComment + string.Join(",",function.myImports);
                    sb.Add(tempLine);
                }
                if(function.myTags.Count > 0)
                {
                    tempLine = this.indexerLanguage.myCommentSymbol + tagsComment + string.Join(",",function.myTags);
                    sb.Add(tempLine);
                }
                string[] listStrLineElements = function.myFunction.Split('\n');
                foreach (string mystring in listStrLineElements)
                {
                    tempLine = Regex.Replace(mystring, Environment.NewLine, "");
                    tempLine = tempLine.TrimEnd();
                    //Remove the newline?
                    if (!(string.IsNullOrWhiteSpace(tempLine)))
                    {
                        sb.Add(tempLine);
                    }
                }
                //add a blank line for separation purposes
                sb.Add("");
            }
            using (StreamWriter outputFile = new StreamWriter(fullFilePath))
            {
                foreach (string line in sb)
                {
                    outputFile.WriteLine(line);
                }
            }
        }

        //Functions to datatable.  Used to populate datagrids
        public DataTable createFunctionTable()
        {
            DataTable returnTable = new DataTable();
            returnTable.Columns.Add("Prototype");
            returnTable.Columns.Add("Purpose");
            returnTable.Columns.Add("WholeFunction");
            returnTable.Columns.Add("Language");
            returnTable.Columns.Add("Imports");
            returnTable.Columns.Add("Tags");

            foreach (individualFunction thisfunction in this.functionList)
            {
                returnTable.Rows.Add(thisfunction.myPrototype, thisfunction.myPurpose, thisfunction.myFunction, thisfunction.myLanguage, string.Join(",", thisfunction.myImports), string.Join(",", thisfunction.myTags));
            }
            return returnTable;
        }

        //Update the public imports list with no duplicates and no blanks
        public void updateImportsList()
        {
            this.tableImports.Clear();
            List<string> tempImportsList = new List<string>();

            int importCount = 0;
            int functionCount = 0;
            string import = "";

            functionCount = this.functionList.Count;
            for(int ctra = 0; ctra < functionCount; ctra++)
            {
                importCount = this.functionList[ctra].myImports.Count;
                for(int ctrb = 0; ctrb < importCount; ctrb++)
                {
                    import = this.functionList[ctra].myImports[ctrb];
                    if (String.IsNullOrEmpty(import))
                    {
                        continue;
                    }
                    else
                    {
                        tempImportsList.Add(import);
                    }
                }
            }
            var noDupes = tempImportsList.Distinct().ToList();
            int noDupesCount = noDupes.Count;
            for(int ctrc = 0; ctrc<noDupesCount; ctrc++)
            {
                this.tableImports.Add(noDupes[ctrc]);
            }
        }

        //Clear the prototype list and re-evaluate
        public void updatePrototypesList()
        {
            this.tablePrototypes.Clear();

            foreach (individualFunction function in this.functionList)
            {
                this.tablePrototypes.Add(function.myPrototype);
            }
        }

        //Check that all functions inside of indexer match the language set for the indexer
        //Used as a control to accurately print functions to file.
        public bool areAllFuncLanguagesSameAsIndexer()
        {
            foreach(individualFunction thisfunction in this.functionList)
            {
                if(thisfunction.myLanguage != this.indexerLanguage.myLanguage)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
