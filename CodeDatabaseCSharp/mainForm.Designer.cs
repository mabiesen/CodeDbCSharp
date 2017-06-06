namespace CodeDatabaseCSharp
{
    partial class mainForm
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
            this.titleMainForm = new System.Windows.Forms.Label();
            this.indFuncBtn = new System.Windows.Forms.Button();
            this.fileFuncBtn = new System.Windows.Forms.Button();
            this.editLibBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.brsDbBtn = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleMainForm
            // 
            this.titleMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleMainForm.Location = new System.Drawing.Point(113, 41);
            this.titleMainForm.Name = "titleMainForm";
            this.titleMainForm.Size = new System.Drawing.Size(1297, 156);
            this.titleMainForm.TabIndex = 0;
            this.titleMainForm.Text = "Code Database";
            this.titleMainForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // indFuncBtn
            // 
            this.indFuncBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.indFuncBtn.Location = new System.Drawing.Point(113, 246);
            this.indFuncBtn.Name = "indFuncBtn";
            this.indFuncBtn.Size = new System.Drawing.Size(334, 133);
            this.indFuncBtn.TabIndex = 1;
            this.indFuncBtn.Text = "Add Individual Function";
            this.indFuncBtn.UseVisualStyleBackColor = true;
            this.indFuncBtn.Click += new System.EventHandler(this.indFuncBtn_Click);
            this.indFuncBtn.MouseHover += new System.EventHandler(this.indFuncBtn_MouseHover);
            // 
            // fileFuncBtn
            // 
            this.fileFuncBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fileFuncBtn.Location = new System.Drawing.Point(506, 246);
            this.fileFuncBtn.Name = "fileFuncBtn";
            this.fileFuncBtn.Size = new System.Drawing.Size(334, 133);
            this.fileFuncBtn.TabIndex = 2;
            this.fileFuncBtn.Text = "Add Functions From File";
            this.fileFuncBtn.UseVisualStyleBackColor = true;
            this.fileFuncBtn.Click += new System.EventHandler(this.fileFuncBtn_Click);
            this.fileFuncBtn.MouseHover += new System.EventHandler(this.fileFuncBtn_MouseHover);
            // 
            // editLibBtn
            // 
            this.editLibBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.editLibBtn.Location = new System.Drawing.Point(506, 423);
            this.editLibBtn.Name = "editLibBtn";
            this.editLibBtn.Size = new System.Drawing.Size(334, 123);
            this.editLibBtn.TabIndex = 5;
            this.editLibBtn.Text = "Browse Library";
            this.editLibBtn.UseVisualStyleBackColor = true;
            this.editLibBtn.Click += new System.EventHandler(this.editLibBtn_Click);
            this.editLibBtn.MouseHover += new System.EventHandler(this.editLibBtn_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1122, 771);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Matthew Biesen 2017";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(900, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "On Hover Information";
            // 
            // brsDbBtn
            // 
            this.brsDbBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.brsDbBtn.Location = new System.Drawing.Point(113, 421);
            this.brsDbBtn.Name = "brsDbBtn";
            this.brsDbBtn.Size = new System.Drawing.Size(334, 125);
            this.brsDbBtn.TabIndex = 11;
            this.brsDbBtn.Text = "Browse Database";
            this.brsDbBtn.UseVisualStyleBackColor = true;
            this.brsDbBtn.Click += new System.EventHandler(this.brsDbBtn_Click_1);
            this.brsDbBtn.MouseHover += new System.EventHandler(this.brsDbBtn_MouseHover);
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(906, 277);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(487, 443);
            this.infoBox.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(113, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(334, 125);
            this.button1.TabIndex = 13;
            this.button1.Text = "Help and Information";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 840);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.brsDbBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editLibBtn);
            this.Controls.Add(this.fileFuncBtn);
            this.Controls.Add(this.indFuncBtn);
            this.Controls.Add(this.titleMainForm);
            this.Name = "mainForm";
            this.Text = "Welcome to Code Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleMainForm;
        private System.Windows.Forms.Button indFuncBtn;
        private System.Windows.Forms.Button fileFuncBtn;
        private System.Windows.Forms.Button editLibBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button brsDbBtn;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

