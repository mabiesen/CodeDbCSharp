using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeDatabaseCSharp
{
    public class individualFunction
    {
        public string myPrototype = "";
        public List<string> myImports = new List<string>();
        public List<string> myTags = new List<string>();
        public string myLanguage = "";
        public string myFunction = "";
        public string myPurpose = "";

        public LanguageAttributes functionLanguage = new LanguageAttributes();

        public individualFunction(string prototype = "", string imports = "", string tags = "", string language = "", string function = "", string purpose = "")
        {
            updateFunctionAttributes(prototype, imports, tags, language, function, purpose);
        }

        public void updateFunctionAttributes(string prototype = "", string imports = "", string tags = "", string language = "", string function = "", string purpose = "")
        {
            this.myTags.Clear();
            this.myImports.Clear();
            this.functionLanguage.clearAllLangAttributes();
            //convert tags and imports to comma separated lists
            this.myPurpose = purpose;
            if (imports.Contains(","))
            {
                List<string> tempimports = imports.Split(',').ToList();
                foreach(string thisimport in tempimports)
                {
                      addToImports(thisimport);
                }
            }
            else
            {
                addToImports(imports);
            }

            if (tags.Contains(","))
            {
                List<string> temptags = tags.Split(',').ToList();
                foreach(string thistag in temptags)
                {
                       addToTags(thistag);
                }
            }
            else
            {
                addToTags(tags);
            }


            this.myFunction = function;
            if (prototype == "")
            {
                updatePrototypeFromFunction();
            }
            else
            {
                this.myPrototype = prototype;
            }
            this.myLanguage = language;
            this.functionLanguage.setLanguageAttributes(language);
        }

        //This method is necessary in order to update prototype when user updates function
        public void updatePrototypeFromFunction()
        {
            //Convert string to array of strings by line
            //go through each line looking for function start indication
            //if line contains function keyword AND a parentheses, set prototype and quit

            string tempstring = "";
            string[] contentByLine = this.myFunction.Split('\n');
            if(this.functionLanguage.myStartFunction != "")
            {
                foreach (var line in contentByLine)
                {
                    if (line.Contains(this.functionLanguage.myStartFunction) && line.Contains(@"("))
                    {
                        tempstring = line;
                        break;
                    }
                }
                tempstring = tempstring.Trim();
                tempstring = Regex.Replace(tempstring, Environment.NewLine, "");
                this.myPrototype = tempstring;
            }
            else
            {
                this.myPrototype = "";
            }
        }

        //Display imports as comma separated string
        public string importsForNewFunc()
        {
            var myreturn = "";
            foreach (string thisimport in this.myImports)
            {
                myreturn = myreturn + "," + thisimport;
            }
            return myreturn;
        }

        //Display tags as comma separated string
        public string tagsForNewFunc()
        {
            var myreturn = "";
            foreach (string thistag in this.myTags)
            {
                myreturn = myreturn + "," + thistag;
            }
            return myreturn;
        }

        //Display imports as one on each line
        public string importsForTextBox()
        {
            var myreturn = "";
            foreach(string thisimport in this.myImports)
            {
                myreturn = myreturn + thisimport + Environment.NewLine;
            }
            return myreturn;
        }

        //Display tags as one on each line
        public string tagsForTextBox()
        {
            var myreturn = "";
            foreach (string thistag in this.myTags)
            {
                myreturn = myreturn + thistag + Environment.NewLine;
            }
            return myreturn;
        }

        //all added imports pass through here.  controls for newline, space, and nulls
        public void addToImports(string newImport)
        {
            if(newImport != "")
            {

                if (!(string.IsNullOrWhiteSpace(newImport)))
                {
                    int numMatches = 0;
                    string noSpaces = "";
                    string noReturns = "";
                    noSpaces = Regex.Replace(newImport, @"\s+", "");
                    noReturns = Regex.Replace(noSpaces, Environment.NewLine, "");
                    noReturns = noReturns.Trim();
                    //if statement to determine if import already exists for the function; do not add if it does
                    int count = this.myImports.Count;
                    for(int ctr = 0; ctr < count; ctr++)
                    {
                        if(this.myImports[ctr] == noReturns)
                        {
                            numMatches++;
                        }
                    }
                    if(numMatches == 0)
                    {
                        this.myImports.Add(noReturns);
                    }
                }
            }
        }

        public void removeFromImports(int delImport)
        {
            if(this.myImports.Count > 0 && delImport < this.myImports.Count && delImport >= 0)
            {
                this.myImports.RemoveAt(delImport);
            }else
            {
                Console.WriteLine("Attempted to delete import, no import was selected.");
            }
        }

        //all added tags pass through here.  controls for newline, space, and nulls
        public void addToTags(string newTag)
        {
            if (newTag != "")
            {
                if (string.IsNullOrWhiteSpace(newTag))
                {

                }
                else
                {
                    int numMatches = 0;
                    string noSpaces = "";
                    string noReturns = "";
                    noSpaces = Regex.Replace(newTag, @"\s+", "");
                    noReturns = Regex.Replace(noSpaces, Environment.NewLine, "");

                    int count = this.myTags.Count;
                    for(int ctr = 0; ctr < count; ctr++)
                    {
                        if(noReturns == this.myTags[ctr])
                        {
                            numMatches++;
                        }
                    }
                    if(numMatches == 0)
                    {
                        this.myTags.Add(noReturns);
                    }
                }
            }

        }

        public void removeFromTags(int delTag)
        {
            //Controls in place for UI
            if (this.myTags.Count > 0 && delTag < this.myTags.Count && delTag >= 0)
            {
                this.myTags.RemoveAt(delTag);
            }else
            {
                Console.WriteLine("Attempted to delete tag, no tag was selected.");
            }
        }

        public void ClearAll()
        {
            this.myFunction = "";
            this.myPrototype = "";
            this.myLanguage = "";
            this.myPurpose = "";

            this.myImports.Clear();
            this.myTags.Clear();
        }
    }
}
