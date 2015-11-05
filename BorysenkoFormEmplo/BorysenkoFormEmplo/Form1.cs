using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BorysenkoFormEmplo
{
    public partial class Form1 : Form
    {
        int index;
        class Person
        {
            public string name;
            public string s_name;
            public string b_day;
            public Person(string N, string S, string D)
            {
                name = N;
                s_name = S;
                b_day = D;
            }
        }
        class Emploer : Person
        {
            public int id;
            public string prof;
            public Emploer(string N, string S, string D, int I, string P)
                : base(N, S, D)
            {
                id = I;
                prof = P;
            }
            public string print_inf() {
                string str = name + "\r\n ______________\r\n" + s_name + "\r\n ______________\r\n" + "\r\nПрофессия\r\n" + prof + "\r\n ______________\r\n";
                return str;
            }
            public string print_dop_inf() {
                string str = "День рождения " + b_day + "\r\n ______________\r\n" + "Инд. Код " + id + "\r\n ______________\r\n";
                return str;
            }
        }
        class Market : Emploer
        {
            public int zp;

            public Market(string N, string S, string D, int I, int Z)
                : base(N, S, D, I, "Маркетолог")
            {
                zp = Z;
            }
            public string info() {
                return print_inf() + "\nЗарплата \n" + zp;
            }
        }

        class Ingener : Emploer
        {
            public int zp;

            public Ingener(string N, string S, string D, int I, int Z)
                : base(N, S, D, I, "Инженер")
            {
                zp = Z;
            }
            public string info()
            {
                return print_inf() + "\nЗарплата \n" + zp;
            }
        }
        class Proizv : Emploer
        {
            public int zp;

            public Proizv(string N, string S, string D, int I, int Z)
                : base(N, S, D, I, "Рабочий")
            {
                zp = Z;
            }
           
            public string info()
            {
                return print_inf() + "\nЗарплата \n" + zp;
            }
        }

        List<Emploer> market = new List<Emploer>();
        List<Emploer> ingener = new List<Emploer>();
        List<Emploer> rabot = new List<Emploer>();
        List<Emploer> tempMas = new List<Emploer>();

        public string print(int i) {
            if (tempMas[i] is Market) {
                return (tempMas[i] as Market).info();
            }
            else if (tempMas[i] is Ingener) {
                return (tempMas[i] as Ingener).info();
            }
            else if (tempMas[i] is Proizv)
            {
                return (tempMas[i] as Proizv).info();
            }
            return "";
        
        }
        public Form1()
        {
            InitializeComponent();
            market.Add(new Market("Василий","Продажкин","12.02.93",121211,1000));
            market.Add(new Market("Сергей", "Рекламов", "09.12.89", 123211, 1100));
            market.Add(new Market("Антон", "Шефко", "31.04.75", 909754, 1500));
            market.Add(new Market("Елена", "Кофеварко", "21.05.95", 673531, 800));

            ingener.Add(new Ingener("Виталий","Умников","07.10.90",3689428,1300));
            ingener.Add(new Ingener("Дмитрий", "Сыншефко", "09.08.96", 858878, 2000));
            ingener.Add(new Ingener("Лев", "Изобретенидзе", "01.01.91", 844884, 1450));
            ingener.Add(new Ingener("Светлана", "Боссиня", "06.11.80", 4747755, 1800));

            rabot.Add(new Proizv("Лена", "Пролова", "09.01.95", 6444353, 700));
            rabot.Add(new Proizv("Виталий", "Слесарев", "07.05.80", 112211, 800));
            rabot.Add(new Proizv("Антон", "Мастеров", "05.09.93", 456789, 1000));
            rabot.Add(new Proizv("Герман", "Ремонтин", "11.10.78", 763664, 800));


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void mark_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            if (radio.Checked)
            {
                index = 0;
                tempMas = market;
               
                foreach (Market item in tempMas)
                {
                    listEmpl.Items.Add(item.name + " " + item.s_name);

                }
                listEmpl.SetSelected(index, true);
                textBox1.Text = print(index);
                textBox2.Text = tempMas[index].print_dop_inf();

            }
            else {
                listEmpl.Items.Clear();
            }  
        }

        private void inge_CheckedChanged(object sender, EventArgs e)
        {
            var radio1 = (RadioButton)sender;
            if (radio1.Checked)
            {
                index = 0;
                tempMas = ingener;
               
                foreach (Ingener item in tempMas)
                {
                    listEmpl.Items.Add(item.name + " " + item.s_name);
                }
                listEmpl.SetSelected(index, true);
                textBox1.Text = print(index);
                textBox2.Text = tempMas[index].print_dop_inf();
            }
            else
            {
                listEmpl.Items.Clear();
            } 
        }

        private void proiz_CheckedChanged(object sender, EventArgs e)
        {
            var radio2 = (RadioButton)sender;
            if (radio2.Checked)
            {
                index = 0;
                tempMas = rabot;
               
                foreach (Proizv item in tempMas)
                {
                    listEmpl.Items.Add(item.name + " " + item.s_name);
                   
                } 
                listEmpl.SetSelected(index, true);
                    textBox1.Text = print(index);
                    textBox2.Text = tempMas[index].print_dop_inf();

            }
            else
            {
                listEmpl.Items.Clear();
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index++;
            if (index > tempMas.Count-1)
            {
                index = 0;
            }
            listEmpl.SetSelected(index, true);
            textBox1.Text = print(index);
       
            textBox2.Text = tempMas[index].print_dop_inf();
        }

        private void listEmpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectItem = listEmpl.SelectedItem.ToString();
            index= listEmpl.FindString(selectItem);
            textBox1.Text = print(index);
          
            textBox2.Text = tempMas[index].print_dop_inf();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var check = (sender as CheckBox);
            if (check.Checked == true)
            {
                textBox2.Show();
            }
            else
            {
                textBox2.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = tempMas.Count-1;
            }
            listEmpl.SetSelected(index, true);
            textBox1.Text = print(index);
         
            textBox2.Text = tempMas[index].print_dop_inf();
            
        }
    }
}
