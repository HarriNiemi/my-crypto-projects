using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyFileCrypto
{
    public partial class MyFileCrypto_form : Form
    {
        const string AppInfo = "My File Crypto";
        const string VerInfo = "Ver-1.0-(2026-04-15)";

        string theKey = "HARRI21101963173";
        string theIV = "3141592653589793";

        string cryptFile = "pw_crypt.txt";
        string plainFile = "pw.txt";

        string cryptFilePath = null;
        string plainFilePath = null;
        string dirPath = null;

        public MyFileCrypto_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = AppInfo + " : " + VerInfo;

            dirPath = AppDomain.CurrentDomain.BaseDirectory;

            textBox3.Text = dirPath;

            textBox1.Text = cryptFile;
            textBox2.Text = plainFile;

            cryptFilePath = dirPath + "\\" + cryptFile;
            plainFilePath = dirPath + "\\" + plainFile;

            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string boxText = "";

            richTextBox1.Clear();

            openFileDialog1.InitialDirectory = dirPath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFileName(openFileDialog1.FileName);

                textBox3.Text = Path.GetDirectoryName(openFileDialog1.FileName);

                dirPath = textBox3.Text;

                cryptFile = textBox1.Text;

                cryptFilePath = openFileDialog1.FileName;

                plainFile = Path.GetFileNameWithoutExtension(cryptFile) + "_plain" + Path.GetExtension(cryptFile);

                plainFilePath = dirPath + "\\" + plainFile;

                textBox2.Text = plainFile;

                DecryptFile(cryptFilePath, plainFilePath, theKey, theIV);

                ReadImputFileText(plainFilePath, ref boxText);

                richTextBox1.Text = boxText;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteOutputFileText(plainFilePath, richTextBox1.Text);

            EncryptFile(plainFilePath, cryptFilePath, theKey, theIV);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string boxText = "";

            richTextBox1.Clear();

            openFileDialog1.InitialDirectory = dirPath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = Path.GetFileName(openFileDialog1.FileName);

                textBox3.Text = Path.GetDirectoryName(openFileDialog1.FileName);

                dirPath = textBox3.Text;

                plainFile = textBox2.Text;

                plainFilePath = openFileDialog1.FileName;

                cryptFile = Path.GetFileNameWithoutExtension(plainFile) + "_crypt" + Path.GetExtension(plainFile);

                cryptFilePath = dirPath + "\\" + cryptFile;

                textBox1.Text = cryptFile;

                ReadImputFileText(plainFilePath, ref boxText);

                richTextBox1.Text = boxText;
            }
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

        private void MyFileCrypto_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if (File.Exists(plainFilePath)) File.Delete(plainFilePath);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0) button2.Enabled = true;
        }
    }
}
