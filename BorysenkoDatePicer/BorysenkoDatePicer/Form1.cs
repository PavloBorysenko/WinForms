using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace BorysenkoDatePicer
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        class UnoEvent {
            public string ev_text{get;set;}
            public DateTime ev_time { get; set; }
            public bool checked_ev;
            public UnoEvent(string s, DateTime d) {
                ev_text = s;
                ev_time = d;
                checked_ev = true;
                
            }
            public string Print() {
                return "Событие: " +" Дата:" + ev_time.ToShortDateString()+
                    " На: "+ev_time.ToShortTimeString();
            }

        }
        
        class DeyEvent { 
        public List<UnoEvent> dey_ev_list;
        public DateTime ev_dey { get; set; }

        public DeyEvent(string s, DateTime d) {
            dey_ev_list = new List<UnoEvent>();
            ev_dey = d;
            dey_ev_list.Add(new UnoEvent(s, d));
        }
        public DeyEvent(DateTime d) {
            dey_ev_list = new List<UnoEvent>();
            ev_dey = d;
        }

          
        }

        class Ergo { 
         public List<DeyEvent> ergonaz = new List<DeyEvent>();
         NotifyIcon tip;
         //public List<UnoEvent> dey_ = new List<UnoEvent>();
            //public void addnewdey(string s,DateTime d){
            //ergonaz.Add(new DeyEvent(d).dey_ev_list.Add(new UnoEvent(s,d)))

            
            
            //}
        public int search(DateTime d) { 
       
            for(int i=0;i<ergonaz.Count;i++ ){
                if (ergonaz[i].ev_dey.Date==d.Date) {
                    return i; 
                }
            }

        return -1;
        }
        public void marcer(MonthCalendar cal) {
            foreach (DeyEvent item in ergonaz)
            {

                cal.AddAnnuallyBoldedDate(item.ev_dey);

            }
        }
        public void Dzin(NotifyIcon t) {
           // aTimer.Stop();
            int c = 0;
            tip = t;
           // dey_=new List<UnoEvent>();
            for (int i=0; i < ergonaz.Count; i++) {
                if (DateTime.Now.Day == ergonaz[i].ev_dey.Day && DateTime.Now.Month == ergonaz[i].ev_dey.Month) {
                   
                  //  dey_ = ergonaz[i].dey_ev_list;
                    for (int j = 0; j < ergonaz[i].dey_ev_list.Count; j++) {
                        if (ergonaz[i].dey_ev_list[j].checked_ev == true) { 
                        SetTimer(); c++;
                        
                        }
                    
                    }
                    
                    break;
                }
            
            }
            MessageBox.Show("У Вас на сегодня "+c+" задач(а)! ");
            if (c > 0) {
                
            }
        }
        public void go() {
           
            int rul = 0;
            for (int i = 0; i <ergonaz.Count;i++ )
            {
                if (DateTime.Now.Date == ergonaz[i].ev_dey.Date )
                {
                    for (int j = 0; j < ergonaz[i].dey_ev_list.Count;j++ )
                    {


                        if ((DateTime.Now.Hour > ergonaz[i].dey_ev_list[j].ev_time.Hour) && ergonaz[i].dey_ev_list[j].checked_ev==true)
                        {
                        
                            ergonaz[i].dey_ev_list[j].checked_ev = false; 
                            tip.BalloonTipText = ergonaz[i].dey_ev_list[j].ev_text;
                            tip.BalloonTipTitle = ergonaz[i].dey_ev_list[j].Print();
                            tip.ShowBalloonTip(5000);
                          
                        }
                        else if ((DateTime.Now.Hour == ergonaz[i].dey_ev_list[j].ev_time.Hour) && ergonaz[i].dey_ev_list[j].checked_ev == true)
                        {
                            if ((DateTime.Now.Minute >= ergonaz[i].dey_ev_list[j].ev_time.Minute) && ergonaz[i].dey_ev_list[j].checked_ev == true)
                            {

                                ergonaz[i].dey_ev_list[j].checked_ev = false;
                                tip.BalloonTipText = ergonaz[i].dey_ev_list[j].ev_text;
                                tip.BalloonTipTitle = ergonaz[i].dey_ev_list[j].Print();
                                tip.ShowBalloonTip(5000);
                            
                            }
                        
                        
                        }
                        if (ergonaz[i].dey_ev_list[j].checked_ev == true) {
                            rul++;
                        }
                        if (rul == 0) {
                            
                            aTimer.Dispose();
                            //MessageBox.Show("Все задачи на сегодня выполнены");
                        }
                    }


                }
              
                //if (DateTime.Now.Hour > dey_[i].ev_time.Hour && DateTime.Now.Minute > dey_[i].ev_time.Minute) {
                //    dey_.RemoveAt(i);
                //    if (dey_.Count <= 0) {
                //        aTimer.Dispose();
                //    }
                //}
            }
        }
        }

       static Ergo date_ergo = new Ergo();

        public DateTime date_picker = new DateTime();
        public int Ind = -1;
        public int Ind_ev = -1;
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(6000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            date_ergo.go();
        }  
     
        public Form1()
        {
            InitializeComponent();
            date_ergo.ergonaz.Add(new DeyEvent(new DateTime(2015, 11, 20)));
            date_ergo.ergonaz.Add(new DeyEvent(new DateTime(2015, 12, 1)));
            date_ergo.ergonaz.Add(new DeyEvent(new DateTime(2015, 11, 30)));
            date_ergo.ergonaz.Add(new DeyEvent(new DateTime(2015, 11, 27)));
            date_ergo.ergonaz.Add(new DeyEvent(new DateTime(2015, 11, 28)));
            date_ergo.ergonaz.Add(new DeyEvent(new DateTime(2015, 11, 26)));

            date_ergo.ergonaz[0].dey_ev_list.Add(new UnoEvent(" 1 Надо сделать", new DateTime(2015, 11, 20,8,30,30)));
            date_ergo.ergonaz[0].dey_ev_list.Add(new UnoEvent(" 2 Надо сделать", new DateTime(2015, 11, 20, 12, 36, 30)));
            date_ergo.ergonaz[1].dey_ev_list.Add(new UnoEvent(" 3 Надо сделать", new DateTime(2015, 12, 1, 13, 00, 30)));
            date_ergo.ergonaz[2].dey_ev_list.Add(new UnoEvent(" 4 Надо сделать", new DateTime(2015, 11, 30, 9, 30, 30)));
            date_ergo.ergonaz[2].dey_ev_list.Add(new UnoEvent(" 5 Надо сделать", new DateTime(2015, 11, 30, 14, 40, 30)));
            date_ergo.ergonaz[2].dey_ev_list.Add(new UnoEvent(" 6 Надо cделать", new DateTime(2015, 11, 30, 21, 15, 30)));
            date_ergo.ergonaz[2].dey_ev_list.Add(new UnoEvent(" 7 Надо сделать", new DateTime(2015, 11, 30, 23, 00, 30)));
            date_ergo.ergonaz[3].dey_ev_list.Add(new UnoEvent(" 8 Надо сделать", new DateTime(2015, 11, 27, 10, 30, 30)));
            date_ergo.ergonaz[3].dey_ev_list.Add(new UnoEvent(" 9 Надо сделать", new DateTime(2015, 11, 27, 21, 20, 30)));
            date_ergo.ergonaz[4].dey_ev_list.Add(new UnoEvent(" 10 Надо сделать", new DateTime(2015, 11, 28, 06, 50, 30)));
            date_ergo.ergonaz[5].dey_ev_list.Add(new UnoEvent(" 8 Надо сделать", new DateTime(2015, 11, 26, 12, 40, 30)));
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();
            date_ergo.marcer(monthCalendar1);
            date_ergo.Dzin(notifyIcon1);
           monthCalendar1.SetDate(DateTime.Now);
            monthCalendar1.RemoveAnnuallyBoldedDate(new DateTime(2015, 11, 17));
        }
        private DateTimePicker timePicker;

        private void InitializeTimePicker()
        {
            timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(100, 100);
            timePicker.Width = 100;
            Controls.Add(timePicker);
        }
      
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();
            listBox1.Items.Clear();
            int index = date_ergo.search(e.Start);
           // MessageBox.Show(index.ToString());
            if (index >= 0)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                Ind = index;
                
                foreach (UnoEvent item in date_ergo.ergonaz[index].dey_ev_list)
                {
                    listBox1.Items.Add(item.Print());

                }
                listBox1.SelectedIndex = 0;
            }else{
                date_picker = e.Start;
                button2.Enabled = false;
                button3.Enabled = false;
                Ind = index;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();
            int i = listBox1.SelectedIndex;
           textBox1.Text=date_ergo.ergonaz[Ind].dey_ev_list[i].ev_text;
           Ind_ev = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();
            if (Ind < 0)
            {
                dateTimePicker1.Value = date_picker;
               // MessageBox.Show(date_picker.ToShortDateString());
            }
            else {
                dateTimePicker1.Value = date_ergo.ergonaz[Ind].ev_dey;
            }
            
            textBox2.Show();
            textBox2.Text = "Текст";
            dateTimePicker1.Show();
            addbutt.Show();
        }

        private void addbutt_Click(object sender, EventArgs e)
        {
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();
            if (Ind < 0)
            {
                
                date_ergo.ergonaz.Add(new DeyEvent(textBox2.Text, dateTimePicker1.Value));
               // date_ergo.marcer(monthCalendar1, dateTimePicker1.Value);
                monthCalendar1.AddAnnuallyBoldedDate(dateTimePicker1.Value);
                monthCalendar1.UpdateBoldedDates();
               // MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
              // monthCalendar1.BoldedDates=(new DateTime(2015,11,11));
               // date_ergo.marcer(monthCalendar1);
               // MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
            }
            else {
                date_ergo.ergonaz[Ind].dey_ev_list.Add(new UnoEvent(textBox2.Text, dateTimePicker1.Value));
                date_ergo.marcer(monthCalendar1);
                //MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
            }
            monthCalendar1.SetDate(dateTimePicker1.Value);
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();
            date_ergo.Dzin(notifyIcon1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();


            dateTimePicker1.Value = date_ergo.ergonaz[Ind].dey_ev_list[Ind_ev].ev_time;

            textBox2.Show();
            textBox2.Text = date_ergo.ergonaz[Ind].dey_ev_list[Ind_ev].ev_text;
            dateTimePicker1.Show();
            Upbut.Show();
        }

        private void Upbut_Click(object sender, EventArgs e)
        {
            textBox2.Hide();
            dateTimePicker1.Hide();
            addbutt.Hide();
            Upbut.Hide();
            //textBox2.Text, dateTimePicker1.Value;
            int i = Ind_ev;
            date_ergo.ergonaz[Ind].dey_ev_list[Ind_ev].ev_text = textBox2.Text;
            date_ergo.ergonaz[Ind].dey_ev_list[Ind_ev].ev_time = dateTimePicker1.Value;

            monthCalendar1.SetDate(dateTimePicker1.Value);

            textBox2.Hide();
            dateTimePicker1.Hide();
            Upbut.Hide();
            date_ergo.Dzin(notifyIcon1);
            listBox1.SelectedIndex = i;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            date_ergo.ergonaz[Ind].dey_ev_list.RemoveAt(Ind_ev);
         //  monthCalendar1.SetDate(date_ergo.ergonaz[Ind].ev_dey);
           DateTime temp = date_ergo.ergonaz[Ind].ev_dey;
         //  MessageBox.Show(date_ergo.ergonaz[Ind].dey_ev_list.Count.ToString());
            if(date_ergo.ergonaz[Ind].dey_ev_list.Count<=0)
            {
                
                monthCalendar1.RemoveAnnuallyBoldedDate(date_ergo.ergonaz[Ind].ev_dey.Date);
                 
                date_ergo.ergonaz.RemoveAt(Ind);
               // MessageBox.Show(Ind.ToString());
                
                monthCalendar1.RemoveAllBoldedDates();
                monthCalendar1.UpdateBoldedDates();
                //date_ergo.marcer(monthCalendar1);
            }
            monthCalendar1.SetDate(temp);
            textBox2.Hide();
            dateTimePicker1.Hide();
            Upbut.Hide();
            date_ergo.Dzin(notifyIcon1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            notifyIcon2.BalloonTipText = "Info fron our app";
            notifyIcon2.BalloonTipTitle = "Info title";
            notifyIcon2.ShowBalloonTip(5);
        }

       
    }
}
