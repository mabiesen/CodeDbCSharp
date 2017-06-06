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
    public partial class HelpInfoForm : Form
    {
        public HelpInfoForm()
        {
            InitializeComponent();
        }

        private void HelpInfoForm_Load(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox1.AppendText("Uploading Functions from Files:");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("To upload functions from files, click the appropriate button in the m main menu and select a file for upload. " + 
                "If the file extension is related to one of the acceptable languages, the program will look through the file for functions in that language syntax" + 
                " and display the results in a table for viewing.");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("It is crucial at this time that functions follow a specific format in order to be recognizes by the program.");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("1.  Always include the arguments parentheses even when no arguments are required");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("2. The function call should be written as one line up to and including the start of the function block.  For instance, if the language is CSharp the program would look for opening braces on the same line as the function call.");
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
