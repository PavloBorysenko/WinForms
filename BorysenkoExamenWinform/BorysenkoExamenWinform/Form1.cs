using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorysenkoExamenWinform
{
    public partial class Form1 : Form
    {
     


        Program.Person Client;
        List<Program.Person> Clients = new List<Program.Person>();
     
         
        public Form1()
        {
            Clients.Add(new Program.Person("gest", "Гость", " ", 0));
            Clients.Add(new Program.Person("ivan", "Иван", "ivan", 300));
            Clients.Add(new Program.Person("djon", "Джон", "djon", 30));

            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client = Clients[0];

            Program.frm2 = new but_del(Client.login, Client.name, Client.pswd, Client.many);
            Program.frm2.Show();
            this.Hide();
        }

        private void enter_button_Click(object sender, EventArgs e)
        {
            string temp_log = name.Text;
            string temp_pswd = password.Text;
            foreach (Program.Person item in Clients)
            {

                if (item.auth(temp_log, temp_pswd)){
                    Client = item;
                    Program.frm2 = new but_del(Client.login, Client.name, Client.pswd, Client.many);
                    Program.frm2.Show();
                    this.Hide();
                }
            
            }
            error.Text = "Такого ползователя не существует";

            
            
            
        }
    }
}
