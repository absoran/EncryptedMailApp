﻿using System;
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


namespace EncryptedMailApp
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

    

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (usrname.Text.Length < 3 || usrname.Text.Length < 5)
            {
                MessageBox.Show("Username or Password is invalid.");
            }
            else
            {
                string dir = usrname.Text;
                Directory.CreateDirectory("data\\" + dir);

                var sw = new StreamWriter("data\\" + dir + "\\data.ls");

                string encusr = AesCrypt.Encrypt(usrname.Text);
                string encpass = AesCrypt.Encrypt(usrpass.Text);

                sw.WriteLine(encusr);
                sw.WriteLine(encpass);
                sw.Close();

                MessageBox.Show("Registration successful.", usrname.Text);
                this.Close();
            }
        }
    }
}
