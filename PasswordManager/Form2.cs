using System;
using System.Collections.Generic;
using System.Windows.Forms;

//https://stackoverflow.com/questions/37271461/c-sharp-adding-data-to-list-inside-list
namespace PasswordManager
{
    [Serializable]
    internal partial class Form2 : Form
    {
        private string encryptFolder = @"PMData";
        private string decryptFolder = @"PMDataDec";

        private int id;
        private string fileName;
        private List<DBPassword> kontaktList = new List<DBPassword>();

        internal Form2(string titleApp, int id)
        {
            InitializeComponent();
            this.btn_addNew.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_showPassword.FlatAppearance.BorderSize = 0;
            this.id = id;
            fileName = @"PMDataDec\" + $"pass{this.id}.xml";
            this.Text = $"Password Manager - {titleApp}";
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_addNew_Click(object sender, EventArgs e)
        {
            AddOrUpdate.AddOrUpdatePassword(kontaktList, listBox1, txt_name, txt_password, txt_userName, id, 2, fileName);
            Save.SerializePassword(kontaktList, fileName, encryptFolder, decryptFolder);
            listBox1.ClearSelected();
            VymazFormular();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            AddOrUpdate.AddOrUpdatePassword(kontaktList, listBox1, txt_name, txt_password, txt_userName, id, 1, fileName);
            Save.SerializePassword(kontaktList, fileName, encryptFolder, decryptFolder);
            listBox1.ClearSelected();
            VymazFormular();
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DBPassword record = listBox1.Items[listBox1.SelectedIndex] as DBPassword;
                txt_name.Text = record.NameOf;
                txt_userName.Text = EncDec.DecryptText(record.UserName, "joha");
                txt_password.Text = record.Password;
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeletePassword.DeletePass(listBox1, kontaktList, fileName);
            Save.SerializePassword(kontaktList, fileName, encryptFolder, decryptFolder);
            listBox1.ClearSelected();
            VymazFormular();
        }
        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex != -1) && (!string.IsNullOrEmpty(txt_name.Text)))
            {
                string showPass = EncDec.DecryptText(this.txt_password.Text, "ahoj");
                MessageBox.Show(showPass);
            }
            listBox1.ClearSelected();
            VymazFormular();
        }
        private void VymazFormular()
        {
            this.txt_name.Clear();
            this.txt_userName.Clear();
            this.txt_password.Clear();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //EncDec.EncryptFolder(@"PMData", @"a1" , "strong Password for Decription Folder_-123456");
            Save.SerializePassword(kontaktList, fileName, encryptFolder, decryptFolder);
            Application.Exit();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            kontaktList = PasswordManager.Load.DeserializePassword(kontaktList, fileName, encryptFolder, decryptFolder);
            listBox1.DataSource = kontaktList;
        }
        private void btn_addNew_MouseEnter(object sender, EventArgs e)
        {
            this.btn_addNew.FlatStyle = FlatStyle.Popup;
        }
        private void btn_addNew_MouseLeave(object sender, EventArgs e)
        {
            this.btn_addNew.FlatStyle = FlatStyle.Flat;
        }
        private void btn_delete_MouseEnter(object sender, EventArgs e)
        {
            this.btn_delete.FlatStyle = FlatStyle.Popup;
        }
        private void btn_delete_MouseLeave(object sender, EventArgs e)
        {
            this.btn_delete.FlatStyle = FlatStyle.Flat;
        }
        private void btn_update_MouseEnter(object sender, EventArgs e)
        {
            this.btn_update.FlatStyle = FlatStyle.Popup;
        }
        private void btn_update_MouseLeave(object sender, EventArgs e)
        {
            this.btn_update.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Exit_MouseEnter(object sender, EventArgs e)
        {
            this.btn_Exit.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Exit_MouseLeave(object sender, EventArgs e)
        {
            this.btn_Exit.FlatStyle = FlatStyle.Flat;
        }
        private void btn_showPassword_MouseEnter(object sender, EventArgs e)
        {
            this.btn_showPassword.FlatStyle = FlatStyle.Popup;
        }
        private void btn_showPassword_MouseLeave(object sender, EventArgs e)
        {
            this.btn_showPassword.FlatStyle = FlatStyle.Flat;
        }
    }
}
