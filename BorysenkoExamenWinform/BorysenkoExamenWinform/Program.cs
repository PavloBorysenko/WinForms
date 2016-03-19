using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorysenkoExamenWinform
{
    static class Program
    {
        public class Person
        {
            public string login;
            public string name;
            public string pswd;
            public double many;
            public Person(string l, string n, string p, double m)
            {
                login = l;
                name = n;
                pswd = p;
                many = m;
            }
            public bool auth(string l, string p)
            {

                if (l == login && p == pswd)
                {
                    return true;
                }
                return false;
            }
            public bool conpr(double m)
            {
                if (m > many)
                {
                    return false;
                }
                many -= m;
                return true;
            }
            public void add_many(string m)
            {
                many += Double.Parse(m);

            }
            public string get_data()
            {
                return "Спасибо  Вам, " + name + " за покупку ";
            }
        }
        public class Bludo
        {
            public string name_pos;
            public string description;
            public double price;
            public Bludo(string n, string d, double p)
            {
                name_pos = n;
                description = d;
                price = p;

            }

        }

        public class Menu
        {
            public ImageList imag;
            public List<Bludo> bludo_menu;
            public string name_menu;
            public Menu(ImageList img, List<Bludo> b, string n)
            {
                imag = img;
                bludo_menu = b;
                name_menu = n;
            }
        }

        static public Form1 frm1;
        static public but_del frm2;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm1 = new Form1();
           
            Application.Run(frm1);
        }
    }
}
