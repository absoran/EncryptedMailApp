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
using MailKit.Net.Pop3;
using System.Security.Authentication;
//using AE.Net.Mail;

namespace EncryptedMailApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        public void GetMails()
        {

            using (var client = new Pop3Client())
            {

                try
                {

                    var Server = "pop.gmail.com";
                    var Port = 995;
                    var UseSsl = false;
                    var credentials = new NetworkCredential(mailFrom.Text, password.Text);
                    var cancel = new CancellationTokenSource();
                    var uri = new Uri(string.Format("pop{0}://{1}:{2}", (UseSsl ? "s" : ""), Server, Port));

                    //Connect to email server
                    client.Connect(uri, cancel.Token);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(credentials, cancel.Token);

                    //Fetch Emails
                    for (int i = 0; i < client.Count; i++)
                    {
                        var message = client.GetMessage(i);

                        MessageBox.Show("Subject: {0}", message.Subject);
                    }

                    //Disconnect Connection
                    client.Disconnect(true);


                }
                /*catch
                {
                    MessageBox.Show("Please check your mail address and password.");
                }*/
                catch(Pop3ProtocolException ex)
                {
                    MessageBox.Show("Protocol error while trying to connect: {0}", ex.Message);
                    return;
                }

                try
                {
                    client.Authenticate(mailFrom.Text, password.Text);
                }
                catch (AuthenticationException ex)
                {
                    MessageBox.Show("Invalid user name or password.");
                    return;
                }
                catch (Pop3CommandException ex)
                {
                    MessageBox.Show("Error trying to authenticate: {0}", ex.Message);
                    MessageBox.Show("\tStatusText: {0}", ex.StatusText);
                    return;
                }
                catch (Pop3ProtocolException ex)
                {
                    MessageBox.Show("Protocol error while trying to authenticate: {0}", ex.Message);
                    return;
                }
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
                


                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(mailFrom.Text, password.Text),

                   // Credentials = new NetworkCredential(mailFrom.Text, password.Text),
                    EnableSsl = true,
                };
                smtp.Send(mailFrom.Text, mailTo.Text, subject.Text, cryptedmsg);

                
                MessageBox.Show("Email Sent");

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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetMails();
        }
    }
}
