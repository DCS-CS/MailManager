namespace MailManager
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;

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

            ICryptoTransform encryptor;
            byte[] cipher = null;
            byte[] encryptedValue = null;

            try
            {
                encryptor = myaes.CreateEncryptor(myaes.Key, myaes.IV);
                cipher = Encoding.UTF8.GetBytes(text);
                encryptedValue = encryptor.TransformFinalBlock(cipher, 0, cipher.Length);
                encryptor.Dispose();
            }
            catch
            {
                MessageBox.Show(
                    "Error al intentar desencriptar",
                    "Error");
            }

            return Convert.ToBase64String(encryptedValue);
        }
        // Método para desencriptar AES.
        public static string Dencrypt(string cipher)
        {
            if (cipher.Equals(string.Empty) || cipher.Length <= 0)
            {
                throw new ArgumentNullException("cipher");
            }

            byte[] mailEncrypt;
            ICryptoTransform transform;
            byte[] decryptedValue = null;

            try
            {
                mailEncrypt = Convert.FromBase64String(cipher);
                transform = myaes.CreateDecryptor(myaes.Key, myaes.IV);
                decryptedValue = transform.TransformFinalBlock(mailEncrypt, 0, mailEncrypt.Length);
            }
            catch 
            {
                MessageBox.Show(
                    "Error al intentar desencriptar",
                    "Error");
            }

            

            return Encoding.UTF8.GetString(decryptedValue);
        }
    }
}
