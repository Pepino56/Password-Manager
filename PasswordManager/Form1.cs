using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        private string encryptFolder = @"PMData";
        private string decryptFolder = @"PMDataDec";

        internal List<DBLogApp> logList = new List<DBLogApp>();
        private string userName;
        private string titleTextForm2;
        private string password;
        public Form1()
        {
            InitializeComponent();
            this.btn_logIn.FlatAppearance.BorderSize = 0;
            this.btn_newLog.FlatAppearance.BorderSize = 0;
            this.btn_about.FlatAppearance.BorderSize = 0;
        }
        private void btn_logIn_Click(object sender, EventArgs e)
        {
            userName = EncDec.EncryptText(this.txt_UserName.Text, "Dobry den");
            password = EncDec.EncryptText(this.txt_Passwd.Text, "Den dobry");
            titleTextForm2 = this.txt_UserName.Text;
            foreach (var i in logList)
            {
                if ((i.UserName != userName) || (i.Password != password))
                {
                    continue;
                }
                this.Hide();
                var form2 = new Form2(titleTextForm2, i.Id);
                form2.Show();
            }
        }
        private void btn_newLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_UserName.Text) || string.IsNullOrEmpty(txt_Passwd.Text))
            {
                MessageBox.Show("Nebylo vyplneno uživatelské jméno nebo heslo");
                return;
            }
            userName = EncDec.EncryptText(this.txt_UserName.Text, "Dobry den");
            password = EncDec.EncryptText(this.txt_Passwd.Text, "Den dobry");
            int id = logList.Count() + 1;
            foreach (var i in logList)
            {
                if (i.UserName == userName)
                {
                    MessageBox.Show("Uzivatelske jmeno je obsazeno");
                    return;
                }
            }
            AddOrUpdate.AddNewLogApp(logList, userName, password, id);
            Save.SerializeLogIn(logList, encryptFolder, decryptFolder);
            txt_UserName.Clear();
            txt_Passwd.Clear();
        }
        /// <summary>
        /// 1. Kontrola existence adresaru, pripadne vytvoreni
        /// 2. Nacteni dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(encryptFolder))
            {
                Directory.CreateDirectory(encryptFolder);
            }
            if (Directory.Exists(encryptFolder))
            {
                logList = PasswordManager.Load.DeserializeLogIn(logList, encryptFolder, decryptFolder);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save.SerializeLogIn(logList, encryptFolder, decryptFolder);
            Application.Exit();
        }
        private void btn_logIn_MouseEnter(object sender, EventArgs e)
        {
            this.btn_logIn.FlatStyle = FlatStyle.Popup;
        }
        private void btn_logIn_MouseLeave(object sender, EventArgs e)
        {
            this.btn_logIn.FlatStyle = FlatStyle.Flat;
        }
        private void btn_newLog_MouseEnter(object sender, EventArgs e)
        {
            this.btn_newLog.FlatStyle = FlatStyle.Popup;
        }
        private void btn_newLog_MouseLeave(object sender, EventArgs e)
        {
            this.btn_newLog.FlatStyle = FlatStyle.Flat;
        }
        private void btn_about_MouseLeave(object sender, EventArgs e)
        {
            this.btn_about.FlatStyle = FlatStyle.Flat;
        }
        private void btn_about_MouseEnter(object sender, EventArgs e)
        {
            this.btn_about.FlatStyle = FlatStyle.Popup;
        }
        private void btn_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Vytvořil:{"Josef P.",25}\nObor:{"AIK2",25}\nRok:{"2023",27}");
        }
    }
}
