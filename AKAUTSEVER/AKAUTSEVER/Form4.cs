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
namespace AKAUTSEVER
{


    public partial class Form4 : Form
    {
        public DataSet temp;
        public Form4(DataSet data)
        {
            InitializeComponent();
            temp = data;
            comboBox1.SelectedIndex = 0;
        }
        private string countloginPswd(string cell, string ob)
        {

            string total = "";
            DataTable tabl = temp.Tables["akk_item"];
            var query =
                from ak in tabl.AsEnumerable()
                where (string)ak[cell] == ob
                group ak by ak.Field<string>(cell) into g
                select new { Login = g.Key, LCount = g.Count() };

            foreach (var rez in query)
            {
                total += rez.Login + " - " + rez.LCount + "шт. \n";

            }
            if (total == "") {
                total = "Нет такого совпадения";
            }
            return total;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) { 
                case 0:
                    label1.Visible = true;
                    textBoxLog.Visible = true;
                    label2.Visible = false;
                    textBoxPass.Visible = false;
                    break;
                case 1:
                    label1.Visible = false;
                    textBoxLog.Visible = false;
                    label2.Visible = true;
                    textBoxPass.Visible = true;
                    break;
                case 2:
                    label1.Visible = true;
                    textBoxLog.Visible = true;
                    label2.Visible = true;
                    textBoxPass.Visible = true;
                    break;
                case 3:
                    label1.Visible = false;
                    textBoxLog.Visible = false;
                    label2.Visible = false;
                    textBoxPass.Visible = false;
                    break;
                case 4:
                    label1.Visible = false;
                    textBoxLog.Visible = false;
                    label2.Visible = false;
                    textBoxPass.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                   textBox1.Text= countloginPswd("login", textBoxLog.Text);
                    break;
                case 1:
                    textBox1.Text = countloginPswd("pswd", textBoxPass.Text);
                    break;
                case 2:
                    textBox1.Text = countloginPswd("login", "pswd",textBoxLog.Text, textBoxPass.Text);
                    break;
                case 3:
                    textBox1.Text = getMax("login");
                    break;
                case 4:
                    textBox1.Text = getMax("pswd");
                    break;
            }
        }
         private string countloginPswd(string cell1,string cell2, string ob1, string ob2)
        {

            string total = "";
            DataTable tabl = temp.Tables["akk_item"];
            var query =
                from ak in tabl.AsEnumerable()
                where (string)ak[cell1] == ob1 && (string)ak[cell2] == ob2 
                
                group ak by ak.Field<string>(cell1) into g
                select new { Login = g.Key, LCount = g.Count() };

            foreach (var rez in query)
            {
                total += textBoxLog.Text+"/"+ textBoxPass.Text+ " - " + rez.LCount + "шт. \n";

            }
            if (total == "") {
                total = "Нет такого совпадения";
            }
            return total;
        }
         private string getMax(string cell) {
             string total = "";
             DataTable tabl = temp.Tables["akk_item"];
             var query =
                 from ak in tabl.AsEnumerable()
               
                 group ak by ak.Field<string>(cell) into g
                 let c=g.Count()

                 orderby g.Count() descending
                // where c>1
                 select new { Login = g.Key, LCount = c};

             foreach (var rez in query)
             {
                 total += rez.Login + " - " + rez.LCount + "шт. \n";
                 break;

             }
             
                 //total = ;
             
             return total;
         }
    }
}
