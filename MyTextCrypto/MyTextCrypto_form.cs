using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyTextCrypto
{
    public partial class MyTextCrypto_form : Form
    {
        const string AppInfo = "My Text Crypto";
        const string VerInfo = "Ver-1.0-(2026-04-13)";


        public MyTextCrypto_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = EncryptText(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = DecryptText(textBox4.Text, textBox2.Text, textBox3.Text);
        }

        private string EncryptText(string plaintext, string skey, string sIV)
        {
            byte[] encryptedBytes;
            string encryptedText = "";

            try
            {
                using (Aes myAes = Aes.Create())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(sIV);

                    myAes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform encryptor = myAes.CreateEncryptor(key, IV))
                    {
                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                byte[] plainBytes = Encoding.UTF8.GetBytes(plaintext);
                                csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                            }

                            encryptedBytes = msEncrypt.ToArray();
                        }
                    }

                    encryptedText = Convert.ToBase64String(encryptedBytes);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return encryptedText;
        }


        private string DecryptText(string plaintext, string skey, string sIV)
        {
            byte[] decryptedBytes;
            string decryptedText = "";

            try
            {
                using (Aes myAes = Aes.Create())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(sIV);

                    myAes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform decryptor = myAes.CreateDecryptor(key, IV))
                    {
                        using (MemoryStream msDecrypt = new MemoryStream())
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                            {
                                byte[] plainBytes = Convert.FromBase64String(plaintext);
                                csDecrypt.Write(plainBytes, 0, plainBytes.Length);
                            }

                            decryptedBytes = msDecrypt.ToArray();
                        }
                    }

                    decryptedText = System.Text.Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return decryptedText;
        }

        private void MyTextCrypto_form_Load(object sender, EventArgs e)
        {
            this.Text = AppInfo + " : " + VerInfo;
        }
    }
}

/*
       public static string Decrypt(byte[] ciphertext, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
               ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
               byte[] decryptedBytes;
               using (var msDecrypt = new System.IO.MemoryStream(ciphertext))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var msPlain = new System.IO.MemoryStream())
                        {
                            csDecrypt.CopyTo(msPlain);
                            decryptedBytes = msPlain.ToArray();
                        }
                    }
                }
               return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        private string DecryptText(string plaintext, string skey, string sIV)
        {
            byte[] decryptedBytes;
            string decryptedText = "";

            try
            {
                using (Aes myAes = Aes.Create())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(sIV);

                    using (ICryptoTransform decryptor = myAes.CreateDecryptor(key, IV))
                    {
                        using (MemoryStream msDecrypt = new MemoryStream(Encoding.UTF8.GetBytes(plaintext)))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (MemoryStream msPlain = new MemoryStream())
                                {
                                    csDecrypt.CopyTo(msPlain);
                                    decryptedBytes = msPlain.ToArray();
                                }

                            }
                        }
                    }

                    decryptedText = Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                // failed to encrypt text
            }

            return decryptedText;
        }


        public static byte[] Encrypt(string plaintext, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
               ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
               byte[] encryptedBytes;
               using (var msEncrypt = new System.IO.MemoryStream())
                {
                   using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plaintext);
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                    }
                   encryptedBytes = msEncrypt.ToArray();
                }
                return encryptedBytes;
            }
        }


        private string DecryptText(string plaintext, string skey, string sIV)
        {
            byte[] decryptedBytes;
            string decryptedText = "";

            try
            {
                using (Aes myAes = Aes.Create())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(sIV);

                    using (ICryptoTransform decryptor = myAes.CreateDecryptor(key, IV))
                    {
                        using (MemoryStream msDecrypt = new MemoryStream())
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                            {
                                byte[] plainBytes = Encoding.UTF8.GetBytes(plaintext);
                                csDecrypt.Write(plainBytes, 0, plainBytes.Length);
                           }

                            decryptedBytes = msDecrypt.ToArray();
                        }
                    }

                    decryptedText = Convert.ToBase64String(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                // failed to encrypt text
            }

            return decryptedText;
        }


*/