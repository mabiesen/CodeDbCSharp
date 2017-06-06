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
    public partial class SelectLanguageForm : Form
    {
        public SelectLanguageForm()
        {
            InitializeComponent();
        }

        private void SelectLanguageForm_Load(object sender, EventArgs e)
        {
            LanguageAttributes refInstance = new LanguageAttributes();
            langListBox.DataSource = refInstance.provideListOfAvailableLanguages();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            GlobalVariables.userFileLanguage = langListBox.SelectedValue.ToString();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
