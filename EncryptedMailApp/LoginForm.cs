using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EncDec;
using RSAEncDec;
using EncryptedMailApp;

namespace EncryptedMailApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        RSACrypt RSAobj = RSACrypt.getInstance();

        public static string user;
        public static string mail;
        public static string userpublicKey;

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (usrname.Text.Length < 3 || usrpass.Text.Length < 3)
            {
                MessageBox.Show("Username or Password is invalid");
            }
            else
            {
                string dir = usrname.Text;
                user = usrname.Text;
                
                if (!Directory.Exists("data\\" + dir))
                    MessageBox.Show("user not found" + dir);
                else
                {
                    var sr = new StreamReader("data\\" + dir + "\\data.ls");
                    string cryptedusr = sr.ReadLine();
                    string cryptedpass = sr.ReadLine();
                    sr.Close();
                    string decryptedusr = AesCrypt.Decrypt(cryptedusr);
                    string decryptedpass = AesCrypt.Decrypt(cryptedpass);

                    var sr2 = new StreamReader("data\\" + dir + "\\PublicKey.ls");

                    string readedKey =sr2.ReadToEnd();
                    RSAobj.PublicKey = readedKey;
                    userpublicKey = readedKey;

                    sr2.Close();

                    var sr3 = new StreamReader("data\\" + dir + "\\PrivateKey.ls");

                    string readedKey2 = sr3.ReadToEnd();
                    RSAobj.PrivateKey = readedKey2;

                    sr3.Close();

                    var sr4 = new StreamReader("data\\" + dir + "\\mail.ls");

                    string readedMail = sr4.ReadLine();
                    string decryptedMail = AesCrypt.Decrypt(readedMail);
                    mail = decryptedMail;

                    sr4.Close();

                    if (decryptedusr == usrname.Text && decryptedpass == usrpass.Text)
                    {
                        MessageBox.Show("Authentication succesfull.");
                        Form1 log = new Form1();
                        log.Show();
                    }
                    else
                    {
                        MessageBox.Show("User or password is wrong.");
                    }

                }

            }
        }

        public string getUsrName()
        {
            string dir = user;
            string error = "USER NOT FOUND !";
            if (!Directory.Exists("data\\" + dir))
            {
              return error;
            }              
            else
            {
                
                var sr4 = new StreamReader("data\\" + dir + "\\mail.ls");
                string cryptedMailUsr = sr4.ReadLine();
                sr4.Close();
                string decryptedMailUsr = AesCrypt.Decrypt(cryptedMailUsr);
                return decryptedMailUsr;
            }

        }
        public string getUsrPass()
        {
            string dir = user;
            string error = "USER NOT FOUND !";

            if (!Directory.Exists("data\\" + dir))
            {
                return error;
            }
            else
            {

                var sr4 = new StreamReader("data\\" + dir + "\\mail.ls");
                sr4.ReadLine();
                string cryptedMailPass = sr4.ReadLine();
                sr4.Close();
                string decryptedMailPass = AesCrypt.Decrypt(cryptedMailPass);
                return decryptedMailPass;
            }

        }

        private void usrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //RSAobj.createKey();
        }
    }
}
