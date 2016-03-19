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
//using System.Data.SqlClient;
using System.Security.Cryptography;
 
using System.IO;
namespace AKAUTSEVER
{
    
    public partial class Form2 : Form
    {
       
        public DataSet temp;
         MySqlDataAdapter dataAdapter;
         string key="";
         public Form2(DataSet data, MySqlDataAdapter dataAdap)
         {
             InitializeComponent();
             temp = data;
             dataAdapter = dataAdap;
         }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textName.Text != "")
            {
                
                DataRow work = temp.Tables["akk_item"].NewRow();
                work["name"] = textName.Text;
                work["url"] = textURL.Text;
                work["description"] = textDesc.Text;
                work["login"] = textLogin.Text;
                work["pswd"] = textPSWD.Text;
                //if (textKey.Text == "")
                //{
                //    work["keycode"] = null;
                //}
                //else
                //{
                //    work["keycode"] = textKey.Text;
                //}
                work["keycode"] = key;

                temp.Tables["akk_item"].Rows.Add(work);
              MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
               
               
                dataAdapter.Update(temp.Tables["akk_item"]);
                temp.Clear();
                dataAdapter.Fill(temp, "akk_item");
                this.Close();
            }
            else {
                MessageBox.Show("Поле \"название сайта\"  обязательно");
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

        private void button2_Click(object sender, EventArgs e)
        {
            string p = textPSWD.Text;
            string k = textKey.Text;
           
            p = Encrypt(p, k); //где text — текст который необходимо зашифровать,password — пароль для шифровки
            key = k;
           // p = Decrypt(p, k);
            textPSWD.Text = p;
           // button3.Enabled = true;
            button3.Visible = true;
          //  button2.Enabled = false;
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string k = textKey.Text;
            string p = textPSWD.Text;
            p = Decrypt(p, k);
            textPSWD.Text = p;
           // button3.Enabled = false;
           // button2.Enabled =true ;
            key = "";
            button2.Visible = true;
            button3.Visible = false;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }





    }
}
