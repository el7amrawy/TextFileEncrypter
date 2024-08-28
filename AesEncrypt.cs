using System.Security.Cryptography;

namespace FileEncrypter
{
    internal class AesEncrypt
    {
        internal static byte[] Encrypter(string plainText, byte[] IV, byte[] Key)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
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
        internal static string Decrypter(byte[] cipherText, byte[] IV, byte[] Key)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            string plainText;
            using (Aes aesAlg=Aes.Create())
            {
                aesAlg.Key= Key;
                aesAlg.IV= IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt=new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt=new StreamReader(csDecrypt))
                        {
                            plainText= srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plainText;
        }
        internal static byte[] GenerateRandomKey()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateKey();
                return aesAlg.Key;
            }
        }

        internal static byte[] GenerateRandomIV()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateIV();
                return aesAlg.IV;
            }
        }

        internal static string EncryptFile(string filePath, byte[] IV, byte[] Key)
        {
            if (filePath == null || filePath.Length <= 0)
                throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
            byte[] encrypted;
            using (FileStream fs=new FileStream(filePath,FileMode.Open))
            {
                using (StreamReader sr=new StreamReader(fs))
                {
                    encrypted= Encrypter(sr.ReadToEnd(),IV,Key);
                }
            }

            var fileName = filePath.Split('\\').Last().Split('.').First();
            var temp = filePath.Split('\\');
            temp[temp.Length - 1] = fileName + ".enc";
            string newFilePath =  temp.Join(@"\");
            using (FileStream fs = new FileStream(newFilePath, FileMode.Create))
            {
                using(StreamWriter sw=new StreamWriter(fs))
                {
                    sw.Write(Convert.ToBase64String(encrypted) + $"\n{filePath.Split('\\').Last().Split('.').Last()}");
                }
            }
            File.Delete(filePath);
            return newFilePath;
        }
        internal static string DecryptFile(string filePath, byte[] IV, byte[] Key)
        {
            if (filePath == null || filePath.Length <= 0)
                throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            string  fileType=string.Empty, decrypted=string.Empty;
            using (FileStream fs=new FileStream(filePath,FileMode.Open))
            {
                using(StreamReader sr=new StreamReader(fs))
                {
                    string s;
                    bool b= true;
                    while ((s= sr.ReadLine())!=null)
                    {
                        fileType = s;
                        if (b)
                        {
                            decrypted=Decrypter(Convert.FromBase64String(s),IV,Key);
                        }
                        b=false;
                    }
                }
            }
            var fileName = filePath.Split('\\').Last().Split('.').First();
            var temp = filePath.Split('\\');
            temp[temp.Length - 1] = fileName + "."+fileType;
            string newFilePath = temp.Join(@"\");
            using (FileStream fs=new FileStream(newFilePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(decrypted);
                }
            }
            return "";
        }

    }
    internal static class ExternalMethods
    {
        internal static string Join(this string[] arr,string c)
        {
            string s = string.Empty;
            for (int i=0;i<arr.Length;i++)
            {
                s += arr[i];
                if(i!=arr.Length-1)
                    s += c;
            }
            return s;
        }
    }
}
