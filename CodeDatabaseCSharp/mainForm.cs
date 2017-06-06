using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeDatabaseCSharp
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void indFuncBtn_Click(object sender, EventArgs e)
        {
            GlobalVariables.activeFunctionIndicator = "NONE";
            GlobalVariables.setActiveFunctionList();
            GlobalVariables.activeFunctionIndex = 0;
            functionEditForm myNewForm = new functionEditForm();
            myNewForm.ShowDialog();
        }

        private void fileFuncBtn_Click(object sender, EventArgs e)
        {
            string filePath = "";
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Console.WriteLine("opening file...");
                
                //Get file extension to determine language
                filePath = openFileDialog1.FileName;

                //Read the file and parse
                readFunctionFileClass myFile = new readFunctionFileClass(filePath);

                //Set global fileFunctions indexer
                GlobalVariables.fileFunctions.replaceFunctionsList(myFile.fileFunctions.functionList);

                if(GlobalVariables.fileFunctions.NumFunctions > 0)
                {
                    GlobalVariables.activeTableIndicator = "FILE";
                    GlobalVariables.activeTable = GlobalVariables.fileFunctions.createFunctionTable();
                    dbBrowseForm myNewForm = new dbBrowseForm();
                    myNewForm.ShowDialog();
                }else
                {
                    SelectLanguageForm aNewForm = new SelectLanguageForm();
                    aNewForm.ShowDialog();
                    if(GlobalVariables.userFileLanguage != "")
                    {
                        myFile.userSetFileLanguage(GlobalVariables.userFileLanguage);
                        myFile.getFunctionAttributes();
                        GlobalVariables.fileFunctions.replaceFunctionsList(myFile.fileFunctions.functionList);
                        if(GlobalVariables.fileFunctions.NumFunctions > 0)
                        {
                            GlobalVariables.activeTableIndicator = "FILE";
                            GlobalVariables.activeTable = GlobalVariables.fileFunctions.createFunctionTable();
                            dbBrowseForm myNewForm = new dbBrowseForm();
                            myNewForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("No functions were detected.  Either the wrong language was selected or no functions in the file match the specified format.");
                        }
                    }else
                    {
                        MessageBox.Show("You selected to cancel the file upload.");
                    }
                }
            }
        }

        private void editLibBtn_Click(object sender, EventArgs e)
        {
            if(GlobalVariables.libraryFunctions.NumFunctions != 0)
            {
                GlobalVariables.activeTableIndicator = "LIBRARY";
                GlobalVariables.activeTable = GlobalVariables.libraryFunctions.createFunctionTable();
                dbBrowseForm myNewForm = new dbBrowseForm();
                myNewForm.ShowDialog();
            } else
            {
                MessageBox.Show("The library is empty. Make new functions, grab functions from the database, or get functions from a file");
            }

        }


        private void brsDbBtn_Click_1(object sender, EventArgs e)
        {

            GlobalVariables.activeTableIndicator = "DATABASE";

            //refresh the database indexer
            GlobalVariables.refreshDatabaseIndexer();
            
            dbBrowseForm myNewForm = new dbBrowseForm();
            myNewForm.ShowDialog();
        }

        private void brsDbBtn_MouseHover(object sender, EventArgs e)
        {
            infoBox.Text = "";
            infoBox.AppendText("Browse Database:");
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText("Browse through all functions in database");
        }

        private void indFuncBtn_MouseHover(object sender, EventArgs e)
        {
            infoBox.Text = "";
            infoBox.AppendText("Add Individual Function");
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText("Add a new function to the database from scratch");
        }

        private void fileFuncBtn_MouseHover(object sender, EventArgs e)
        {
            infoBox.Text = "";
            infoBox.AppendText("Add a Full File of Functions");
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText("Use this program to parse through old code and extract the functions used.");
            infoBox.AppendText(Environment.NewLine);
        }

        private void editLibBtn_MouseHover(object sender, EventArgs e)
        {
            infoBox.Text = "";
            infoBox.AppendText("Manage library functions.");
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText(Environment.NewLine);
            infoBox.AppendText("After adding newly created functions, database functions, and file functions, review, delete unwanted functions and save functions to a file.");
            infoBox.AppendText(Environment.NewLine);
            
        }

        private void saveLibBtn_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelpInfoForm helpForm = new HelpInfoForm();
            helpForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
