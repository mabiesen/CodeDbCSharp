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
    public partial class dbBrowseForm : Form
    {
        public dbBrowseForm()
        {
            InitializeComponent();
        }

        private void langSearchBox_TextChanged(object sender, EventArgs e)
        {
            filterDatagridAllBoxes();
        }

        private void importSearchBox_TextChanged(object sender, EventArgs e)
        {
            filterDatagridAllBoxes();
        }

        private void tagSearchBox_TextChanged(object sender, EventArgs e)
        {

            filterDatagridAllBoxes();
        }

        private void editFuncBtn_Click(object sender, EventArgs e)
        {
            if (functionBrowse.SelectedRows.Count > 0)
            {
                GlobalVariables.activeFunctionIndex = functionBrowse.SelectedRows[0].Index;
                GlobalVariables.activeFunctionIndicator = GlobalVariables.activeTableIndicator;
                GlobalVariables.setActiveFunctionList();
                functionEditForm myNewForm = new functionEditForm();
                myNewForm.ShowDialog();
            }
        }

        private void mainMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dbBrowseForm_Activated(object sender, EventArgs e)
        {
            functionBrowse.DataSource = GlobalVariables.activeTable;
            crntRevBox.Text = GlobalVariables.activeTableIndicator;
            functionBrowse.Refresh();
            if(GlobalVariables.activeTableIndicator != "LIBRARY")
            {
                rmvFromLibBtn.Hide();
            }
            else
            {
                libraryAddBtn.Hide();
            }
        }

        private void filterDatagridAllBoxes()
        {
            string mainSearchString = "";
            string tempString = "";
            string escapedText = "";

            int ctr = 0;

            string langSearch = langSearchBox.Text;
            string importSearch = importSearchBox.Text;
            string tagSearch = tagSearchBox.Text;
            string funcSearch = funcSearchBox.Text;
            string purpSearch = purpSearchBox.Text;

            string keySearch = "";      //Keyword was not working properly, removing keyword box

            Dictionary<string, string> dictOfColumns = new Dictionary<string, string>();
            dictOfColumns.Add("Language", langSearch);
            dictOfColumns.Add("Imports", importSearch);
            dictOfColumns.Add("Tags", tagSearch);
            dictOfColumns.Add("Prototype", "");
            dictOfColumns.Add("WholeFunction", funcSearch);
            dictOfColumns.Add("Purpose", purpSearch);

            //First, create a dictitionary of all columns
            //The dictionary should have blank values, EXCEPT for lang,imports, and tags, which will have textbox values
            //Second, iterate through the dictionary.  If value, put Contains.  If null, skip.  If keyword and contains, OR statement.  If just keyword, normal statement

            foreach (KeyValuePair<string, string> kvp in dictOfColumns)
            {
                //clear the temp variable
                tempString = "";

                //check that the value is not blank, if not structure info and add to temp string
                if (!(string.IsNullOrWhiteSpace(kvp.Value)))
                {
                    escapedText = kvp.Value.Replace("'", "''");
                    tempString = kvp.Key + " LIKE '%" + escapedText + "%'";

                    if (!(string.IsNullOrWhiteSpace(keySearch)))
                    {
                        escapedText = keySearch.Replace("'", "''");
                        tempString = tempString + " OR " + kvp.Key + " LIKE '%" + escapedText + "%'";
                    }
                }
                else
                {
                    //Add keysearch to temp string as primary line
                    if (!(string.IsNullOrWhiteSpace(keySearch)))
                    {
                        escapedText = keySearch.Replace("'", "''");
                        tempString = kvp.Key + " LIKE '%" + escapedText + "%'";
                    }
                }

                //add temp string to main string if and only if not blank
                if (!(string.IsNullOrWhiteSpace(tempString)))
                {
                    if(ctr == 0)
                    {
                        mainSearchString = tempString;
                        ctr = ctr + 1;
                    }else
                    {
                        mainSearchString = mainSearchString + " AND " + tempString;
                    }
                }
                
            }
            GlobalVariables.activeTable.DefaultView.RowFilter = mainSearchString;

        }

        private void saveToFile_Click(object sender, EventArgs e)
        {
            GlobalVariables.activeFunctionIndicator = GlobalVariables.activeTableIndicator;
            GlobalVariables.setActiveFunctionList();
            fileAttributesModalForm modalForm = new fileAttributesModalForm();
            modalForm.ShowDialog();
        }

        private void rmvFromLibBtn_Click(object sender, EventArgs e)
        {

            int count = functionBrowse.SelectedRows.Count;
            for(int i = 0; i < count; i++)
            {
                GlobalVariables.libraryFunctions.removeFunction(Convert.ToString(functionBrowse.SelectedRows[i].Cells["Prototype"].Value));
            }
            GlobalVariables.setActiveTable();
            functionBrowse.DataSource = GlobalVariables.activeTable;
            functionBrowse.Refresh();
        }

        private void dbBrowseForm_Load(object sender, EventArgs e)
        {
            GlobalVariables.addAForm(this);
        }

        private void libraryAddBtn_Click(object sender, EventArgs e)
        {
            int count = functionBrowse.SelectedRows.Count;
            GlobalVariables.activeFunctionIndicator = GlobalVariables.activeTableIndicator;
            GlobalVariables.setActiveFunctionList();
            for (int i = 0; i < count; i++)
            {
                //Cycle through the selected rows, grab functions from the active database.
                //Perform a prototype check to make sure the function isn't already there.
                //NOTE: this is okay to do because the database and file indexers do not update functions.
                //otherwise, we might have to worry about references
                if (!(GlobalVariables.libraryFunctions.containsPrototype(GlobalVariables.activeFunctionList.functionList[i].myPrototype)))
                {
                    GlobalVariables.libraryFunctions.addFunction(GlobalVariables.activeFunctionList.functionList[i]);
                }
                
            }
            MessageBox.Show("Added the selected functions to the library");
        }

        private void funcSearchBox_TextChanged(object sender, EventArgs e)
        {
            filterDatagridAllBoxes();
        }

        private void purpSearchBox_TextChanged(object sender, EventArgs e)
        {
            filterDatagridAllBoxes();
        }
    }
}
