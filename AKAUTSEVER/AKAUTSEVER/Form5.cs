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
using System.IO;
namespace AKAUTSEVER
{
    public partial class Form5 : Form
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database;
        private string uid;
        private string password;
        private string connectionString;
        string readPath = @"connect.txt";
        public Form5()
        {
            TopMost = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               database=textBoxNameBD.Text;
               uid = textBoxNameUser.Text;
               password = textBoxPswdBD.Text;

                connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";charset = utf8;";

                connection = new MySqlConnection(connectionString);

                connection.Open();
                connection.Close();
                MessageBox.Show("Ок!!! Есть соединение!");  
            }
            catch (MySqlException eee)
            {
                MessageBox.Show("Проблема подключения!!! Проверьте данные");
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {

            try { 
            database = textBoxNameBD.Text;
            uid = textBoxNameUser.Text;
            password = textBoxPswdBD.Text;

            connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";charset = utf8;";
            connection = new MySqlConnection(connectionString);
            MySqlCommand cmd;

            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "CREATE TABLE akk_item (id INT NOT NULL AUTO_INCREMENT , name VARCHAR(70) NOT NULL, url VARCHAR(100) NOT NULL, description TEXT NOT NULL, login VARCHAR(70) NOT NULL, pswd VARCHAR(100) NOT NULL, keycode VARCHAR(100) NOT NULL, PRIMARY KEY(id));";

            cmd.ExecuteNonQuery();


            connection.Close();
            StreamWriter sw = new StreamWriter(readPath, false);

            sw.WriteLine(connectionString);
            sw.Close();
           this.Close();
            }
            catch (MySqlException eee)
            {
                MessageBox.Show(eee.Message);
            }



            
        }
    }
}
