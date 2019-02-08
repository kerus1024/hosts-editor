namespace hosteditor
{
    partial class editForm
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
            this.inputIP = new System.Windows.Forms.TextBox();
            this.inputDomains = new System.Windows.Forms.TextBox();
            this.buttonDo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Domains";
            // 
            // inputIP
            // 
            this.inputIP.Location = new System.Drawing.Point(77, 10);
            this.inputIP.Name = "inputIP";
            this.inputIP.Size = new System.Drawing.Size(198, 20);
            this.inputIP.TabIndex = 1;
            this.inputIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // inputDomains
            // 
            this.inputDomains.Location = new System.Drawing.Point(77, 40);
            this.inputDomains.Name = "inputDomains";
            this.inputDomains.Size = new System.Drawing.Size(198, 20);
            this.inputDomains.TabIndex = 2;
            this.inputDomains.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputDomain_keyDown);
            // 
            // buttonDo
            // 
            this.buttonDo.Location = new System.Drawing.Point(236, 66);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(39, 28);
            this.buttonDo.TabIndex = 3;
            this.buttonDo.Text = "OK";
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Click += new System.EventHandler(this.ButtonDo_click);
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 102);
            this.Controls.Add(this.buttonDo);
            this.Controls.Add(this.inputDomains);
            this.Controls.Add(this.inputIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "editForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "editForm";
            this.Load += new System.EventHandler(this.editForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputIP;
        private System.Windows.Forms.TextBox inputDomains;
        private System.Windows.Forms.Button buttonDo;
    }
}