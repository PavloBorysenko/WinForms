using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BorysekoExamAdoNet
{



    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "hokey";
        private string uid = "hokey";
        private string password = "";
        private string connectionString;

        private BindingSource timeBindingSource = new BindingSource();
        private BindingSource timeTimeInfoBindingSource = new BindingSource();
        private BindingSource timePlayerBindingSource = new BindingSource();
        private BindingSource PlayerInfoBindingSource = new BindingSource();

       private DataSet data = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";";

                connection = new MySqlConnection(connectionString);

                

                MySqlDataAdapter masterDataAdapter = new MySqlDataAdapter("select * from time", connection);
                masterDataAdapter.Fill(data, "time");

                MySqlDataAdapter detailsDataAdapter = new MySqlDataAdapter("select * from infotim", connection);
                detailsDataAdapter.Fill(data, "infotim");

                MySqlDataAdapter playerDataAdapter = new MySqlDataAdapter("select * from player", connection);
                playerDataAdapter.Fill(data, "player");

                MySqlDataAdapter playerinfoDataAdapter = new MySqlDataAdapter("select * from infoplayer", connection);
                playerinfoDataAdapter.Fill(data, "infoplayer");


                MySqlDataAdapter turnirDataAdapter = new MySqlDataAdapter("select * from turnir", connection);
                turnirDataAdapter.Fill(data, "turnir");


                DataRelation relation = new DataRelation("timeInfo",
                    data.Tables["time"].Columns["id"],
                    data.Tables["infotim"].Columns["id_time"]);
                data.Relations.Add(relation);

                DataRelation relation3 = new DataRelation("timeturnir",
                   data.Tables["time"].Columns["id"],
                   data.Tables["turnir"].Columns["id_time1"]);
                data.Relations.Add(relation3);

                DataRelation relation4 = new DataRelation("timeturnir2",
                   data.Tables["time"].Columns["id"],
                   data.Tables["turnir"].Columns["id_time2"]);
                data.Relations.Add(relation4);

                DataRelation relation1 = new DataRelation("timePlayer",
                   data.Tables["time"].Columns["id"],
                   data.Tables["player"].Columns["id_time"]);
                data.Relations.Add(relation1);

                DataRelation relation2 = new DataRelation("PlayerInfo",
              data.Tables["player"].Columns["id"],
              data.Tables["infoplayer"].Columns["id_player"]);
                data.Relations.Add(relation2);


                timeBindingSource.DataSource = data;
                timeBindingSource.DataMember = "time";

                timeTimeInfoBindingSource.DataSource = timeBindingSource;
                timeTimeInfoBindingSource.DataMember = "timeInfo";

                timePlayerBindingSource.DataSource = timeBindingSource;
                timePlayerBindingSource.DataMember = "timePlayer";

                PlayerInfoBindingSource.DataSource = timePlayerBindingSource;
                PlayerInfoBindingSource.DataMember = "PlayerInfo";

                Print_etap("А", etap1);
                Print_etap("В", etap2);
                Print_etap("С", etap3);
                Print_etap("D", etap4);
            }
            catch (MySqlException eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimeTable.DataSource = timeBindingSource;
            InfoTimeTable.DataSource = timeTimeInfoBindingSource;
            TablePlayer.DataSource = timePlayerBindingSource;
            TableInfoPlayer.DataSource = PlayerInfoBindingSource;




        }

        private void TimeTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableInfoPlayer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //void Print_finsl(string s1, string s2, int i, ListBox text)
        //{

        //    var query = from inf in data.Tables["infotim"].AsEnumerable()
        //                from tur in data.Tables["turnir"].AsEnumerable()
                   
        //                where (string)tur["grup"] == s1
        //                group inf by (int)inf["id_time"]== (int)tur["id_time1"] into m

        //               let maxc=m.Max(inf=>(int)inf["count"])

        //                select new { 
        //                     Champion= m.Where(inf=>(int)inf["count"]==maxc)
                        
        //                };


        
        //} 
        void Print_etap(string i, ListBox text) {

            try
            {
                var query = from tim in data.Tables["time"].AsEnumerable()
                            from tur in data.Tables["turnir"].AsEnumerable()
                            from tim2 in data.Tables["time"].AsEnumerable()
                            where (string)tur["grup"] == i
                            where (int)tur["id_time1"] == (int)tim["id"]
                            where (int)tur["id_time2"] == (int)tim2["id"]
                            select  new {  Grup = tur["grup"], Time1 = tim["name"], Time2 = tim2["name"], Count1=tur["count1"], Count2=tur["count2"], Rez=tur["rez"]};


                foreach (var etap in query)
                {  string c ="Не сыгран";
                if ((int)etap.Rez > 0)
                {
                    c = etap.Count1 + ":" + etap.Count1;
                }
                    string s = " " + etap.Time1 + " ^ " + etap.Time2 + "   " + c;
                    text.Items.Add(s);
                   
                }
            }
            catch (MySqlException eee)
            {
                MessageBox.Show(eee.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
