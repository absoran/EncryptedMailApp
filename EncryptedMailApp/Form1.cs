using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using EncDec;
using System.IO;

namespace EncryptedMailApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(mailFrom.Text, "gethealthtip");
                mailMessage.To.Add(new MailAddress(mailTo.Text));
                mailMessage.Subject = subject.Text;
                string cryptedmsg = AesCrypt.Encrypt(message.Text);
                mailMessage.Body = cryptedmsg;
                mailMessage.IsBodyHtml = true;
               /* if (labelPath.Text.Length > 0)
                {
                    if (System.IO.File.Exists(labelPath.Text))
                    {
                        mailMessage.Attachments.Add(new Attachment(labelPath.Text));

                    }
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Credentials = new NetworkCredential(mailFrom.Text,password.Text);
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    MessageBox.Show("Email Sent");

                }*/
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(mailFrom.Text, password.Text),

                   // Credentials = new NetworkCredential(mailFrom.Text, password.Text),
                    EnableSsl = true,
                };
                smtp.Send(mailFrom.Text, mailTo.Text, subject.Text, message.Text);

                
                MessageBox.Show("Email Sent");

            }
            catch 
            {

                MessageBox.Show("Please check your mail address and password.");

            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mailFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void message_TextChanged(object sender, EventArgs e)
        {

        }

        private void CryptKey_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string TakenKey = CryptKey.Text;
            string TakenIV = CryptIV.Text;

            if (TakenKey.Length != 32 && TakenIV.Length !=16)
            {
                MessageBox.Show("Invalid key entry. Key must be 32 character");
            }
            else
            {
                AesCrypt.setKey(TakenKey);
                AesCrypt.setIV(TakenIV);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void testbtn_Click(object sender, EventArgs e)
        {
            string cryptedteststring = AesCrypt.Encrypt(testbox.Text);
            MessageBox.Show(cryptedteststring);
        }
    }
}
