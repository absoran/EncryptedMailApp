namespace EncryptedMailApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.mailFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mailTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelPath = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CryptKey = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.CryptIV = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.testbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.testbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Mail";
            // 
            // mailFrom
            // 
            this.mailFrom.Location = new System.Drawing.Point(28, 41);
            this.mailFrom.Margin = new System.Windows.Forms.Padding(2);
            this.mailFrom.Name = "mailFrom";
            this.mailFrom.Size = new System.Drawing.Size(188, 20);
            this.mailFrom.TabIndex = 1;
            this.mailFrom.TextChanged += new System.EventHandler(this.mailFrom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 426);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(32, 328);
            this.message.Margin = new System.Windows.Forms.Padding(2);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(188, 96);
            this.message.TabIndex = 5;
            this.message.TextChanged += new System.EventHandler(this.message_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 312);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(28, 173);
            this.subject.Margin = new System.Windows.Forms.Padding(2);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(188, 20);
            this.subject.TabIndex = 7;
            this.subject.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subject";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // mailTo
            // 
            this.mailTo.Location = new System.Drawing.Point(28, 128);
            this.mailTo.Margin = new System.Windows.Forms.Padding(2);
            this.mailTo.Name = "mailTo";
            this.mailTo.Size = new System.Drawing.Size(188, 20);
            this.mailTo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Send Mail Adress";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(28, 84);
            this.password.Margin = new System.Windows.Forms.Padding(2);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(188, 20);
            this.password.TabIndex = 11;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Password";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(57, 426);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Dosya Seç";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(120, 426);
            this.labelPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(52, 13);
            this.labelPath.TabIndex = 13;
            this.labelPath.Text = "dosyaismi";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 444);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 40);
            this.button1.TabIndex = 14;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Key (32 Character)";
            // 
            // CryptKey
            // 
            this.CryptKey.Location = new System.Drawing.Point(29, 216);
            this.CryptKey.Name = "CryptKey";
            this.CryptKey.Size = new System.Drawing.Size(187, 20);
            this.CryptKey.TabIndex = 16;
            this.CryptKey.TextChanged += new System.EventHandler(this.CryptKey_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Change";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CryptIV
            // 
            this.CryptIV.Location = new System.Drawing.Point(28, 261);
            this.CryptIV.Name = "CryptIV";
            this.CryptIV.Size = new System.Drawing.Size(188, 20);
            this.CryptIV.TabIndex = 18;
            this.CryptIV.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "IV (16 Character)";
            // 
            // testbox
            // 
            this.testbox.Location = new System.Drawing.Point(264, 40);
            this.testbox.Name = "testbox";
            this.testbox.Size = new System.Drawing.Size(160, 20);
            this.testbox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "test";
            // 
            // testbtn
            // 
            this.testbtn.Location = new System.Drawing.Point(310, 68);
            this.testbtn.Name = "testbtn";
            this.testbtn.Size = new System.Drawing.Size(75, 23);
            this.testbtn.TabIndex = 22;
            this.testbtn.Text = "test";
            this.testbtn.UseVisualStyleBackColor = true;
            this.testbtn.Click += new System.EventHandler(this.testbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 491);
            this.Controls.Add(this.testbtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.testbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CryptIV);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CryptKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mailTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mailFrom);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encrypted Mail App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mailFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mailTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CryptKey;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox CryptIV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox testbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button testbtn;
    }
}

