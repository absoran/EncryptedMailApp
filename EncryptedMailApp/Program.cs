using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;
using EncryptedMailApp;
using RSAEncDec;
namespace MainProgram
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new EncryptedMailApp.LoginForm());
            //Application.Run(new Form1());
            //Application.Run(new AddFriend());
        }
    }
}
