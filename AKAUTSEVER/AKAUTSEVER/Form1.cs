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
    public partial class Form1 : Form
    {

        private MySqlConnection connection;
        //private string server = "localhost";
        //private string database = "akaut";
        //private string uid = "akaut";
        //private string password = "akaut";
        private string connectionString;
        private string secredkey;
        private string pass;
        string readPath = @"connect.txt";
        private DataSet data = new DataSet();
        MySqlDataAdapter masterDataAdapter;

        public Form1()
        {
            InitializeComponent();
            try
            {
               StreamWriter sw = new StreamWriter(readPath, true);
               sw.Close();
             // connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";charset = utf8;";
                StreamReader sr = new StreamReader(readPath);
                connectionString = sr.ReadLine();
                sr.Close();
                //MessageBox.Show(connectionString);
                if (connectionString != null)
                {
                   // стартToolStripMenuItem.Enabled = false;
                    connectBD();
                }
                else
                {
                    setting();
                }

              //connection = new MySqlConnection(connectionString);



              //masterDataAdapter = new MySqlDataAdapter("select * from akk_item", connection);
              //masterDataAdapter.Fill(data, "akk_item");
              //printList();
              ////listBox1.SetSelected(0, true);
              //seveselect(0);
              //comboBox1.SelectedItem = 0;

            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void приложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {

            setting();
        }

        private void добавитьНовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_new();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        void printList() {
            listBox1.Items.Clear();
            try
            {
                var query = from site in data.Tables["akk_item"].AsEnumerable()
                            select new { Name = site["name"] };


                foreach (var N in query)
                {
                    listBox1.Items.Add(N.Name.ToString());
                }
            }
            catch (MySqlException eee)
            {
                MessageBox.Show(eee.Message);
            }
        
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            DataRow work = data.Tables["akk_item"].Rows[index];
            labelName.Text = work["name"].ToString();
            linkLabelURL.Text = work["url"].ToString();
            textBox1.Text = work["description"].ToString();
            labelLogin.Text = work["login"].ToString();
            labelPSWD.Text = work["pswd"].ToString();
            pass = work["pswd"].ToString();
            if (work["keycode"].ToString() == "")
            {
                textBoxKey.Visible = false;
                buttonShow.Visible = false;
                buttonHide.Visible = false;
            }
            else {
                secredkey = work["keycode"].ToString();
                textBoxKey.Text = "";
                textBoxKey.Visible = true;
                buttonShow.Visible = true;
                buttonHide.Visible = false;
            
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelPSWD_Click(object sender, EventArgs e)
        {

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

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (textBoxKey.Text == secredkey)
            {
                labelPSWD.Text = Decrypt(labelPSWD.Text, secredkey);
                buttonShow.Visible = false;
                buttonHide.Visible = true;
                // p = Encrypt(p, k); 
            }
            else {
                MessageBox.Show("Вы ввели не правильный ключ!!!");
            }

        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            labelPSWD.Text = pass;
            buttonShow.Visible = true;
            buttonHide.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listBox1.SelectedIndex;
                Form3 newForm = new Form3(data, masterDataAdapter,index);
                // Set the Parent Form of the Child window.
                // newMDIChild.MdiParent = this;
                // Display the new form.
                newForm.FormClosed += (obj, args) => seveselect( index); 

                newForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void seveselect(int ind) {
            printList();
            if (data.Tables["akk_item"].Rows.Count!=0)
            {
            if (ind > data.Tables["akk_item"].Rows.Count)
            {
                listBox1.SetSelected(0, true);
            }
            else {
                listBox1.SetSelected(ind, true);
            }}
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void поToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {

              int choise=comboBox1.SelectedIndex;
              string que = "";
              if (choise == 0) {

                  que = " where name='" + textBox2.Text+"'";
              }
              else if (choise == 1) {

                  que = " where url='" + textBox2.Text+"'";
              }
              else if (choise == 2)
              {

                  que = " where description  like '%" + textBox2.Text +"%'";
              }

              else if (choise == 3)
              {

                  que = " where url='" + textBox2.Text + "'|| name='" + textBox2.Text + "'||  description  like '%" + textBox2.Text + "%'";
              }
              else {
                  que = " where name='" + textBox2.Text + "'";
              }


                data.Clear();

                masterDataAdapter = new MySqlDataAdapter("select * from akk_item "+que, connection);
                masterDataAdapter.Fill(data, "akk_item");
                printList();
                seveselect(0);
            }
            catch (MySqlException eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            data.Clear();

            masterDataAdapter = new MySqlDataAdapter("select * from akk_item " , connection);
            masterDataAdapter.Fill(data, "akk_item");
            printList();
            seveselect(0);
        }

        private void linkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

       

       
        private void общеКоличествоToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otcet();
        }
        void connectBD() {


            try
            {

                StreamReader sr = new StreamReader(readPath);
                connectionString = sr.ReadLine();
                sr.Close();
                connection = new MySqlConnection(connectionString);

                data.Clear();

                masterDataAdapter = new MySqlDataAdapter("select * from akk_item", connection);
                masterDataAdapter.Fill(data, "akk_item");
                printList();
                //listBox1.SetSelected(0, true);
                seveselect(0);
                comboBox1.SelectedItem = 0;
            }
            catch (MySqlException eee) {
                MessageBox.Show(eee.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_new();
        }
        private void add_new() {
            try
            {
                Form2 newMDIChild = new Form2(data, masterDataAdapter);
                // Set the Parent Form of the Child window.
                // newMDIChild.MdiParent = this;
                // Display the new form.
                newMDIChild.FormClosed += (obj, args) => seveselect(data.Tables["akk_item"].Rows.Count - 1);

                newMDIChild.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
        private void otcet() {
            Form4 newForm4 = new Form4(data);

            // newForm4.FormClosed += (obj, args) => seveselect(index);

            newForm4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            otcet();
        }
        private void setting() {
            try
            {
                Form5 newMDI = new Form5();
                // Set the Parent Form of the Child window.
                // newMDIChild.MdiParent = this;
                // Display the new form.
                newMDI.FormClosed += (obj, args) => connectBD();

                newMDI.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
