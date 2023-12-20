using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManager
{
    internal class DeletePassword
    {
        private static string encryptFolder = @"PMData";
        private static string decryptFolder = @"PMDataDec";
        internal static void DeletePass(ListBox listBox1, List<DBPassword> kontaktList, string fileName)
        {
            if (listBox1.Items.Count >= 1)
            {
                if (listBox1.SelectedValue != null)
                {
                    var items = (List<DBPassword>)listBox1.DataSource;
                    var item = (DBPassword)listBox1.SelectedValue;
                    listBox1.DataSource = null;
                    listBox1.Items.Clear();
                    items.Remove(item);
                    listBox1.DataSource = items;
                    Save.SerializePassword(kontaktList, fileName, encryptFolder, decryptFolder);
                }
            }
            else
            {
                MessageBox.Show("Není žádný záznam k vymazání");
            }
        }
    }
}
