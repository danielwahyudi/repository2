namespace XMLProcessWinForm
{
    partial class Form1
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
            this.btnSelectXMLSource = new System.Windows.Forms.Button();
            this.lblXMLSource = new System.Windows.Forms.Label();
            this.lblXMLNumFiles = new System.Windows.Forms.Label();
            this.btnSelectOutputFolder = new System.Windows.Forms.Button();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectXMLSource
            // 
            this.btnSelectXMLSource.Location = new System.Drawing.Point(13, 13);
            this.btnSelectXMLSource.Name = "btnSelectXMLSource";
            this.btnSelectXMLSource.Size = new System.Drawing.Size(117, 23);
            this.btnSelectXMLSource.TabIndex = 0;
            this.btnSelectXMLSource.Text = "Select XML Folder";
            this.btnSelectXMLSource.UseVisualStyleBackColor = true;
            this.btnSelectXMLSource.Click += new System.EventHandler(this.btnSelectXMLSource_Click);
            // 
            // lblXMLSource
            // 
            this.lblXMLSource.AutoSize = true;
            this.lblXMLSource.Location = new System.Drawing.Point(162, 18);
            this.lblXMLSource.Name = "lblXMLSource";
            this.lblXMLSource.Size = new System.Drawing.Size(67, 13);
            this.lblXMLSource.TabIndex = 1;
            this.lblXMLSource.Text = "Not selected";
            // 
            // lblXMLNumFiles
            // 
            this.lblXMLNumFiles.AutoSize = true;
            this.lblXMLNumFiles.Location = new System.Drawing.Point(162, 42);
            this.lblXMLNumFiles.Name = "lblXMLNumFiles";
            this.lblXMLNumFiles.Size = new System.Drawing.Size(0, 13);
            this.lblXMLNumFiles.TabIndex = 2;
            // 
            // btnSelectOutputFolder
            // 
            this.btnSelectOutputFolder.Enabled = false;
            this.btnSelectOutputFolder.Location = new System.Drawing.Point(13, 57);
            this.btnSelectOutputFolder.Name = "btnSelectOutputFolder";
            this.btnSelectOutputFolder.Size = new System.Drawing.Size(117, 23);
            this.btnSelectOutputFolder.TabIndex = 3;
            this.btnSelectOutputFolder.Text = "Select Output Folder";
            this.btnSelectOutputFolder.UseVisualStyleBackColor = true;
            this.btnSelectOutputFolder.Click += new System.EventHandler(this.btnSelectOutputFolder_Click);
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(162, 62);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(67, 13);
            this.lblOutputFolder.TabIndex = 4;
            this.lblOutputFolder.Text = "Not selected";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(13, 102);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(117, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(13, 131);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(447, 144);
            this.tbOutput.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 291);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.btnSelectOutputFolder);
            this.Controls.Add(this.lblXMLNumFiles);
            this.Controls.Add(this.lblXMLSource);
            this.Controls.Add(this.btnSelectXMLSource);
            this.Name = "Form1";
            this.Text = "XML Process";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectXMLSource;
        private System.Windows.Forms.Label lblXMLSource;
        private System.Windows.Forms.Label lblXMLNumFiles;
        private System.Windows.Forms.Button btnSelectOutputFolder;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbOutput;
    }
}

