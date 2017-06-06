namespace CodeDatabaseCSharp
{
    partial class dbBrowseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crntRevBox = new System.Windows.Forms.TextBox();
            this.langSearchBox = new System.Windows.Forms.TextBox();
            this.importSearchBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tagSearchBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.functionBrowse = new System.Windows.Forms.DataGridView();
            this.mainMenuBtn = new System.Windows.Forms.Button();
            this.editFuncBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.saveToFile = new System.Windows.Forms.Button();
            this.rmvFromLibBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.libraryAddBtn = new System.Windows.Forms.Button();
            this.funcSearchBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.purpSearchBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.functionBrowse)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1011, 135);
            this.label1.TabIndex = 0;
            this.label1.Text = "Browse Functions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1109, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Currently Reviewing:";
            // 
            // crntRevBox
            // 
            this.crntRevBox.Location = new System.Drawing.Point(1410, 121);
            this.crntRevBox.Name = "crntRevBox";
            this.crntRevBox.ReadOnly = true;
            this.crntRevBox.Size = new System.Drawing.Size(592, 38);
            this.crntRevBox.TabIndex = 2;
            // 
            // langSearchBox
            // 
            this.langSearchBox.Location = new System.Drawing.Point(986, 270);
            this.langSearchBox.Name = "langSearchBox";
            this.langSearchBox.Size = new System.Drawing.Size(286, 38);
            this.langSearchBox.TabIndex = 6;
            this.langSearchBox.TextChanged += new System.EventHandler(this.langSearchBox_TextChanged);
            // 
            // importSearchBox
            // 
            this.importSearchBox.Location = new System.Drawing.Point(1458, 270);
            this.importSearchBox.Name = "importSearchBox";
            this.importSearchBox.Size = new System.Drawing.Size(311, 38);
            this.importSearchBox.TabIndex = 7;
            this.importSearchBox.TextChanged += new System.EventHandler(this.importSearchBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(980, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Language";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1452, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Imports";
            // 
            // tagSearchBox
            // 
            this.tagSearchBox.Location = new System.Drawing.Point(1872, 270);
            this.tagSearchBox.Name = "tagSearchBox";
            this.tagSearchBox.Size = new System.Drawing.Size(300, 38);
            this.tagSearchBox.TabIndex = 11;
            this.tagSearchBox.TextChanged += new System.EventHandler(this.tagSearchBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1866, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 32);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tags";
            // 
            // functionBrowse
            // 
            this.functionBrowse.AllowUserToAddRows = false;
            this.functionBrowse.AllowUserToDeleteRows = false;
            this.functionBrowse.AllowUserToOrderColumns = true;
            this.functionBrowse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.functionBrowse.Location = new System.Drawing.Point(58, 425);
            this.functionBrowse.Name = "functionBrowse";
            this.functionBrowse.ReadOnly = true;
            this.functionBrowse.RowTemplate.Height = 40;
            this.functionBrowse.Size = new System.Drawing.Size(2114, 786);
            this.functionBrowse.TabIndex = 13;
            // 
            // mainMenuBtn
            // 
            this.mainMenuBtn.Location = new System.Drawing.Point(58, 1259);
            this.mainMenuBtn.Name = "mainMenuBtn";
            this.mainMenuBtn.Size = new System.Drawing.Size(355, 57);
            this.mainMenuBtn.TabIndex = 14;
            this.mainMenuBtn.Text = "Main Menu";
            this.mainMenuBtn.UseVisualStyleBackColor = true;
            this.mainMenuBtn.Click += new System.EventHandler(this.mainMenuBtn_Click);
            // 
            // editFuncBtn
            // 
            this.editFuncBtn.Location = new System.Drawing.Point(560, 342);
            this.editFuncBtn.Name = "editFuncBtn";
            this.editFuncBtn.Size = new System.Drawing.Size(514, 57);
            this.editFuncBtn.TabIndex = 15;
            this.editFuncBtn.Text = "Review/Edit Selected Function";
            this.editFuncBtn.UseVisualStyleBackColor = true;
            this.editFuncBtn.Click += new System.EventHandler(this.editFuncBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(398, 32);
            this.label8.TabIndex = 16;
            this.label8.Text = "*Select the row to edit function";
            // 
            // saveToFile
            // 
            this.saveToFile.Location = new System.Drawing.Point(1756, 342);
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(288, 57);
            this.saveToFile.TabIndex = 17;
            this.saveToFile.Text = "Save To File";
            this.saveToFile.UseVisualStyleBackColor = true;
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
            // 
            // rmvFromLibBtn
            // 
            this.rmvFromLibBtn.Location = new System.Drawing.Point(1122, 1259);
            this.rmvFromLibBtn.Name = "rmvFromLibBtn";
            this.rmvFromLibBtn.Size = new System.Drawing.Size(482, 53);
            this.rmvFromLibBtn.TabIndex = 18;
            this.rmvFromLibBtn.Text = "Remove Selected From Library";
            this.rmvFromLibBtn.UseVisualStyleBackColor = true;
            this.rmvFromLibBtn.Click += new System.EventHandler(this.rmvFromLibBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1940, 1308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 32);
            this.label3.TabIndex = 19;
            this.label3.Text = "Matthew Biesen 2017";
            // 
            // libraryAddBtn
            // 
            this.libraryAddBtn.Location = new System.Drawing.Point(1144, 342);
            this.libraryAddBtn.Name = "libraryAddBtn";
            this.libraryAddBtn.Size = new System.Drawing.Size(514, 57);
            this.libraryAddBtn.TabIndex = 20;
            this.libraryAddBtn.Text = "Add Selected To Library";
            this.libraryAddBtn.UseVisualStyleBackColor = true;
            this.libraryAddBtn.Click += new System.EventHandler(this.libraryAddBtn_Click);
            // 
            // funcSearchBox
            // 
            this.funcSearchBox.Location = new System.Drawing.Point(560, 270);
            this.funcSearchBox.Name = "funcSearchBox";
            this.funcSearchBox.Size = new System.Drawing.Size(286, 38);
            this.funcSearchBox.TabIndex = 21;
            this.funcSearchBox.TextChanged += new System.EventHandler(this.funcSearchBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 32);
            this.label4.TabIndex = 22;
            this.label4.Text = "WholeFunction";
            // 
            // purpSearchBox
            // 
            this.purpSearchBox.Location = new System.Drawing.Point(78, 270);
            this.purpSearchBox.Name = "purpSearchBox";
            this.purpSearchBox.Size = new System.Drawing.Size(381, 38);
            this.purpSearchBox.TabIndex = 23;
            this.purpSearchBox.TextChanged += new System.EventHandler(this.purpSearchBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 32);
            this.label9.TabIndex = 24;
            this.label9.Text = "Purpose";
            // 
            // dbBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2240, 1349);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.purpSearchBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.funcSearchBox);
            this.Controls.Add(this.libraryAddBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rmvFromLibBtn);
            this.Controls.Add(this.saveToFile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.editFuncBtn);
            this.Controls.Add(this.mainMenuBtn);
            this.Controls.Add(this.functionBrowse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tagSearchBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.importSearchBox);
            this.Controls.Add(this.langSearchBox);
            this.Controls.Add(this.crntRevBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "dbBrowseForm";
            this.Text = "dbBrowseForm";
            this.Activated += new System.EventHandler(this.dbBrowseForm_Activated);
            this.Load += new System.EventHandler(this.dbBrowseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.functionBrowse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox crntRevBox;
        private System.Windows.Forms.TextBox langSearchBox;
        private System.Windows.Forms.TextBox importSearchBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tagSearchBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView functionBrowse;
        private System.Windows.Forms.Button mainMenuBtn;
        private System.Windows.Forms.Button editFuncBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button saveToFile;
        private System.Windows.Forms.Button rmvFromLibBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button libraryAddBtn;
        private System.Windows.Forms.TextBox funcSearchBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox purpSearchBox;
        private System.Windows.Forms.Label label9;
    }
}