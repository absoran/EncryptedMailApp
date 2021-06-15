using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using RSAEncDec;
using EncDec;

namespace EncryptedMailApp
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        public string[,] friends = new string[50, 4];
        RSACrypt RSAobj = RSACrypt.getInstance();
        EncryptedMailApp.LoginForm logformobj = new LoginForm();

        FirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8sXBXsTWSypjHv9Lfu2P8biITYexw4NIQ80sAmkH",
            BasePath = "https://encryptedmailapp-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient SendMailClient;

        private void button1_Click(object sender, EventArgs e)//sender
        {
            string appSign = "UrfaDiyarbakir";


            if (listBox1.SelectedIndex >= 0)
            {
                char[] charsToTrim = { ' ', '"' };
                int index = listBox1.SelectedIndex;
                var dateTime = DateTime.Now;
                string mailfrom = logformobj.getUsrName();
                string mailpass = logformobj.getUsrPass();
                try
                {
                    string encryptedAESkey = friends[index, 0].Trim(charsToTrim);
                    string decryptedAESkey = RSAobj.Decrypt(encryptedAESkey);
                    string mailTo = friends[index, 2].Trim(charsToTrim);
                    var post = new MailMessage(mailfrom, mailTo);
                    string MailSign =textBox1.Text + "\n" + dateTime;
                    string cryptedMailSign = RSAobj.SignData(MailSign);
                    post.Subject = AesCrypt.EncryptParam(textBox2.Text, decryptedAESkey);
                    post.Body = AesCrypt.Encrypt(appSign)+"---AppSign---" + AesCrypt.Encrypt(EncryptedMailApp.LoginForm.user) + "---Username---" + AesCrypt.EncryptParam(textBox1.Text + "\n" + dateTime, decryptedAESkey) + "---Body---" + cryptedMailSign + "---Sign---";
                    ;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(mailfrom, mailpass);
                        smtp.EnableSsl = true;
                        if(!string.IsNullOrEmpty(textBox3.Text))
                        {
                            Attachment data = new Attachment(textBox3.Text);
                            post.Attachments.Add(data);
                            smtp.Send(post);
                            MessageBox.Show("Email Sent With Attachment");
                        }
                        else
                        {
                            smtp.Send(post);
                            MessageBox.Show("Email Sent");
                        }
                    }
                

                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
                

            }
            else
            {
                MessageBox.Show("There is no selected friend!");
            }
        }

        private void SendMail_Load(object sender, EventArgs e)
        {
            SendMailClient = new FireSharp.FirebaseClient(config);

            string result;
            try
            {
                result = SendMailClient.Get(EncryptedMailApp.LoginForm.user + "/friends").Body.ToString();
                var mList = JsonConvert.DeserializeObject(result);
                object[] resultList = ((IEnumerable)mList).Cast<object>()
                             .Select(x => x)
                             .ToArray();

                foreach (var x in resultList)
                {
                    object[] items = ((IEnumerable)x).Cast<object>()
                             .Select(a => a)
                             .ToArray();


                    foreach (var y in items)
                    {
                        object[] props = ((IEnumerable)y).Cast<object>()
                                 .Select(a => a)
                                 .ToArray();

                        string[] request = new string[4];
                        foreach (var z in props)
                        {
                            string phrase = z.ToString();
                            string[] words = phrase.Split(new char[] { ':' }, 2);

                            for (int i = 0; i < request.Length; i++)
                            {
                                if (request[i] == null)
                                {
                                    request[i] = words[1];
                                    break;
                                }
                            }

                        }
                        char[] charsToTrim = { ' ', '"' };
                        for (int i = 0; i < friends.Length; i++)
                        {
                            if (friends[i, 0] == null)
                            {
                                friends[i, 0] = request[0]; //aes  
                                friends[i, 1] = request[1]; //username
                                friends[i, 2] = request[2]; //mail
                                friends[i, 3] = request[3]; //public
                                listBox1.Items.Add(new ListItem { Name = request[1].Trim(charsToTrim), Value = i.ToString() });
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dlg.FileName.ToString();
            }
        }
    }
}
