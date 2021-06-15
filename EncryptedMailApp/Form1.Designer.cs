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
            this.message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.testbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.testbtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.testbtn2 = new System.Windows.Forms.Button();
            this.testtextbox = new System.Windows.Forms.TextBox();
            this.keybox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            this.mailTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CryptKey = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.CryptIV = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(858, 10);
            this.message.Margin = new System.Windows.Forms.Padding(2);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.message.Size = new System.Drawing.Size(188, 96);
            this.message.TabIndex = 5;
            this.message.TextChanged += new System.EventHandler(this.message_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(860, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gelen Kutusu";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(902, 346);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testbox
            // 
            this.testbox.Location = new System.Drawing.Point(886, 454);
            this.testbox.Name = "testbox";
            this.testbox.Size = new System.Drawing.Size(160, 20);
            this.testbox.TabIndex = 20;
            this.testbox.TextChanged += new System.EventHandler(this.testbox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1100, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Public Key";
            // 
            // testbtn
            // 
            this.testbtn.Location = new System.Drawing.Point(886, 480);
            this.testbtn.Name = "testbtn";
            this.testbtn.Size = new System.Drawing.Size(75, 23);
            this.testbtn.TabIndex = 22;
            this.testbtn.Text = "encrypt";
            this.testbtn.UseVisualStyleBackColor = true;
            this.testbtn.Click += new System.EventHandler(this.testbtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 582);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Gelen Kutusunu Getir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // testbtn2
            // 
            this.testbtn2.Location = new System.Drawing.Point(971, 480);
            this.testbtn2.Name = "testbtn2";
            this.testbtn2.Size = new System.Drawing.Size(75, 23);
            this.testbtn2.TabIndex = 26;
            this.testbtn2.Text = "decrypt";
            this.testbtn2.UseVisualStyleBackColor = true;
            this.testbtn2.Click += new System.EventHandler(this.button4_Click);
            // 
            // testtextbox
            // 
            this.testtextbox.Location = new System.Drawing.Point(886, 541);
            this.testtextbox.Multiline = true;
            this.testtextbox.Name = "testtextbox";
            this.testtextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.testtextbox.Size = new System.Drawing.Size(160, 53);
            this.testtextbox.TabIndex = 27;
            this.testtextbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // keybox
            // 
            this.keybox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keybox.Location = new System.Drawing.Point(1085, 28);
            this.keybox.Multiline = true;
            this.keybox.Name = "keybox";
            this.keybox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keybox.Size = new System.Drawing.Size(178, 194);
            this.keybox.TabIndex = 28;
            this.keybox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_2);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1083, 228);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 23);
            this.button4.TabIndex = 29;
            this.button4.Text = "Change Key";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(861, 403);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Encryption (AES)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1006, 369);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(69, 17);
            this.checkBox2.TabIndex = 33;
            this.checkBox2.Text = "Add Sign";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1181, 539);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 23);
            this.button5.TabIndex = 35;
            this.button5.Text = "Verify";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1085, 424);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(178, 96);
            this.textBox1.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1085, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Enter Sign For Verify";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1165, 228);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 38;
            this.button6.Text = "My Public Key";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1088, 306);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(178, 20);
            this.textBox2.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1087, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Enter User Name";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1085, 539);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 41;
            this.button7.Text = "sign";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1135, 332);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 28);
            this.button8.TabIndex = 42;
            this.button8.Text = "Find PubKey";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(848, 485);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "RSA";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(886, 509);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 44;
            this.button9.Text = "Encrypt";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(971, 509);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 45;
            this.button10.Text = "Decrypt";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(848, 514);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "AES";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(649, 91);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(142, 51);
            this.button11.TabIndex = 47;
            this.button11.Text = "Arkadaş Ekle";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(649, 32);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(142, 51);
            this.button12.TabIndex = 48;
            this.button12.Text = "Yeni İleti";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(649, 149);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(142, 51);
            this.button13.TabIndex = 49;
            this.button13.Text = "Arkadaşlık İstekleri";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click_1);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(915, 275);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(142, 51);
            this.button14.TabIndex = 51;
            this.button14.Text = "Dosya Ekle";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(916, 219);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(141, 20);
            this.textBox3.TabIndex = 52;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(943, 600);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 53;
            this.button15.Text = "test";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(973, 399);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 54;
            this.button16.Text = "file enc";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(973, 429);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 55;
            this.button17.Text = "file dec";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(916, 246);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(141, 20);
            this.textBox4.TabIndex = 56;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(621, 550);
            this.listBox1.TabIndex = 57;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(856, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subject";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(858, 70);
            this.subject.Margin = new System.Windows.Forms.Padding(2);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(188, 20);
            this.subject.TabIndex = 7;
            this.subject.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // mailTo
            // 
            this.mailTo.Location = new System.Drawing.Point(858, 25);
            this.mailTo.Margin = new System.Windows.Forms.Padding(2);
            this.mailTo.Name = "mailTo";
            this.mailTo.Size = new System.Drawing.Size(188, 20);
            this.mailTo.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(858, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Key (32 Character)";
            // 
            // CryptKey
            // 
            this.CryptKey.Location = new System.Drawing.Point(859, 113);
            this.CryptKey.Name = "CryptKey";
            this.CryptKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CryptKey.Size = new System.Drawing.Size(187, 20);
            this.CryptKey.TabIndex = 16;
            this.CryptKey.TextChanged += new System.EventHandler(this.CryptKey_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(915, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Change";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CryptIV
            // 
            this.CryptIV.Location = new System.Drawing.Point(858, 158);
            this.CryptIV.Name = "CryptIV";
            this.CryptIV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CryptIV.Size = new System.Drawing.Size(188, 20);
            this.CryptIV.TabIndex = 18;
            this.CryptIV.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(859, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "IV (16 Character)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(858, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "To:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 614);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.keybox);
            this.Controls.Add(this.testtextbox);
            this.Controls.Add(this.testbtn2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.testbtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.testbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CryptIV);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CryptKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mailTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encrypted Mail App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox testbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button testbtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button testbtn2;
        private System.Windows.Forms.TextBox testtextbox;
        private System.Windows.Forms.TextBox keybox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.TextBox mailTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CryptKey;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox CryptIV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
    }
}

