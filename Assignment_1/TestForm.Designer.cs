namespace Assignment_1
{
    partial class TestForm
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
            this.Submit = new System.Windows.Forms.Button();
            this.Xml = new System.Windows.Forms.RadioButton();
            this.Json = new System.Windows.Forms.RadioButton();
            this.FileType = new System.Windows.Forms.GroupBox();
            this.browse = new System.Windows.Forms.Button();
            this.inputFilename = new System.Windows.Forms.TextBox();
            this.FileType.SuspendLayout();
            this.SuspendLayout();
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(120, 168);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(98, 39);
            this.Submit.TabIndex = 0;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // Xml
            // 
            this.Xml.AutoSize = true;
            this.Xml.Checked = true;
            this.Xml.Location = new System.Drawing.Point(29, 39);
            this.Xml.Name = "Xml";
            this.Xml.Size = new System.Drawing.Size(42, 17);
            this.Xml.TabIndex = 1;
            this.Xml.TabStop = true;
            this.Xml.Text = "Xml";
            this.Xml.UseVisualStyleBackColor = true;
            // 
            // Json
            // 
            this.Json.AutoSize = true;
            this.Json.Location = new System.Drawing.Point(105, 39);
            this.Json.Name = "Json";
            this.Json.Size = new System.Drawing.Size(47, 17);
            this.Json.TabIndex = 2;
            this.Json.TabStop = true;
            this.Json.Text = "Json";
            this.Json.UseVisualStyleBackColor = true;
            // 
            // FileType
            // 
            this.FileType.Controls.Add(this.Xml);
            this.FileType.Controls.Add(this.Json);
            this.FileType.Location = new System.Drawing.Point(77, 25);
            this.FileType.Name = "FileType";
            this.FileType.Size = new System.Drawing.Size(188, 76);
            this.FileType.TabIndex = 3;
            this.FileType.TabStop = false;
            this.FileType.Text = "File Type";
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(271, 124);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 4;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // inputFilename
            // 
            this.inputFilename.Location = new System.Drawing.Point(34, 126);
            this.inputFilename.Name = "inputFilename";
            this.inputFilename.Size = new System.Drawing.Size(231, 20);
            this.inputFilename.TabIndex = 5;
            this.inputFilename.Text = "XMLFileName";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 306);
            this.Controls.Add(this.inputFilename);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.FileType);
            this.Controls.Add(this.Submit);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.FileType.ResumeLayout(false);
            this.FileType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.RadioButton Xml;
        private System.Windows.Forms.RadioButton Json;
        private System.Windows.Forms.GroupBox FileType;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox inputFilename;
    }
}