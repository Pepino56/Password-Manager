using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManager
{
    internal static class AddOrUpdate
    {
        internal static void AddNewLogApp(List<DBLogApp> logList, string userName, string password, int id)
        {
            DBLogApp newLog = new DBLogApp
            {
                UserName = userName,
                Password = password,
                Id = id
            };
            logList.Add(newLog);
        }
        internal static void AddOrUpdatePassword(List<DBPassword> kontaktList, ListBox listBox1, TextBox txt_name, TextBox txt_password, TextBox txt_userName, int id, int a, string fileName)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_password.Text) || string.IsNullOrWhiteSpace(txt_userName.Text))
            {
                MessageBox.Show("Formulář není kompletní, prosím doplň ho.");
                return;
            }
            string nameOf = txt_name.Text;
            string userName = EncDec.EncryptText(txt_userName.Text, "joha");
            string password = EncDec.EncryptText(txt_password.Text, "ahoj");
            DBPassword newPassword = new DBPassword
            {
                Id = id,
                NameOf = nameOf,
                UserName = userName,
                Password = password
            };
            if (a == 1)
            {
                int ind = listBox1.SelectedIndex;
                DeletePassword.DeletePass(listBox1, kontaktList, fileName);
                kontaktList.Insert(ind, newPassword);
            }
            else
            {
                kontaktList.Add(newPassword);
            }
            listBox1.DataSource = null;
            listBox1.DataSource = kontaktList;
        }
    }
}
