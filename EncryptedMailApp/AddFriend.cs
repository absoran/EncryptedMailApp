using System;
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

namespace EncryptedMailApp
{
    public partial class AddFriend : Form
    {
        public AddFriend()
        {
            InitializeComponent();
        }


        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8sXBXsTWSypjHv9Lfu2P8biITYexw4NIQ80sAmkH",
            BasePath = "https://encryptedmailapp-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient AddFriendClient;




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Mailtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PublicKeyBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = NameBox.Text;
            string result;
            
            if (AddFriendClient.Get(username).Body == "null")
            {
               MessageBox.Show("Eklemek istediğiniz kullanıcı bulunamadı. Hemen ulaşın ve bu programı kullanmasını söyleyin");
            }
            else
            {
                 try
                {
                    result = AddFriendClient.Get(username).Body.ToString();

                    var request = new
                    {
                        username = EncryptedMailApp.LoginForm.user,
                        mail = EncryptedMailApp.LoginForm.mail,
                        publicKey = EncryptedMailApp.LoginForm.userpublicKey.Replace("\r", "").Replace("\n", "")
                    };
                    AddFriendClient.Set(username + "/friendRequests/" + EncryptedMailApp.LoginForm.user, request);
                    MessageBox.Show("Arkadaşlık isteği gönderildi");
                }
                catch
                {
                    MessageBox.Show("error sending request");
                }
            }
        }

        private void AddFriend_Load(object sender, EventArgs e)
        {
            AddFriendClient = new FireSharp.FirebaseClient(config);
            if (AddFriendClient != null)
            {
                //MessageBox.Show("Firebase Connection established");
            }
        }
    }
}
