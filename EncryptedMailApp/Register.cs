using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EncDec;
using System.IO;
using RSAEncDec;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace EncryptedMailApp
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8sXBXsTWSypjHv9Lfu2P8biITYexw4NIQ80sAmkH",
            BasePath = "https://encryptedmailapp-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient RgClient;

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (usrname.Text.Length < 4 && usrpass.Text.Length < 4)
            {
                MessageBox.Show("Username or Password is invalid.");
            }
            else
            {
                RSACrypt RSAobj = RSACrypt.getInstance();
                RSAobj.createKey();
                string dir = usrname.Text;
                Directory.CreateDirectory("data\\" + dir);
                var sw = new StreamWriter("data\\" + dir + "\\data.ls");

                string encusr = AesCrypt.Encrypt(usrname.Text);
                string encpass = AesCrypt.Encrypt(usrpass.Text);               
                sw.WriteLine(encusr);
                sw.WriteLine(encpass);
                sw.Close();

                var sw2 = new StreamWriter("data\\" + dir + "\\PublicKey.ls");
                string PublicKey = RSAobj.RSApublicKey;
                //string PublicKey = new string(RSAobj.PublicKey.Where(c => !char.IsWhiteSpace(c)).ToArray());
                sw2.WriteLine(PublicKey);
                sw2.Close();

                var sw3 = new StreamWriter("data\\" + dir + "\\PrivateKey.ls");
                //string PrivateKey = new string(RSAobj.PrivateKey.Where(c => !char.IsWhiteSpace(c)).ToArray());
                string PrivateKey = RSAobj.PrivateKey;
                sw3.WriteLine(PrivateKey);
                sw3.Close();

                var sw4 = new StreamWriter("data\\" + dir + "\\mail.ls");
                string UserMail = AesCrypt.Encrypt(UserMailTextBox.Text);
                string UserMailPass = AesCrypt.Encrypt(UserMailPassBox.Text);
                sw4.WriteLine(UserMail);
                sw4.WriteLine(UserMailPass);
                sw4.Close();

                RgClient.Set(usrname.Text+"/publicKey", PublicKey);
                RgClient.Set(usrname.Text + "/mail", UserMailTextBox.Text);
                

                MessageBox.Show("Registration successful.", usrname.Text);
                this.Close();
            }
        }

        private void usrpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            RgClient = new FireSharp.FirebaseClient(config);
            if (RgClient != null)
            {
                //MessageBox.Show("Firebase Connection established");
            }
        }
    }
}
