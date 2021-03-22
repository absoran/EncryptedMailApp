
namespace EncryptedMailApp
{
    partial class Register
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
            this.usrpass = new System.Windows.Forms.TextBox();
            this.registerbtn = new System.Windows.Forms.Button();
            this.usrname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // usrpass
            // 
            this.usrpass.Location = new System.Drawing.Point(86, 60);
            this.usrpass.Name = "usrpass";
            this.usrpass.Size = new System.Drawing.Size(100, 20);
            this.usrpass.TabIndex = 3;
            // 
            // registerbtn
            // 
            this.registerbtn.Location = new System.Drawing.Point(86, 100);
            this.registerbtn.Name = "registerbtn";
            this.registerbtn.Size = new System.Drawing.Size(75, 23);
            this.registerbtn.TabIndex = 4;
            this.registerbtn.Text = "Register";
            this.registerbtn.UseVisualStyleBackColor = true;
            this.registerbtn.Click += new System.EventHandler(this.registerbtn_Click);
            // 
            // usrname
            // 
            this.usrname.Location = new System.Drawing.Point(86, 22);
            this.usrname.Name = "usrname";
            this.usrname.Size = new System.Drawing.Size(100, 20);
            this.usrname.TabIndex = 5;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 151);
            this.Controls.Add(this.usrname);
            this.Controls.Add(this.registerbtn);
            this.Controls.Add(this.usrpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usrpass;
        private System.Windows.Forms.Button registerbtn;
        private System.Windows.Forms.TextBox usrname;
    }
}