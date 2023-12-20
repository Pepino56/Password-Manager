using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PasswordManager
{
    public class Save
    {
        /// <summary>
        /// 1. Rozsifrovani adresare se daty
        /// 2. Ulozeni dat do xml souboru
        /// 3. Sifrovani adresare s daty
        /// 4. Smazani adresare s nezasifrovanymi daty
        /// </summary>
        /// <param name="a"></param>
        /// <param name="encryptFolder"></param>
        /// <param name="decryptFolder"></param>
        public static void SerializeLogIn(List<DBLogApp> a, string encryptFolder, string decryptFolder)
        {
            EncDec.DecryptFolder(encryptFolder, decryptFolder, "Pas.s@w-_o§§rd");
            try
            {
                XmlSerializer serializer = new XmlSerializer(a.GetType());

                using (StreamWriter sw = new StreamWriter(@"PMDataDec\logIn.xml"))
                {
                    serializer.Serialize(sw, a);
                }
            }
            catch
            {
                //  MessageBox.Show("Soubor nenalezen, bude vytvoren novy.");  
                //zakomentovano z duvodu: behem zobrazeni messageboxu je viditelny adresar s desifrovanymi soubory
            }
            EncDec.EncryptFolder(decryptFolder, encryptFolder, "Pas.s@w-_o§§rd");
            Directory.Delete(decryptFolder, true);
        }

        /// <summary>
        /// 1. Rozsifrovani adresare se daty
        /// 2. Ulozeni dat do xml souboru
        /// 3. Sifrovani adresare s daty
        /// 4. Smazani adresare s nezasifrovanymi daty
        /// </summary>
        /// <param name="a"></param>
        /// <param name="fileName"></param>
        public static void SerializePassword(List<DBPassword> a, string fileName, string encryptFolder, string decryptFolder)
        {
            EncDec.DecryptFolder(encryptFolder, decryptFolder, "Pas.s@w-_o§§rd");
            try
            {
                XmlSerializer serializer = new XmlSerializer(a.GetType());

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    serializer.Serialize(sw, a);
                }
            }
            catch
            {
                //  MessageBox.Show("Soubor nenalezen, bude vytvoren novy.");  
                //zakomentovano z duvodu: behem zobrazeni messageboxu je viditelny adresar s desifrovanymi soubory
            }

            EncDec.EncryptFolder(decryptFolder, encryptFolder, "Pas.s@w-_o§§rd");
            Directory.Delete(decryptFolder, true);
        }
    }
}
