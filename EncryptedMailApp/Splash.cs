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

namespace EncryptedMailApp

{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usrname.Text.Length < 3 || usrpass.Text.Length < 5)
            {
                MessageBox.Show("Username or Password is invalid");
            }
            else
            {
                string dir = usrname.Text;
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

                    if(decryptedusr == usrname.Text && decryptedpass == usrpass.Text)
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
    }
}
