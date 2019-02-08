namespace WindowsFormsApp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.openPath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.loadedHosts = new System.Windows.Forms.ListView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAddHost = new System.Windows.Forms.Button();
            this.buttonShowCompare = new System.Windows.Forms.Button();
            this.buttonDeleteHost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // openPath
            // 
            this.openPath.AcceptsReturn = true;
            this.openPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.openPath.Location = new System.Drawing.Point(62, 16);
            this.openPath.Name = "openPath";
            this.openPath.ReadOnly = true;
            this.openPath.Size = new System.Drawing.Size(315, 20);
            this.openPath.TabIndex = 1;
            this.openPath.Text = "C:\\WINDOWS\\SYSTEM32\\DRIVERS\\ETC\\HOSTS";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(383, 14);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(37, 26);
            this.btnSelectPath.TabIndex = 2;
            this.btnSelectPath.TabStop = false;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(426, 14);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(64, 26);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.TabStop = false;
            this.btnOpenFile.Text = "LOAD";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // loadedHosts
            // 
            this.loadedHosts.FullRowSelect = true;
            this.loadedHosts.GridLines = true;
            this.loadedHosts.LabelWrap = false;
            this.loadedHosts.Location = new System.Drawing.Point(12, 57);
            this.loadedHosts.MultiSelect = false;
            this.loadedHosts.Name = "loadedHosts";
            this.loadedHosts.ShowGroups = false;
            this.loadedHosts.Size = new System.Drawing.Size(478, 281);
            this.loadedHosts.TabIndex = 5;
            this.loadedHosts.UseCompatibleStateImageBehavior = false;
            this.loadedHosts.View = System.Windows.Forms.View.Details;
            this.loadedHosts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.loadedHosts_MouseDoubleClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(426, 14);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(64, 26);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAddHost
            // 
            this.buttonAddHost.Location = new System.Drawing.Point(398, 346);
            this.buttonAddHost.Name = "buttonAddHost";
            this.buttonAddHost.Size = new System.Drawing.Size(92, 30);
            this.buttonAddHost.TabIndex = 6;
            this.buttonAddHost.Text = "Add";
            this.buttonAddHost.UseVisualStyleBackColor = true;
            this.buttonAddHost.Click += new System.EventHandler(this.buttonAddHost_Click);
            // 
            // buttonShowCompare
            // 
            this.buttonShowCompare.Location = new System.Drawing.Point(202, 346);
            this.buttonShowCompare.Name = "buttonShowCompare";
            this.buttonShowCompare.Size = new System.Drawing.Size(92, 30);
            this.buttonShowCompare.TabIndex = 6;
            this.buttonShowCompare.TabStop = false;
            this.buttonShowCompare.Text = "Compare A->B";
            this.buttonShowCompare.UseVisualStyleBackColor = true;
            this.buttonShowCompare.Click += new System.EventHandler(this.buttonShowCompare_Click);
            // 
            // buttonDeleteHost
            // 
            this.buttonDeleteHost.Location = new System.Drawing.Point(300, 346);
            this.buttonDeleteHost.Name = "buttonDeleteHost";
            this.buttonDeleteHost.Size = new System.Drawing.Size(92, 30);
            this.buttonDeleteHost.TabIndex = 6;
            this.buttonDeleteHost.TabStop = false;
            this.buttonDeleteHost.Text = "Delete";
            this.buttonDeleteHost.UseVisualStyleBackColor = true;
            this.buttonDeleteHost.Click += new System.EventHandler(this.buttonDeleteHost_Click_1);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 384);
            this.Controls.Add(this.buttonShowCompare);
            this.Controls.Add(this.buttonDeleteHost);
            this.Controls.Add(this.buttonAddHost);
            this.Controls.Add(this.loadedHosts);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.openPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox openPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ListView loadedHosts;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddHost;
        private System.Windows.Forms.Button buttonShowCompare;
        private System.Windows.Forms.Button buttonDeleteHost;
    }
}