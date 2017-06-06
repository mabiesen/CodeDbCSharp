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
    public partial class fileAttributesModalForm : Form
    {
        public fileAttributesModalForm()
        {
            InitializeComponent();
        }

        private void fldrSelectBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                fldSelectBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void fileAttributesModalForm_Load(object sender, EventArgs e)
        {
            //Fill the language listbox using LanguageAttribues.  Add "NONE" as first item for default
            LanguageAttributes tempAttr = new LanguageAttributes();
            List<string> tempLangList = new List<string>();
            tempLangList = tempAttr.provideListOfAvailableLanguages();
            langListBox.DataSource = tempAttr.provideListOfAvailableLanguages();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            if(langListBox.GetItemText(langListBox.SelectedItem) == "NONE" || string.IsNullOrWhiteSpace(fldSelectBox.Text) || string.IsNullOrWhiteSpace(fileNameBox.Text))
            {
                MessageBox.Show("Not all information provided.  Please make certain that all fields have been filled and that the language is not set to NONE");
            }else
            {
                //set the indexer language to allow for accurate file writing
                GlobalVariables.activeFunctionList.setIndexerLanguage(langListBox.GetItemText(langListBox.SelectedItem));

                //Check if the functions in the indexer are all the selected Language. Ask user for permission to continue if not.
                if (GlobalVariables.activeFunctionList.areAllFuncLanguagesSameAsIndexer())
                {
                    writeFunctionsToFile();
                }
                else
                {
                    DialogResult myAnswer = MessageBox.Show("Not all functions in the indexer matched the selected language. Continue?", "Language Mismatch", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (myAnswer == DialogResult.OK)
                    {
                        writeFunctionsToFile();
                    }
                }
            }
            this.Close();
        }

        private void writeFunctionsToFile()
        {
            string fullFilePath = fldSelectBox.Text + @"\" + fileNameBox.Text + GlobalVariables.activeFunctionList.indexerLanguage.myExtension;
            GlobalVariables.activeFunctionList.printFunctionsToFile(fullFilePath);
            MessageBox.Show("The file has been created at the identified location");
        }
    }
}
