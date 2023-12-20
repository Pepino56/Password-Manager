using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PasswordManager
{
    public class Load
    {
        /// <summary>
        /// 1. Desifrovani adresare
        /// 2. Deserializace dat do Listu<T>
        /// 3. Sifrovani adresare
        /// 4. Smazani desifrovaneho adresare
        /// </summary>
        /// <param name="a"></param>
        /// <param name="encryptFolder"></param>
        /// <param name="decryptFolder"></param>
        /// <returns></returns>
        public static List<DBLogApp> DeserializeLogIn(List<DBLogApp> a, string encryptFolder, string decryptFolder)
        {
            EncDec.DecryptFolder(encryptFolder, decryptFolder, "Pas.s@w-_o§§rd");
            try
            {
                XmlSerializer deserializer = new XmlSerializer(a.GetType());
                using (StreamReader sr = new StreamReader(@"PMDataDec\logIn.xml"))
                {
                    a = (List<DBLogApp>)deserializer.Deserialize(sr);
                }
            }
            catch
            {
              //  MessageBox.Show("Soubor nenalezen, bude vytvoren novy.");  
              //zakomentovano z duvodu: behem zobrazeni messageboxu je viditelny adresar s desifrovanymi soubory
            }
            EncDec.EncryptFolder(decryptFolder, encryptFolder, "Pas.s@w-_o§§rd");
            Directory.Delete(decryptFolder, true);

            return a;
        }

        /// <summary>
        /// 1. Desifrovani adresare
        /// 2. Deserializace dat do Listu<T>
        /// 3. Sifrovani adresare
        /// 4. Smazani desifrovaneho adresare
        /// </summary>
        /// <param name="a"></param>
        /// <param name="fileName"></param>
        /// <param name="encryptFolder"></param>
        /// <param name="decryptFolder"></param>
        /// <returns></returns>
        public static List<DBPassword> DeserializePassword(List<DBPassword> a, string fileName, string encryptFolder, string decryptFolder)
        {
            EncDec.DecryptFolder(encryptFolder, decryptFolder, "Pas.s@w-_o§§rd");
            try
            {
                XmlSerializer deserializer = new XmlSerializer(a.GetType());
                using (StreamReader sr = new StreamReader(fileName))
                {
                    a = (List<DBPassword>)deserializer.Deserialize(sr);
                }
            }
            catch
            {
                //  MessageBox.Show("Soubor nenalezen, bude vytvoren novy.");  
                //zakomentovano z duvodu: behem zobrazeni messageboxu je viditelny adresar s desifrovanymi soubory
            }
            EncDec.EncryptFolder(decryptFolder, encryptFolder, "Pas.s@w-_o§§rd");
            Directory.Delete(decryptFolder, true);

            return a;
        }
    }
}
