namespace CodeDatabaseCSharp
{
    partial class fileAttributesModalForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.fldrSelectBtn = new System.Windows.Forms.Button();
            this.fldSelectBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.langListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(118, 634);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(201, 65);
            this.submitBtn.TabIndex = 0;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(839, 631);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(208, 68);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // fldrSelectBtn
            // 
            this.fldrSelectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fldrSelectBtn.Location = new System.Drawing.Point(118, 197);
            this.fldrSelectBtn.Name = "fldrSelectBtn";
            this.fldrSelectBtn.Size = new System.Drawing.Size(321, 75);
            this.fldrSelectBtn.TabIndex = 2;
            this.fldrSelectBtn.Text = "Select Folder";
            this.fldrSelectBtn.UseVisualStyleBackColor = true;
            this.fldrSelectBtn.Click += new System.EventHandler(this.fldrSelectBtn_Click);
            // 
            // fldSelectBox
            // 
            this.fldSelectBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fldSelectBox.Location = new System.Drawing.Point(557, 219);
            this.fldSelectBox.Name = "fldSelectBox";
            this.fldSelectBox.ReadOnly = true;
            this.fldSelectBox.Size = new System.Drawing.Size(490, 53);
            this.fldSelectBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "Language for File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = "File Name (no ext)";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameBox.Location = new System.Drawing.Point(557, 315);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(490, 53);
            this.fileNameBox.TabIndex = 7;
            // 
            // langListBox
            // 
            this.langListBox.FormattingEnabled = true;
            this.langListBox.ItemHeight = 31;
            this.langListBox.Location = new System.Drawing.Point(557, 419);
            this.langListBox.Name = "langListBox";
            this.langListBox.Size = new System.Drawing.Size(490, 159);
            this.langListBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(695, 63);
            this.label3.TabIndex = 9;
            this.label3.Text = "Set Attributes and Save File";
            // 
            // fileAttributesModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 756);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.langListBox);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fldSelectBox);
            this.Controls.Add(this.fldrSelectBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Name = "fileAttributesModalForm";
            this.Text = "fileAttributesModalForm";
            this.Load += new System.EventHandler(this.fileAttributesModalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button fldrSelectBtn;
        private System.Windows.Forms.TextBox fldSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.ListBox langListBox;
        private System.Windows.Forms.Label label3;
    }
}