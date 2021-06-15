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
using Newtonsoft.Json;
using RSAEncDec;
using EncDec;

namespace EncryptedMailApp
{
    public partial class FriendRequests : Form
    {
        public string[,] friendRequests = new string[50,3];

        public FriendRequests()
        {
            InitializeComponent();
        }

        RSACrypt RSAobj = RSACrypt.getInstance();
        AesCrypt AESobj = new AesCrypt();
        

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8sXBXsTWSypjHv9Lfu2P8biITYexw4NIQ80sAmkH",
            BasePath = "https://encryptedmailapp-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient FriendReqClient;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FriendRequests_Load(object sender, EventArgs e)
        {
            FriendReqClient = new FireSharp.FirebaseClient(config);
            if (FriendReqClient != null)
            {
                //MessageBox.Show("Firebase Connection established");
            }
            
            string result;
            try
            {
                result = FriendReqClient.Get(EncryptedMailApp.LoginForm.user+"/friendRequests").Body.ToString();
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

                        string[] request = new string[3];
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
                        for (int i = 0; i < friendRequests.Length; i++)
                        {
                            if (friendRequests[i,0] == null)
                            {
                                friendRequests[i,0] = request[0];
                                friendRequests[i, 1] = request[1];
                                friendRequests[i, 2] = request[2];
                                listBox1.Items.Add(new ListItem { Name = request[0].Trim(charsToTrim), Value = i.ToString() });
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>=0)
            {
                int index = listBox1.SelectedIndex;
                //kendi arkadaslarına eklemesi
                char[] charsToTrim = { ' ', '"' };
                string friendPublic = friendRequests[index, 1].Trim(charsToTrim);
                string friendMail = friendRequests[index, 0].Trim(charsToTrim);
                string friendUsername = friendRequests[index, 2].Trim(charsToTrim);

                //Creating AES KEY
                int length = 32;
                // creating a StringBuilder object()
                StringBuilder str_build = new StringBuilder();
                Random random = new Random();
                char letter;
                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);
                }
                string aesKey= str_build.ToString(); 

                //ENCRYPT AES KEY WITH MY PUBLIC TO STORE IN DB
                
                string encrtyptedAes = RSAobj.Encrypt(aesKey);
                var friend = new
                {
                    friendUsername =friendUsername,
                    mail = friendMail,
                    publicKey = friendPublic,
                    aes = encrtyptedAes
                };
                try {
                    FriendReqClient.Set(EncryptedMailApp.LoginForm.user + "/friends/" + friendUsername, friend);
                    FriendReqClient.Delete(EncryptedMailApp.LoginForm.user + "/friendRequests/"+friendUsername);


                }
                catch
                {
                    MessageBox.Show("There is an error occured!");

                }

                //karşı tarafa ekleme

                 encrtyptedAes = RSAobj.EncryptFriend(aesKey,friend.publicKey);

                friend = new
                {
                    friendUsername = EncryptedMailApp.LoginForm.user,
                    mail = EncryptedMailApp.LoginForm.mail,
                    publicKey = EncryptedMailApp.LoginForm.userpublicKey.Replace("\r","").Replace("\n", ""),
                    aes = encrtyptedAes
                };
                try
                {
                    FriendReqClient.Set(friendUsername + "/friends/" + EncryptedMailApp.LoginForm.user, friend);
                }
                catch
                {
                    MessageBox.Show("There is an error occured!");
                }
            }
            else
            {
                MessageBox.Show("There is no selected request!");
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                int index = listBox1.SelectedIndex;


                //kendi arkadaslarına eklemesi
                char[] charsToTrim = { ' ', '"' };
               
                string friendUsername = friendRequests[index, 2].Trim(charsToTrim);
             
                try
                {
                    FriendReqClient.Delete(EncryptedMailApp.LoginForm.user + "/friendRequests/" + friendUsername);
                    listBox1.Items.RemoveAt(index);
                }
                catch
                {
                    MessageBox.Show("There is an error occured!");
                }

            }
            else
            {
                MessageBox.Show("There is no selected request!");

            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FriendReqClient = new FireSharp.FirebaseClient(config);
            listBox1.Items.Clear();

            string result;
            try
            {
                result = FriendReqClient.Get(EncryptedMailApp.LoginForm.user + "/friendRequests").Body.ToString();
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

                        string[] request = new string[3];
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
                            for (int i = 0; i < friendRequests.Length; i++)
                            {
                                if (friendRequests[i, 0] == null)
                                {
                                    friendRequests[i, 0] = request[0];
                                    friendRequests[i, 1] = request[1];
                                    friendRequests[i, 2] = request[2];
                                    listBox1.Items.Add(new ListItem { Name = request[0].Trim(charsToTrim), Value = i.ToString() });
                                    break;
                                }
                            }
                    }
                }
            }
            catch{ 

            }
         }
    }

    internal class ListItem
    {

        public string Name { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Name;
        }

        
    }
}
