using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
namespace AKAUTSEVER
{
    public partial class Form3 : Form
    {
        public DataSet temp;
        MySqlDataAdapter dataAdapter;
        int indx;
        string key="";
        public Form3(DataSet t, MySqlDataAdapter d, int i)
        {
            InitializeComponent();

            temp = t;
            dataAdapter = d;
            indx = i;
            DataRow work = temp.Tables["akk_item"].Rows[indx];
            TextBoxName.Text = work["name"].ToString();
            textBoxLogin.Text = work["login"].ToString();
            textBoxURL.Text = work["url"].ToString();
            textBoxDesc.Text = work["description"].ToString();
            textBoxPSWD.Text = work["pswd"].ToString();
            if (work["keycode"].ToString() == "")
            {
                buttonEnc.Visible = true;
                buttonDes.Visible = false;
            }
            else {
                key = work["keycode"].ToString();
                buttonEnc.Visible = false;
                buttonDes.Visible = true;
            }





        }

        public static string Encrypt(string plainText, string password,
     string salt = "Kosher", string hashAlgorithm = "SHA1",
     int passwordIterations = 2, string initialVector = "OFRna73m*aze01xY",
     int keySize = 256)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = derivedPassword.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;

            using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmetricKey.Clear();
            return Convert.ToBase64String(cipherTextBytes);
        }



        //дешифрование
        public static string Decrypt(string cipherText, string password,
               string salt = "Kosher", string hashAlgorithm = "SHA1",
               int passwordIterations = 2, string initialVector = "OFRna73m*aze01xY",
               int keySize = 256)
        {
            if (string.IsNullOrEmpty(cipherText))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = derivedPassword.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int byteCount = 0;

            using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                    {
                        byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmetricKey.Clear();
            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (TextBoxName.Text != "")
            {

                DataRow work = temp.Tables["akk_item"].Rows[indx];
                work["name"] = TextBoxName.Text;
                work["url"] = textBoxURL.Text;
                work["description"] = textBoxDesc.Text;
                work["login"] = textBoxLogin.Text;
                work["pswd"] = textBoxPSWD.Text;
               
                    work["keycode"] = key;
                   // MessageBox.Show(key);
                
              

               // temp.Tables["akk_item"].Rows.Add(work);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Update(temp.Tables["akk_item"]);
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле \"название сайта\"  обязательно");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnc_Click(object sender, EventArgs e)
        {
            key = textBoxKey.Text;
           textBoxPSWD.Text=Encrypt(textBoxPSWD.Text, key);
           buttonEnc.Visible = false;
           buttonDes.Visible = true;
        }

        private void buttonDes_Click(object sender, EventArgs e)
        {
            if (textBoxKey.Text == key)
            {
                key = "";
                textBoxPSWD.Text = Decrypt(textBoxPSWD.Text, textBoxKey.Text);
                buttonEnc.Visible = true;
                buttonDes.Visible = false;
            }
            else {
                MessageBox.Show("Ключ не подходит!!!");
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            DataRow work = temp.Tables["akk_item"].Rows[indx];
            //temp.Tables["akk_item"].Rows.Remove(work);
            work.Delete();
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Update(temp.Tables["akk_item"]);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow work = temp.Tables["akk_item"].Rows[indx];
            work["pswd"] = "";
            work["keycode"] = "";
            textBoxKey.Text = "";
            textBoxPSWD.Text = "";
            key = "";
            buttonDes.Visible = false;
            buttonEnc.Visible = true;
        }

    }
}
