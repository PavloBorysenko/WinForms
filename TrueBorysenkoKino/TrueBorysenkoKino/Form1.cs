using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueBorysenkoKino
{
    public partial class Form1 : Form
    {
        class Plaze
        {
            public int col;
            public int row;
            public double price;
            public Button b;
            public bool free { get; set; }
            public Plaze(int c, int r, double p)
            {
               
                col = c;
                row = r;
                price = p;
                free = true;
            }
            public string Print() {
                return "Ряд " + (row+1) + " Место " + (col+1) + " Цена " + price;
            }
        }

        List<Plaze> plazes = new List<Plaze>();
        List<Plaze> plazes_comp = new List<Plaze>();
        public Form1()
        {
            InitializeComponent();
            int z = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int pr = 0;
                    if ((j > 0 && j < 3) && i < 2)
                    {
                        pr = 50;
                    }
                    else if ((j > 0 && j < 3) && i >=2)
                    {
                        pr = 30;
                    }
                    else
                    {
                        pr = 20;
                    }
                    plazes.Add(new Plaze(j,i,pr));
                    
                    
                }
            } 
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button16));
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button2));

        }



       

        private void button18_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button18));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button10));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button14));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button15));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button3));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button4));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button5));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button6));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button7));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button8));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button9));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button11));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button12));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Cheng_color(flowLayoutPanel1.Controls.IndexOf(button13));
        }
        public void Cheng_color(int i)
        {
            if (flowLayoutPanel1.Controls[i].BackColor == System.Drawing.Color.Green)
            {
                flowLayoutPanel1.Controls[i].BackColor = System.Drawing.Color.Red;
                add_list(i);
            }
            else
            {
                flowLayoutPanel1.Controls[i].BackColor = System.Drawing.Color.Green;
                del_list(i);
            };
             

        }
        public void add_list(int i) {

            plazes_comp.Add(plazes[i]);
            listBox1.Items.Clear();
            double p = 0;
            foreach (Plaze item in plazes_comp) {
                p += item.price;
                listBox1.Items.Add(item.Print());
            
            }
            textBox1.Text = p.ToString();

        }
        public void del_list(int i) {
            for (int j = 0; j < plazes_comp.Count; j++) {
                if ((plazes[i].row == plazes_comp[j].row) && (plazes[i].col == plazes_comp[j].col)) {
                    plazes_comp.RemoveAt(j);
                    break;
                }
            
            }
            listBox1.Items.Clear();
            double p = 0;
            foreach (Plaze item in plazes_comp)
            {
                p += item.price;
                listBox1.Items.Add(item.Print());

            }
            textBox1.Text = p.ToString();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double p = 0;
            foreach (Plaze item in plazes_comp)
            {
                p += item.price;
              

            }
            MessageBox.Show("Вы кунили "+plazes_comp.Count+" белета. За "+p);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 1 && trackBar1.Value < 3)
            {
                radioButton1.Checked = true;
            }
            else if (trackBar1.Value > 3 && trackBar1.Value < 6)
            {
                radioButton2.Checked = true;
            }
            else if (trackBar1.Value > 6 && trackBar1.Value < 9)
            {
                radioButton3.Checked = true;
            }
            else if (trackBar1.Value > 9)
            {
                radioButton4.Checked = true;
            }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
    }
}
