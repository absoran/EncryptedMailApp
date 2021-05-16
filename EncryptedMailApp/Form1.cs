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
using System.Threading;
using System.Security.Authentication;
using RSAEncDec;
using S22.Imap;


namespace EncryptedMailApp
{
    public partial class Form1 : Form
    {
        static Form1 p;
        RSACrypt RSAobj = RSACrypt.getInstance();

        public Form1()
        {
            InitializeComponent();
            p = this;
        }


        private void GetMail()
        {
            try {
                Task.Run(() =>
                {
                    using (ImapClient client = new ImapClient("imap.gmail.com", 993, mailFrom.Text, password.Text, AuthMethod.Login, true))
                    {
                        if (client.Supports("IDLE") == false)
                        {
                            MessageBox.Show("Server do not support IMAP IDLE");
                            return;
                        }
                        client.NewMessage += new EventHandler<IdleMessageEventArgs>(OnNewMessage);
                        while (true) ;
                    }
                });
            }
            catch (InvalidCredentialsException)
            {
                MessageBox.Show("The server rejected the supplied credentials.");
            }
            }

        static void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            MessageBox.Show(" New Message received ");
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
            p.Invoke((MethodInvoker)delegate
            {
                p.richTextBox1.AppendText("From :" + m.From + "\n" +
                                        "Subject : " + m.Subject + "\n" +
                                        "Message : " + m.Body + "\n");
            });
        }
        private void SendMail()
        {
            try
            {
                string cryptedmsg = AesCrypt.Encrypt(message.Text);
                var messag = new MailMessage(mailFrom.Text, mailTo.Text);
                messag.Subject = subject.Text;
                messag.Body = cryptedmsg;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(mailFrom.Text, password.Text);
                    smtp.EnableSsl = true;
                    smtp.Send(messag);
                    MessageBox.Show("Email Sent");
                }
            }
            catch
            {

                MessageBox.Show("Please check your mail address and password.");

            }

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

        private void button1_Click(object sender, EventArgs e) //mails sender
        {
            SendMail();
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

        /*private void button2_Click(object sender, EventArgs e)
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
        }*/

        private void button2_Click(object sender, EventArgs e)
        {

            string TakenKey = CryptKey.Text;
            string TakenIV = CryptIV.Text;

            if (TakenKey.Length != 32 && TakenIV.Length != 16)
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

        private void testbtn_Click(object sender, EventArgs e)//encrypt
        {
            //RSACrypt rsaobj = RSACrypt.getInstance();
            //string encrtypted = rsaobj.Encrypt(testbox.Text);
            string encrtypted = RSAobj.Encrypt(testbox.Text);
            testtextbox.Text = encrtypted;
        }
        private void button4_Click(object sender, EventArgs e)//decrypt
        {
            //RSACrypt rsaobj = RSACrypt.getInstance();
            //string decrypted = rsaobj.Decrypt(testtextbox.Text);
            string decrypted = RSAobj.Decrypt(testtextbox.Text);
            testtextbox.Text = decrypted;  
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetMail();
        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void testbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string KeyPublic = keybox.Text;
            RSAobj.PublicKey = KeyPublic;
            MessageBox.Show("Public Key Changed");
        }
    }
}
