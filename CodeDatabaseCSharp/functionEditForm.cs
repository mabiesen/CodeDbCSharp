using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.IO;

namespace CodeDatabaseCSharp
{
    public partial class functionEditForm : Form
    {
        public functionEditForm()
        {
            InitializeComponent();
            //Line below used for 
            this.functionColorBox.ActiveTextAreaControl.TextArea.KeyUp += new KeyEventHandler(this.TextEditor_KeyUp);
        }


        private void functionEditForm_Load(object sender, EventArgs e)
        {
            GlobalVariables.addAForm(this);
            functionColorBox.Width = 400;
            displayNewFunction();
        }

        private void TextEditor_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine(this.functionColorBox.Text);
            captureLanguageAndFunctionUpdatePrototype();
        }

        //Add import to active function and update imports deletes and display boxes
        private void importAddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(importsAddBox.Text))
            {

            }else
            {
                //NOTE: add a check to make sure import is not a duplicate
                GlobalVariables.activeFunctionFunction.addToImports(importsAddBox.Text);
                importsDelListBox.DataSource = null;
                importsMainBox.Text = GlobalVariables.activeFunctionFunction.importsForTextBox();
                importsDelListBox.DataSource = GlobalVariables.activeFunctionFunction.myImports;
                importsDelListBox.Update();
            }
            importsAddBox.Clear();
        }

        //Delete import from active function and update imports deletes and display boxes
        private void importDelBtn_Click(object sender, EventArgs e)
        {
            if(importsDelListBox.Items.Count > 0)
            {
                GlobalVariables.activeFunctionFunction.removeFromImports(importsDelListBox.SelectedIndex);
                importsDelListBox.DataSource = null;
                importsDelListBox.DataSource = GlobalVariables.activeFunctionFunction.myImports;
                importsMainBox.Text = GlobalVariables.activeFunctionFunction.importsForTextBox();
                importsDelListBox.Update();
            }
        }


        private void tagsAddBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tagsAddBox.Text))
            {

            }else
            {
                //NOTE: add a check to insure that tag is not duplicate
                GlobalVariables.activeFunctionFunction.addToTags(tagsAddBox.Text);
                tagsDelBox.DataSource = null;
                tagsMainBox.Text = GlobalVariables.activeFunctionFunction.tagsForTextBox();
                tagsDelBox.DataSource = GlobalVariables.activeFunctionFunction.myTags;
                tagsDelBox.Update();
            }
            tagsAddBox.Clear();
        }

        private void tagsDelBtn_Click(object sender, EventArgs e)
        {
            if (tagsDelBox.Items.Count > 0)
            {
                GlobalVariables.activeFunctionFunction.removeFromTags(tagsDelBox.SelectedIndex);
                tagsDelBox.DataSource = null;
                tagsDelBox.DataSource = GlobalVariables.activeFunctionFunction.myTags;
                tagsMainBox.Text = GlobalVariables.activeFunctionFunction.tagsForTextBox();
                tagsDelBox.Update();
            }
        }

        //Check that prototype is valid and that there is no existing prototype
        //If we are overwriting
        private void addToDbBtn_Click(object sender, EventArgs e)
        {
            //make sure new prototype is not blank
            if(String.IsNullOrWhiteSpace(GlobalVariables.activeFunctionFunction.myPrototype))
            {
                MessageBox.Show("The prototype is currently null, probably due to an inaccurate syntax or undocumented language.  Please correct your function and/or change your function language and try again");
            }
            else
            {
                
                //Check if database indexer contains the prototype being added.  If it does, ask if we should delete the old and create new
                if(GlobalVariables.databaseFunctions.containsPrototype(GlobalVariables.activeFunctionFunction.myPrototype))
                {
                    DialogResult dialogResult = MessageBox.Show("The prototype for this function already exists in the database.  Overwrite existing function?","Prototype already exists", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        GlobalVariables.removeFromDatabase();
                        GlobalVariables.addToDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Cancelling database update.  To prevent overwriting an existing function, please change the name of the current function");
                    }
                }else
                {
                    GlobalVariables.addToDatabase();
                    MessageBox.Show("Function was added to database.");
                }
            }
        }


        //NOTE: it appears that individualFunction instances are passed by reference.  To that end, created temp function in this method
        private void addToLibBtn_Click(object sender, EventArgs e)
        {

            individualFunction tempfunction = new individualFunction(GlobalVariables.activeFunctionFunction.myPrototype, GlobalVariables.activeFunctionFunction.importsForNewFunc(), GlobalVariables.activeFunctionFunction.tagsForNewFunc(), GlobalVariables.activeFunctionFunction.myLanguage, GlobalVariables.activeFunctionFunction.myFunction, GlobalVariables.activeFunctionFunction.myPurpose);

            if (String.IsNullOrWhiteSpace(GlobalVariables.activeFunctionFunction.myPrototype))
            {
                MessageBox.Show("The prototype is currently null, probably due to an inaccurate syntax or undocumented language.  Please correct your function and/or change your function language and try again");
            }
            else
            {
                //Check if library indexer contains the prototype being added.  If it does, ask if we should delete the old and create new
                if (GlobalVariables.libraryFunctions.containsPrototype(GlobalVariables.activeFunctionFunction.myPrototype))
                {
                    DialogResult dialogResult = MessageBox.Show("The prototype for this function already exists in the library.  Overwrite existing function?", "Prototype already exists", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        GlobalVariables.libraryFunctions.removeFunction(GlobalVariables.activeFunctionFunction.myPrototype);
                        GlobalVariables.libraryFunctions.addFunction(tempfunction);
                        GlobalVariables.setActiveFunctionList();
                        GlobalVariables.setActiveTable();
                        MessageBox.Show("The function has been added to the library");
                    }
                }else
                {
                    
                    GlobalVariables.libraryFunctions.addFunction(tempfunction);
                    GlobalVariables.setActiveFunctionList();
                    GlobalVariables.setActiveTable();
                    MessageBox.Show("Function has been added to library.");
                }
            }

        }


        private void mainMenuBtn_Click(object sender, EventArgs e)
        {
            //Close this window, close any open tables, return to main menu
            GlobalVariables.closeToMainMenu();
        }

        private void purposeBox_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.activeFunctionFunction.myPurpose = purposeBox.Text;
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if(GlobalVariables.activeFunctionIndex - 1 >= 0)
            {
                GlobalVariables.activeFunctionIndex = GlobalVariables.activeFunctionIndex - 1;
                displayNewFunction();
            }
            else
            {
                MessageBox.Show("Reached end of list");
            }
        }

        private void nxtBtn_Click(object sender, EventArgs e)
        {
            if(GlobalVariables.activeFunctionIndex + 1 < GlobalVariables.activeFunctionList.NumFunctions)
            {
                GlobalVariables.activeFunctionIndex = GlobalVariables.activeFunctionIndex + 1;
                displayNewFunction();
            }
            else
            {
                MessageBox.Show("Reached end of list");
            }
        }

        private void displayNewFunction()
        {
            //Show which function we are currently review
            funcNumBox.Text = "Viewing Function " + (GlobalVariables.activeFunctionIndex + 1) + " Of " + GlobalVariables.activeFunctionList.NumFunctions;

            //Set the listbox items
            importsDelListBox.DataSource = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].myImports;
            tagsDelBox.DataSource = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].myTags;
            LanguageAttributes refAttr = new LanguageAttributes();
            langListBox.DataSource = refAttr.provideListOfAvailableLanguages();

            //Get the attributes for the currently reviewed function
            string crntprototype = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].myPrototype;
            string crntpurpose = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].myPurpose;
            string crntlanguage = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].myLanguage;
            string crntfunction = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].myFunction;
            string crntimports = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].importsForTextBox();
            string crnttags = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].tagsForTextBox();

            
            //Set the textboxes
            crntRevBox.Text = GlobalVariables.activeFunctionIndicator;
            tagsMainBox.Text = crnttags;
            importsMainBox.Text = crntimports;
            functionColorBox.Text = crntfunction;
            functionColorBox.Refresh();
            if(!(string.IsNullOrWhiteSpace(crntlanguage)))
            {
                List<string> tempList = refAttr.provideListOfAvailableLanguages();
                int languageCount = tempList.Count;
                for (int ctr = 0; ctr < languageCount; ctr++)
                {
                    if(tempList[ctr] == crntlanguage)
                    {
                        langListBox.SelectedIndex = ctr;
                        captureLanguageAndFunctionUpdatePrototype();
                    }
                }
                
            }
            else
            {
                langListBox.SelectedIndex = 0;
                captureLanguageAndFunctionUpdatePrototype();
            }

            purposeBox.Text = crntpurpose;
            protoBox.Text = crntprototype;

            //Create line separated string of tags for display
            string formattedTags = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].tagsForNewFunc();
            string formattedImports = GlobalVariables.activeFunctionList.functionList[GlobalVariables.activeFunctionIndex].importsForNewFunc();

            //Set the active function, which will allow us to hold changes without affecting indexers
            GlobalVariables.activeFunctionFunction.updateFunctionAttributes(crntprototype, formattedImports, formattedTags, crntlanguage, crntfunction, crntpurpose);
        }

        private void langListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            captureLanguageAndFunctionUpdatePrototype();
            setTheSyntaxHighlights();
        }

        private void captureLanguageAndFunctionUpdatePrototype()
        {
            GlobalVariables.activeFunctionFunction.myFunction = functionColorBox.Text;
            GlobalVariables.activeFunctionFunction.myLanguage = langListBox.SelectedValue.ToString();
            GlobalVariables.activeFunctionFunction.functionLanguage.setLanguageAttributes(langListBox.SelectedValue.ToString());
            GlobalVariables.activeFunctionFunction.updatePrototypeFromFunction();
            protoBox.Text = GlobalVariables.activeFunctionFunction.myPrototype;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void functionColorBox_Load(object sender, EventArgs e)
        {
            string dirc = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(dirc))
            {

                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                setTheSyntaxHighlights();
            }
        }

        private void setTheSyntaxHighlights()
        {
                functionColorBox.SetHighlighting(GlobalVariables.activeFunctionFunction.functionLanguage.mySyntaxRef);
        }
    }
}
