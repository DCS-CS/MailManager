namespace MailManager
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    internal static class AES
    {
        private static readonly AesManaged myaes = new AesManaged();
        // Constructor el cual configura la variable myaes.
        public static void CryptoConfigure()
        {
            myaes.Padding = PaddingMode.PKCS7;
            myaes.Mode = CipherMode.CBC;
            //myaes.KeySize = 128;

            string fileKey = "Key.bin";
            string fileVector = "Vector.bin";

            byte[] key = new byte[32];
            byte[] IV = new byte[16];

            if (!File.Exists(fileKey))
            {
                FileStream keysave = new FileStream(fileKey, FileMode.Create);
                keysave.Close();

                keysave = new FileStream(fileKey, FileMode.Open, FileAccess.Write);
                keysave.Write(myaes.Key, 0, myaes.Key.Length);
                keysave.Close();
            }
            else
            {
                FileStream keysave = new FileStream(fileKey, FileMode.Open, FileAccess.Read);
                keysave.Read(key, 0, myaes.Key.Length);
                keysave.Close();
                myaes.Key = key;
            }

            if (!File.Exists(fileVector))
            {
                FileStream vectorsave = new FileStream(fileVector, FileMode.Create);
                vectorsave.Close();

                vectorsave = new FileStream(fileVector, FileMode.Open, FileAccess.Write);
                vectorsave.Write(myaes.IV, 0, myaes.IV.Length);
                vectorsave.Close();
            }
            else
            {
                FileStream vectorsave = new FileStream(fileVector, FileMode.Open, FileAccess.Read);
                vectorsave.Read(IV, 0, myaes.IV.Length);
                vectorsave.Close();
                myaes.IV = IV;
            }
        }
        // Método para encriptar AES.
        public static string Encrypt(string text)
        {
            if (text == null || text.Length <= 0)
            {
                throw new ArgumentNullException("text");
            }

            ICryptoTransform encryptor = myaes.CreateEncryptor(myaes.Key, myaes.IV);
            byte[] cipher = Encoding.UTF8.GetBytes(text);
            byte[] encryptedValue = encryptor.TransformFinalBlock(cipher, 0, cipher.Length);
            encryptor.Dispose();

            return Convert.ToBase64String(encryptedValue);
        }
        // Método para desencriptar AES.
        public static string Dencrypt(string cipher)
        {
            if (cipher.Equals(string.Empty) || cipher.Length <= 0)
            {
                throw new ArgumentNullException("cipher");
            }

            byte[] mailEncrypt = Convert.FromBase64String(cipher);

            /*ICryptoTransform decryptor = myaes.CreateDecryptor(myaes.Key, myaes.IV);
            MemoryStream memoryStream = new MemoryStream(mailEncrypt);

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            StreamReader srDecrypt = new StreamReader(cryptoStream);*/

            ICryptoTransform transform = myaes.CreateDecryptor(myaes.Key, myaes.IV);
            byte[] decryptedValue = transform.TransformFinalBlock(mailEncrypt, 0, mailEncrypt.Length);

            return Encoding.UTF8.GetString(decryptedValue);
        }
    }
}
