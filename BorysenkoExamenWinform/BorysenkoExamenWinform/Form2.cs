using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace BorysenkoExamenWinform
{
    

    public partial class but_del : Form
    {
        






        Program.Person Client;
        List<Program.Bludo> main_menu = new List<Program.Bludo>();

        List<Program.Bludo> then_menu=new List<Program.Bludo>();
        List<Program.Bludo> second_menu=new List<Program.Bludo>();
        List<Program.Bludo> first_menu = new List<Program.Bludo>();
        List<Program.Bludo> com_menu = new List<Program.Bludo>();
        List<Program.Menu> complex_menu = new List<Program.Menu>();
        List<Program.Menu> standart = new List<Program.Menu>();
        List<Program.Menu> temp = new List<Program.Menu>();
        static public int my_cursor = 0;

        



        public but_del(string l, string n, string p, double m)
        {
            Client = new Program.Person(l, n, p, m);
          
         
            InitializeComponent();


            lab_name.Text = Client.name;
            lab_many.Text = Client.many.ToString();
            lab_summa.Text = "0";

            com_menu.Add(new Program.Bludo("Стандартный обед", "Борщ, Картошка с котлетой, сок", 13.50));
            com_menu.Add(new Program.Bludo("Домашний обед", "Суп с макаронами, Мясное ассорти, чай", 10.50));
            com_menu.Add(new Program.Bludo("Итальянский обед", "Суп овощной, паста, салат, дисерт", 12.00));
            complex_menu.Add(new Program.Menu(this.complex_list, com_menu, "Комплексные  меню"));

            first_menu.Add(new Program.Bludo("Вега-суп", "Овощной суп", 2.50));
            first_menu.Add(new Program.Bludo("Борщ", "Красный украинский борщ", 4.00));
            first_menu.Add(new Program.Bludo("Суп", "Куриный суп с макаронами", 3.00));
            standart.Add(new Program.Menu(this.first_list, first_menu, "Первые блюда"));

            second_menu.Add(new Program.Bludo("Мясное ассорти", "Мясное ассорти из 4-х видов мяса", 8.50));
            second_menu.Add(new Program.Bludo("Пица", "Большая пица с мясом и грибами", 5.80));
            second_menu.Add(new Program.Bludo("Картошка с котлетой", "Картофельное пюре, с котлетами", 4.30));
            second_menu.Add(new Program.Bludo("Паста", "Паста с итальянским соусом", 4.00));
            standart.Add(new Program.Menu(this.second_list, second_menu, "Вторые блюда"));
            then_menu.Add(new Program.Bludo("Чай", "Черный крупнолистовой чай", 1.50));
            then_menu.Add(new Program.Bludo("Пирожено", "Сладкий дисерт с кремом и шоколадом", 2.50));
            then_menu.Add(new Program.Bludo("Сок", "Сок апельсиновый, fresh", 3.00));
            then_menu.Add(new Program.Bludo("Кофе", "Черный кофе, Lavazza", 2.00));
            standart.Add(new Program.Menu(this.then_list, then_menu, "Дисерты и напитки"));
            temp = standart;
            foreach (Program.Bludo item in temp[my_cursor].bludo_menu)
            {
                list_menu.Items.Add(item.name_pos);
            }
            //list_menu.SelectedItem = 1;
            list_menu.SetSelected(0, true);
            button1.Enabled = false;
            lab_comp.Hide();
            label5.Hide();
            textBox2.Hide();
            butt_up.Hide();
            lab_nam_com.Hide();
            text_name_com.Hide(); 
            lab_numer.Hide();
            butt_trans.Hide();
            butt_hide.Hide();
            
        
        }
  
 




     
          

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frm1.Close();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void butt_bludo_Click(object sender, EventArgs e)
        {
            
            list_menu.Items.Clear();
            my_cursor = 0;
            temp = standart;
            print(temp, list_menu, my_cursor);
            //foreach (Program.Bludo item in temp[my_cursor].bludo_menu)
            //{
            //    list_menu.Items.Add(item.name_pos);
            //}
           
            list_menu.SetSelected(0, true);
            if (temp.Count <=1)
            {
                butt_prev.Enabled = false;
                butt_next.Enabled = false;
            }
            else {
                butt_prev.Enabled = true;
                butt_next.Enabled = true;
            }
        }

        private void butt_compl_Click(object sender, EventArgs e)
        {
            list_menu.Items.Clear();
            my_cursor = 0;
            temp = complex_menu;
            print(temp, list_menu,my_cursor);
            //foreach (Program.Bludo item in temp[my_cursor].bludo_menu)
            //{
            //   list_menu.Items.Add(item.name_pos);
            //}
            list_menu.SetSelected(0, true);
          
            if (temp.Count <= 1)
            {
                butt_prev.Enabled = false;
                butt_next.Enabled = false;
            }
            else
            {
                butt_prev.Enabled = true;
                butt_next.Enabled = true;
            }
        }

        static void print(List<Program.Menu> temp, ListBox lis, int ind)
        {
            foreach (Program.Bludo item in temp[ind].bludo_menu)
            {
                lis.Items.Add(item.name_pos);
            }

        }

        private void butt_add_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = list_menu.SelectedIndex;
            main_menu.Add(temp[my_cursor].bludo_menu[i]);
            //foreach (Program.Bludo item in main_menu)
            //{
            //    list_choise.Items.Add(item.name_pos);
            //}
            print(main_menu, list_choise, lab_summa, button1);
        }
        static void print(List<Program.Bludo> li, ListBox box, Label summa,Button but) {
            double sum=0;
            box.Items.Clear();
            foreach (Program.Bludo item in li)
            {
                box.Items.Add(item.name_pos);
                sum += item.price;
            }
            summa.Text = sum.ToString();
            if (li.Count < 1)
            {
                but.Enabled = false;
            }
            else {
                but.Enabled = true;
            }
        
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (list_choise.Items.Count > 0)
            {
                double sum_many = 0;
                foreach (Program.Bludo item in main_menu)
                {
                    sum_many += item.price;
                }
                if (Client.login == "gest")
                {
                    Program.frm2.Size = new System.Drawing.Size(900, 376);

                    lab_comp.Location = new System.Drawing.Point(660, 15);
                    lab_comp.Show();
                    lab_comp.Text = "Воспользуйтесь электронным переводом";
                    lab_nam_com.Location = new System.Drawing.Point(678, 35);
                    lab_nam_com.Show();
                    text_name_com.Location = new System.Drawing.Point(678, 50);
                    text_name_com.Show();
                    lab_numer.Location = new System.Drawing.Point(678, 82);
                    lab_numer.Show();
                    textBox2.Location = new System.Drawing.Point(678, 95);
                    textBox2.Show();
                    butt_trans.Location = new System.Drawing.Point(678, 125);
                    butt_trans.Show();
                    butt_hide.Location = new System.Drawing.Point(800, 300);
                    butt_hide.Show();

                }
                else
                {

                    if (sum_many > Client.many)
                    {

                        Program.frm2.Size = new System.Drawing.Size(900, 376);
                        double res = sum_many - Client.many;
                        lab_comp.Location = new System.Drawing.Point(678, 15);
                        lab_comp.Show();
                        label5.Location = new System.Drawing.Point(678, 35);
                        label5.Show();
                        textBox2.Location = new System.Drawing.Point(678, 55);
                        textBox2.Show();
                        butt_up.Location = new System.Drawing.Point(678, 85);
                        butt_up.Show();
                        lab_comp.Text = "На Вашем  счете не хватает  " + res.ToString();
                        butt_hide.Location = new System.Drawing.Point(800, 300);
                        butt_hide.Show();

                    }
                    else
                    {

                        Client.many -= sum_many;
                        MessageBox.Show("Ваш заказ оформлен, Приятного аппетита");
                        list_choise.Items.Clear();
                        lab_many.Text = Client.many.ToString();
                        print_chek(main_menu);
                        main_menu.Clear();
                        lab_summa.Text = "0";
                    }

                }
            }
            else {
                MessageBox.Show("Вы ничего не заказали!");
            }

        }

        private void list_menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            lab_name_men.Text = temp[my_cursor].name_menu;
            int i = 0;
            i = list_menu.SelectedIndex;
            textBox1.Text = temp[my_cursor].bludo_menu[i].description;
            pictureBox2.Image = temp[my_cursor].imag.Images[i];

            lab_price.Text = temp[my_cursor].bludo_menu[i].price.ToString();




        }

        private void butt_next_Click(object sender, EventArgs e)
        {
            list_menu.Items.Clear();

            if (my_cursor == temp.Count-1)
            {
                my_cursor = 0;
            }
            else
            {
                my_cursor++;
            }



            foreach (Program.Bludo item in temp[my_cursor].bludo_menu)
            {
                list_menu.Items.Add(item.name_pos);
            }
            list_menu.SetSelected(0, true); 
        }

        private void butt_prev_Click(object sender, EventArgs e)
        {
            list_menu.Items.Clear();
            if (my_cursor == 0)
            {
                my_cursor = temp.Count - 1;
            }
            else { 
                my_cursor--;
            }
            
           
            foreach (Program.Bludo item in temp[my_cursor].bludo_menu)
            {
                list_menu.Items.Add(item.name_pos);
            }
            list_menu.SetSelected(0, true); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            i = list_choise.SelectedIndex;
            if (list_choise.SelectedItem != null) { 
            main_menu.RemoveAt(i);
            print(main_menu, list_choise, lab_summa, button1);
            }
        }

        private void butt_up_Click(object sender, EventArgs e)
        {
            Client.many += double.Parse(textBox2.Text);
            lab_many.Text = Client.many.ToString();
            lab_comp.Location = new System.Drawing.Point(20, 350);
            lab_comp.Hide();
            lab_comp.Text="";
            label5.Location = new System.Drawing.Point(20, 350);
            label5.Hide();
            textBox2.Location = new System.Drawing.Point(20, 350);
            textBox2.Clear();
            textBox2.Hide();
            butt_up.Location = new System.Drawing.Point(20, 350);
            butt_up.Hide();
            Program.frm2.Size = new System.Drawing.Size(680, 376);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void butt_trans_Click(object sender, EventArgs e)
        {
            if (text_name_com.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else {
                MessageBox.Show("Ваш заказ оформлен, Приятного аппетита");
                list_choise.Items.Clear();
                print_chek(main_menu);
                main_menu.Clear();

               

                lab_comp.Location = new System.Drawing.Point(20, 350);
                lab_comp.Hide();
                lab_comp.Text = "Воспользуйтесь электронным переводом";
                lab_nam_com.Location = new System.Drawing.Point(20, 350);
                lab_nam_com.Hide();
                text_name_com.Location = new System.Drawing.Point(20, 350);
                text_name_com.Hide();
                text_name_com.Clear();
                lab_numer.Location = new System.Drawing.Point(20, 350);
                lab_numer.Hide();
                textBox2.Location = new System.Drawing.Point(20, 350);
                textBox2.Hide();
                textBox2.Clear();
                butt_trans.Location = new System.Drawing.Point(20, 350);
                butt_trans.Hide();
                lab_summa.Text = "0";
             Program.frm2.Size = new System.Drawing.Size(680, 376);
            }
        }

        private void list_choise_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void butt_hide_Click(object sender, EventArgs e)
        {
       
           
            lab_comp.Location = new System.Drawing.Point(20, 350);
            lab_comp.Hide();
            lab_comp.Text = "";
            label5.Location = new System.Drawing.Point(20, 350);
            label5.Hide();
            textBox2.Location = new System.Drawing.Point(20, 350);
            textBox2.Clear();
            textBox2.Hide();
            butt_up.Location = new System.Drawing.Point(20, 350);
            butt_up.Hide();
            butt_hide.Location = new System.Drawing.Point(20, 350);
            butt_hide.Hide();
           
           
            lab_nam_com.Location = new System.Drawing.Point(20, 350);
            lab_nam_com.Hide();
            text_name_com.Location = new System.Drawing.Point(20, 350);
            text_name_com.Hide();
            text_name_com.Clear();
            lab_numer.Location = new System.Drawing.Point(20, 350);
            lab_numer.Hide();
          
            butt_trans.Location = new System.Drawing.Point(20, 350);
            butt_trans.Hide();
          

            Program.frm2.Size = new System.Drawing.Size(680, 376);



        }

        static void print_chek(List<Program.Bludo>  bl) {
            string nameT = "Счет";
            double s = 0;
            nameT += DateTime.Now.ToShortDateString();
            nameT +="N"+ DateTime.Now.Millisecond.ToString();
            StreamWriter ticket = File.CreateText(nameT+".txt");
            ticket.WriteLine("Спасибо за заказ. Приятного аппетита!");
            ticket.WriteLine("**************************************");     
            foreach (Program.Bludo item in bl)
            {
                ticket.WriteLine(item.name_pos + " --- " + item.price.ToString());
                s += item.price;
            }
            ticket.WriteLine("**************************************");
            ticket.WriteLine("Сумма: " + s.ToString()+" $");
            ticket.WriteLine("Дата заказа: "+DateTime.Now.ToShortDateString());
            ticket.Close();
        
        }
    

      

       
    }
}
