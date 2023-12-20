using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager
{
    internal static class EncDec
    {

        //Pouzit kod z: https://www.codeproject.com/Articles/769741/CSharp-AES-bits-Encryption-Library-with-Salt?fid=1859393&df=90&mpp=25&prof=True&sort=Position&view=Normal&spc=Relaxed&fr=26
        internal static string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        internal static string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }
        private static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }
        private static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }




        //Pouzit kod z: https://www.dotnetoffice.com/2023/05/encrypt-and-decrypt-folder-in-c.html
        internal static void EncryptFolder(string sourceFolder, string destinationFolder, string password)
        {
            // Generate a random salt value
            byte[] salt = new byte[8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Create an AES encryption algorithm with the specified password and salt
            using (var aes = new AesManaged())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                var key = new Rfc2898DeriveBytes(password, salt, 1000).GetBytes(32);
                aes.Key = key;
                aes.IV = new byte[16];
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                // Create the destination folder if it doesn't exist
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // Encrypt each file in the source folder and copy it to the destination folder
                foreach (string filePath in Directory.GetFiles(sourceFolder))
                {
                    using (var fsIn = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var fsOut = new FileStream(Path.Combine(destinationFolder, Path.GetFileName(filePath)), FileMode.Create, FileAccess.Write))
                        {
                            // Write the salt value to the beginning of the output file
                            fsOut.Write(salt, 0, salt.Length);

                            // Encrypt the file using the AES algorithm
                            using (var cryptoStream = new CryptoStream(fsOut, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                fsIn.CopyTo(cryptoStream);
                            }
                        }
                    }
                }

            }
        }
        internal static void DecryptFolder(string sourceFolder, string destinationFolder, string password)
        {
            // Create the destination folder if it doesn't exist
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }
            // Loop through each file in the source folder
            foreach (string filePath in Directory.GetFiles(sourceFolder))
            {
                // Read the salt value from the beginning of the input file
                byte[] salt = new byte[8];
                using (var fsIn = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fsIn.Read(salt, 0, salt.Length);
                }

                // Create an AES decryption algorithm with the specified password and salt
                using (var aes = new AesManaged())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(password, salt, 1000).GetBytes(32);
                    aes.Key = key;
                    aes.IV = new byte[16];
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Mode = CipherMode.CBC;

                    // Decrypt the input file using the AES algorithm and copy it to the destination folder
                    using (var fsIn = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var cryptoStream = new CryptoStream(fsIn, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            fsIn.Read(salt, 0, salt.Length);

                            using (var fsOut = new FileStream(Path.Combine(destinationFolder, Path.GetFileName(filePath)), FileMode.Create, FileAccess.Write))
                            {
                                cryptoStream.CopyTo(fsOut);
                            }
                        }
                    }
                }
            }
        }
    }
}
