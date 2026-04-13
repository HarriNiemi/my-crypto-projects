using System.Security.Cryptography;
using System.Text;

namespace MyFileCrypto
{
    public partial class MyFileCrypto_form : Form
    {
        const string AppInfo = "My File Crypto";
        const string VerInfo = "Ver-1.0-(2026-04-13)";

        string theKey = "HARRI21101963173";
        string theIV = "3141592653589793";

        string inputFile = "pw_crypt.txt";
        string outputFile = "pw.txt";

        string inputFilePath = null;
        string outputFilePath = null;

        string UG_APP_DIR = "";

        public MyFileCrypto_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string boxText = "";

            DecryptFile(inputFilePath, outputFilePath, theKey, theIV);

            ReadImputFileText(outputFilePath, ref boxText);

            richTextBox1.Text = boxText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteOutputFileText(outputFilePath, richTextBox1.Text);

            EncryptFile(outputFilePath, inputFilePath, theKey, theIV);
        }

        private void EncryptFile(string inputFile, string outputFile, string skey, string sIV)
        {
            try
            {
                using (Aes myAes = Aes.Create())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(sIV);

                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = myAes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // failed to encrypt file
            }
        }

        private void DecryptFile(string inputFile, string outputFile, string skey, string sIV)
        {
            try
            {
                using (Aes myAes = Aes.Create())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(sIV);

                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            using (ICryptoTransform decryptor = myAes.CreateDecryptor(key, IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // failed to decrypt file
            }
        }

        private void ReadImputFileText(string inputFile, ref string inputText)
        {
            using (var file = File.Open(inputFile, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(file))
            {
                inputText = reader.ReadToEnd();
            }
        }

        private void WriteOutputFileText(string outputFile, string outputText)
        {
            using (var file = File.Open(outputFile, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(file))
            {
                writer.Write(outputText.Replace("\n", "\r\n"));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = AppInfo + " : " + VerInfo;

            UG_APP_DIR = AppDomain.CurrentDomain.BaseDirectory;

            inputFilePath = UG_APP_DIR + "\\" + inputFile;
            outputFilePath = UG_APP_DIR + "\\" + outputFile;

        }

        private void MyFileCrypto_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(outputFilePath)) File.Delete(outputFilePath);
        }
    }
}
