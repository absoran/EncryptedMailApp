using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EncryptedMailApp;

namespace EncryptedMailApp
{
    public partial class MessageComponent : Form
    {
        string from,  subject,  body;
        public MessageComponent()
        {
            InitializeComponent();
        }
        public MessageComponent(string from, string subject, string body)
        {
            InitializeComponent();
            this.from = from;
            this.subject = subject;
            this.body = body;
            textBox1.Text = from;
            textBox2.Text = subject;
            textBox3.Text = body;
            if(EncryptedMailApp.Form1.signed == true)
            {
                label4.Text = "This message is Signed";
            }
            else
            {
                label4.Text = "This Message is not Signed";
            }
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MessageComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
