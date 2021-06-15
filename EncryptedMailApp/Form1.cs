using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using EncDec;
using System.IO;
using RSAEncDec;
using S22.Imap;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;

namespace EncryptedMailApp
{
    public partial class Form1 : Form
    {
        public event EventHandler DoubleClick;

        static Form1 p;
        RSACrypt RSAobj = RSACrypt.getInstance();
        EncryptedMailApp.LoginForm logform = new LoginForm();
        public static bool signed = false;
        string password = "rastgelebirstring";
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8sXBXsTWSypjHv9Lfu2P8biITYexw4NIQ80sAmkH",
            BasePath= "https://encryptedmailapp-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient FbClient;

        public string[,] messages = new string[50, 4];

        public Form1()
        {
            InitializeComponent();
            p = this;
        }


        private void GetMail()
        {
            string mailfrom = logform.getUsrName();
            string mailpass = logform.getUsrPass();

            try {
                Task.Run(() =>
                {
                    using (ImapClient client = new ImapClient("imap.gmail.com", 993, mailfrom, mailpass, AuthMethod.Login, true))
                    {
                        if (client.Supports("IDLE") == false)
                        {
                            MessageBox.Show("Server do not support IMAP IDLE");
                            return;
                        }
                        string cryptedAppSign=AesCrypt.Encrypt("UrfaDiyarbakir");

                        var uids = client.Search(SearchCondition.Text(cryptedAppSign));
                        int index = 0;


                        foreach (var id in uids)
                        {
                           
                            var m = client.GetMessage(id, FetchOptions.Normal);


                            int a = m.Body.IndexOf("---AppSign---") + "---AppSign---".Length;
                            int b = m.Body.IndexOf("---Username---");

                            int c = m.Body.IndexOf("---Username---") + "---Username---".Length;
                            int d = m.Body.IndexOf("---Body---");

                            int e = m.Body.IndexOf("---Body---") + "---Body---".Length;
                            int f = m.Body.IndexOf("---Sign---");

                            string appsign = m.Body.Substring(0, m.Body.IndexOf("---AppSign---"));
                            string Username = AesCrypt.Decrypt(m.Body.Substring(a, b - a));
                            string sign = m.Body.Substring(e, f - e);
                            string encryptedBody = m.Body.Substring(c, d - c);
                            string dir = EncryptedMailApp.LoginForm.user;


                            char[] charsToTrim = { ' ', '"' };
                            string encryptedAES = FbClient.Get(EncryptedMailApp.LoginForm.user + "/friends/" + Username + "/aes").Body.ToString().Trim(charsToTrim);
                            string friendPublic = FbClient.Get(EncryptedMailApp.LoginForm.user + "/friends/" + Username + "/publicKey").Body.ToString().Trim(charsToTrim);
                            string aes;
                            string decryptedBody;
                            string decryptedSubject;
                            try
                            {
                                string decryptetaes = RSAobj.Decrypt(encryptedAES);
                                aes = decryptetaes;
                            }
                            catch
                            {
                                aes = null;
                                Console.WriteLine("error on decrypting aes ");
                            }
                            try
                            {
                                decryptedBody = AesCrypt.DecryptParam(encryptedBody, aes);
                            }
                            catch
                            {
                                decryptedBody = null;
                                Console.WriteLine("error on decrpting body");
                            }
                            try
                            {
                                decryptedSubject = AesCrypt.DecryptParam(m.Subject, aes);
                            }
                            catch
                            {
                                decryptedSubject = null;
                                Console.WriteLine("error on decrpting subject");
                            }
                            if(RSAobj.VerifySign(decryptedBody, sign, friendPublic) == true)
                            {
                                Console.WriteLine("match");
                                signed = true;
                            }
                            else
                            {
                                Console.WriteLine("missmatch");
                                signed = false;
                            }

                            if (messages[index, 0] == null)
                                {
                                    messages[index, 0] = Username; 
                                    messages[index, 1] = decryptedSubject; 
                                    messages[index, 2] = decryptedBody; 
                               }
                                                        
                            listBox1.Items.Add(new ListItem { Name = "From:   "+ Username + "   Subject:   "+ decryptedSubject, Value = index.ToString() });
                            
                            index++;
                            
                            foreach(Attachment attachment in m.Attachments)
                            {
                                byte[] allBytes = new byte[attachment.ContentStream.Length];
                                int bytesread = attachment.ContentStream.Read(allBytes, 0, (int)attachment.ContentStream.Length);
                                if (System.IO.Directory.Exists("data\\" + dir + "\\attachments") == false)
                                {
                                    System.IO.Directory.CreateDirectory("data\\" + dir + "\\attachments");
                                }
                                string destinationFile = "data\\" + dir + "\\attachments\\" + attachment.Name;
                                BinaryWriter writer = new BinaryWriter(new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
                                writer.Write(allBytes);
                                writer.Close();
                                if (attachment.Name.EndsWith("crp"))
                                {
                                    EncryptedMailApp.CryptoStuff.DecryptFile(password, destinationFile, destinationFile.Replace("crp", ""));
                                }
                                //MessageBox.Show("saved attachment at attachments, attachment count is : "+ m.Attachments.Count);
                            }

                        }
                        
                        this.listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_MouseDoubleClick);
                    }
                });
            }
            catch (InvalidCredentialsException)
            {
                MessageBox.Show("The server rejected the supplied credentials.");
            }
            }

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                
                MessageComponent messageComponent = new MessageComponent(messages[index,0], messages[index, 1], messages[index, 2]);
                messageComponent.Show();
            }
        }       
        private void SendMail()
        {
            string mailfrom = logform.getUsrName();
            string mailpass = logform.getUsrPass();
            string msg;
            

            try
            {
                var dateTime = DateTime.Now;
                var messag = new MailMessage(mailfrom, mailTo.Text);
                messag.Subject = subject.Text;
                
                if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    msg = AesCrypt.Encrypt(message.Text + "\n" + dateTime);
                    messag.Body = msg;
                }
     
                if (checkBox1.Checked == true && checkBox2.Checked == false)
                {
                    msg = AesCrypt.Encrypt(message.Text + "\n" + dateTime);
                    messag.Body = msg;
                }
                if(checkBox1.Checked == false && checkBox2.Checked == true)
                {
                    msg = message.Text + "\n"  + dateTime;
                    messag.Body = msg;
                }
                if (checkBox1.Checked == false && checkBox2.Checked == false)
                {
                    msg = message.Text + "\n" + dateTime;
                    messag.Body = msg;
                }


                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(mailfrom, mailpass);
                    smtp.EnableSsl = true;
                    Attachment data = new Attachment(textBox3.Text);
                    messag.Attachments.Add(data);
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

        private void button1_Click(object sender, EventArgs e) //mail sender
        {
            SendMail();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FbClient = new FireSharp.FirebaseClient(config);

            if(FbClient != null)
            {

                //MessageBox.Show("Firebase Connection established");
            }
        }

        private void mailFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
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
            string encrtypted = RSAobj.Encrypt(testbox.Text);
            testtextbox.Text = encrtypted;
        }
        private void button4_Click(object sender, EventArgs e)//decrypt
        {
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

        private void button5_Click(object sender, EventArgs e)
        {
            string textToHash = testbox.Text;
            string hash = RSAobj.GenerateSHA256Hash(textToHash);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            string dir = EncryptedMailApp.LoginForm.user;
            var sr2 = new StreamReader("data\\" + dir + "\\PublicKey.ls");

            string readedKey = sr2.ReadToEnd();
            RSAobj.PublicKey = readedKey;
            sr2.Close();
            keybox.Text = (RSAobj.PublicKey);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            /*
            bool verifybool = RSAobj.VerifySign(message.Text, textBox1.Text);
            if(verifybool == true)
            {
                MessageBox.Show("Match");
            }
            else
            {
                MessageBox.Show("missmatch");
            }*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
            string msgtosign = textBox2.Text;
            string signedmsg = RSAobj.SignData(msgtosign);
            textBox1.Text = signedmsg;*/
        }

        private void button8_Click(object sender, EventArgs e)//find Public Key Button
        {
            //string test = FbClient.Get(textBox2.Text + "/publicKey").Body.ToString();
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(FbClient.Get(textBox2.Text + "/publicKey").Body);
           // foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(doc))
           // {
            //    string name = descriptor.Name;
           //     object value = descriptor.GetValue(doc);
           //     Console.WriteLine("{0}={1}", name, value);
           // }
            //keybox.Text = doc;
            keybox.Text= FbClient.Get(textBox2.Text + "/publicKey").Body.ToString().TrimStart('"').TrimEnd('"');
        }

        private void button9_Click(object sender, EventArgs e) //encyrpt aes
        {
            //string text = testtextbox.Text;
            string encrypted= AesCrypt.Encrypt(testbox.Text);
            testtextbox.Text = encrypted;
        }

        private void button10_Click(object sender, EventArgs e)//decrypt aes
        {
            //string text = testtextbox.Text;
            string decrypted = AesCrypt.Decrypt(testtextbox.Text);
            testtextbox.Text = decrypted;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddFriend friend = new AddFriend();
            friend.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {

            FriendRequests friendReq = new FriendRequests();
            friendReq.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SendMail mailsender = new SendMail();
            mailsender.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {          
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dlg.FileName.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            testtextbox.Text = RSAobj.EncryptFriend(testbox.Text, keybox.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string testkey = "oEAywkyVv203XEhtKubgfLQbEc39JNus";
            AesCrypt.FileEncrypt(textBox3.Text,testkey);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string testkey = "oEAywkyVv203XEhtKubgfLQbEc39JNus";
            AesCrypt.FileDecrypt(textBox3.Text,textBox4.Text, testkey);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
