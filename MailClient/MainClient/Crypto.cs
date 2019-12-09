using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MainClient
{
    class Crypto
    {
        public string Hesh(string Input)
        {
            using (SHA256Managed sha2 = new SHA256Managed())
            {
                var hash = sha2.ComputeHash(Encoding.UTF8.GetBytes(Input));
                return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
            }
        }
        public string ReturnEncryptRijndaelString(string inputString)
        {
            using (Rijndael rijndael = Rijndael.Create())
            {
                byte[] Encrypted = RijndaelEncrypt(inputString, rijndael.Key, rijndael.IV);
                return $"{Convert.ToBase64String(Encrypted)}^&*{Convert.ToBase64String(rijndael.Key)}^&*{Convert.ToBase64String(rijndael.IV)}";
            }
        }
        public string ReturnDecryptRijndaelString(string inputString)
        {
            string[] Decrypted = inputString.Split(new string[] { "^&*" }, StringSplitOptions.None);
            return RijndaelDecrypt(Convert.FromBase64String(Decrypted[0].ToString()), 
                Convert.FromBase64String(Decrypted[1].ToString()), 
                Convert.FromBase64String(Decrypted[2].ToString()));
        }
        public byte[] RijndaelEncrypt(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        public string RijndaelDecrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        public enum RSAKeySize
        {
            Key512 = 512,
            Key1024 = 1024,
            Key2048 = 2048,
            Key4096 = 4096
        }
        public class RSAKeysTypes
        {
            public string PublicKey { get; set; }
            public string PrivateKey { get; set; }
        }
        public RSAKeysTypes GenerateKeys(RSAKeySize rsaKeySize)
        {
            int keySize = (int)rsaKeySize;
            if (keySize % 2 != 0 || keySize < 512)
                throw new Exception("Ключ должен быть кратен 2!");
            var rsaKeysTypes = new RSAKeysTypes();
            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                var publicKey = provider.ToXmlString(false);
                var privateKey = provider.ToXmlString(true);
                var publicKeyWithSize = IncludeKeyInEncryptionString(publicKey);
                var privateKeyWithSize = IncludeKeyInEncryptionString(privateKey);
                rsaKeysTypes.PublicKey = publicKeyWithSize;
                rsaKeysTypes.PrivateKey = privateKeyWithSize;
            }
            return rsaKeysTypes;
        }
        public bool _optimalAsymmetricEncryptionPadding = false;
        //конвертирование в base64 ключа
        public string IncludeKeyInEncryptionString(string publicKey)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKey));
        }
        //Из base64 в xml  
        private void GetKeyFromEncryptionString(string rawkey, out string xmlKey)
        {
            xmlKey = "";
            if (rawkey != null && rawkey.Length > 0)
            {
                byte[] keyBytes = Convert.FromBase64String(rawkey);
                xmlKey = Encoding.UTF8.GetString(keyBytes);
            }
        }
        public byte[] Encrypt(byte[] data, string PublicKey)
        {
            string publicKeyXml = "";
            GetKeyFromEncryptionString(PublicKey, out publicKeyXml);
            if (data == null || data.Length == 0)
                throw new ArgumentException("Data are empty", "data");
            using (var provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(publicKeyXml);
                return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }
        public string Encrypt(string plainText, string PublicKey)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(plainText), PublicKey));
        }
        public string Decrypt(string encryptedText, string PrivateKey)
        {
            var decrypted = Decrypt(Convert.FromBase64String(encryptedText), PrivateKey);

            return Encoding.UTF8.GetString(decrypted);
        }
        public string Decrypt(string encryptedText, int ID)
        {
            WorkWithDatabase workWithDatabase = new WorkWithDatabase();
            string prKey = workWithDatabase.GetPrivateKeyForUser(ID);
            var decrypted = Decrypt(Convert.FromBase64String(encryptedText), prKey);
            return Encoding.UTF8.GetString(decrypted);
        }
        public byte[] Decrypt(byte[] data, string PrivateKey)
        {
            string publicAndPrivateKeyXml = "";
            GetKeyFromEncryptionString(PrivateKey, out publicAndPrivateKeyXml);

            if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
            using (var provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(publicAndPrivateKeyXml);
                return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }
        public string ReturnStringWithTowChipers(string text, int ID)
        {
            string[] temp = ReturnEncryptRijndaelString(text).Split(new string[] { "^&*" }, StringSplitOptions.None); /*временный массив для формирования зашифрованного сообщения согласно заданной последовательности*/
            WorkWithDatabase workWithDatabase = new WorkWithDatabase();
            string pbKey = workWithDatabase.GetPublicKeyForUser(ID);  /*"Берём public ключ из базы"*/

            temp[1] = Encrypt(temp[1], pbKey);   /*Шифруем ключ при помощи алгоритма RSA*/

            string EncryptText = "";

            for (int i = 0; i < temp.Length; i++)    /*Формируем конечную строку*/
            {
                if (i < temp.Length - 1)
                    EncryptText += $"{temp[i]}^&*";
                else
                    EncryptText += temp[i];
            }
            return EncryptText;
        }
    }
}