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


namespace GoEon
{
    public partial class Fooldal : Form
    {
        Database_Manager db = new Database_Manager();

        List<Feladatok> feladatok = new List<Feladatok>();
        List<Team> csapatok = new List<Team>();
        List<Person> emberek = new List<Person>();
        List<Equipmet> eszkozok = new List<Equipmet>();
        List<Vehicle> jarmuvek = new List<Vehicle>();
        List<Administration> administrations = new List<Administration>();

        int _year;
        int _month;

        Belépő_oldal belepo_form;

        public Fooldal(Belépő_oldal form)
        {
            InitializeComponent();
            belepo_form = form;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            feltolt();
            calendar_handle();
            calendar_task_managment();
            calendar_desc_panel_green.BackColor = Color.Lime;
            calendar_desc_panel_orange.BackColor = Color.Orange;
            
        }

        public void calendar_handle()
        {
            calendar.Items.Clear();

            string month = DateTime.Now.ToString("MMMM");

            _year = DateTime.Now.Year;
            _month = DateTime.Now.Month;
            int days = DateTime.DaysInMonth(_year, _month);

            month_label.Text = month;

            for(int i = 1; i <= days; i++)
            {
                calendar.Items.Add(i.ToString());
            }
        }

        public void calendar_task_managment()
        {
            foreach(Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Normál"))
                {
                    string[] date = it.getHatarido().Split('-');

                    if (getMonth(month_label.Text.ToString()).Equals(date[1]))
                    {
                        foreach (ListViewItem x in calendar.Items)
                        {
                            if (date[2].Equals(x.Text))
                            {
                                if (x.ForeColor != Color.DarkOrange)
                                {
                                    x.ForeColor = Color.Lime;

                                }

                            }

                        }
                    }                    
                }
                else
                {
                    string[] date = it.getHatarido().Split('-');

                    if (getMonth(month_label.Text.ToString()).Equals(date[1]))
                    {
                        foreach (ListViewItem x in calendar.Items)
                        {
                            if (date[2].Equals(x.Text))
                            {
                                x.ForeColor = Color.DarkOrange;                              
                            }

                        }
                    }
                }
            }
        }

        public string getMonth(string month)
        {
            string _month = "";
            switch (month)
            {
                case "január":
                    _month = "01";
                    break;
                case "február":
                    _month = "02";
                    break;
                case "március":
                    _month = "03";
                    break;
                case "április":
                    _month = "04";
                    break;
                case "május":
                    _month = "05";
                    break;
                case "június":
                    _month = "06";
                    break;
                case "július":
                    _month = "07";
                    break;
                case "augusztus":
                    _month = "08";
                    break;
                case "szeptember":
                    _month = "09";
                    break;
                case "október":
                    _month = "10";
                    break;
                case "november":
                    _month = "11";
                    break;
                case "december":
                    _month = "12";
                    break;
            }

            return _month;           
        }

        public string getDay(string day)
        {
            string _day = "";

            if(Convert.ToInt32(day) < 10)
            {
                _day = "0" + day;
            }
            else
            {
                _day = day;
            }

            return _day;            
        }

        public void feltolt()
        {
            feladatok.Clear();
            db.Read_Administraton(administrations);
            db.Read_Task(feladatok);

            //Csapatoknak szükséges adatok betöltése
            db.Read_Person(emberek);
            db.Read_Vehicle(jarmuvek);
            db.Read_Equipments(eszkozok);

            csapatok.Clear();
            csapatok = db.Read_Team(csapatok);

            elvegzendo_feladatok_lista.Items.Clear();
            surgos_feladatok_lista.Items.Clear();
            csapatok_lista.Items.Clear();

            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Sürgős"))
                {
                    surgos_feladatok_lista.Items.Add(it.getFeladat_neve());
                    surgos_feladatok_lista.Items.Add("\tHatáridő: " + it.getHatarido());
                    surgos_feladatok_lista.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    surgos_feladatok_lista.Items.Add("\tPrioritás:" + it.getPrioritas());
                    surgos_feladatok_lista.Items.Add(hozzarendeles_keres(it));
                    surgos_feladatok_lista.Items.Add("\n");

                }
                else
                {
                    elvegzendo_feladatok_lista.Items.Add(it.getFeladat_neve());
                    elvegzendo_feladatok_lista.Items.Add("\tHatáridő: " + it.getHatarido());
                    elvegzendo_feladatok_lista.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    elvegzendo_feladatok_lista.Items.Add("\tPrioritás:" + it.getPrioritas());
                    elvegzendo_feladatok_lista.Items.Add(hozzarendeles_keres(it));
                    elvegzendo_feladatok_lista.Items.Add("\n");
                }
            }

            foreach (Team it in csapatok)
            {
                csapatok_lista.Items.Add("- " + it.getTeam_name() + ":");
                csapatok_lista.Items.Add("      Székhely: " + it.getCity());
                csapatok_lista.Items.Add("\n");
            }
        }

        //Ideiglenes, ha hozzáadtunk egy feladatot egy csapathoz akkor azok nem jelennek meg
        public void reload(List<Team> cslist)
        {
            feladatok.Clear();
            administrations.Clear();

            csapatok = cslist;

            db.Read_Administraton(administrations);
            db.Read_Task(feladatok);

            elvegzendo_feladatok_lista.Items.Clear();
            surgos_feladatok_lista.Items.Clear();
            csapatok_lista.Items.Clear();

            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Sürgős"))
                {
                    surgos_feladatok_lista.Items.Add(it.getFeladat_neve());
                    surgos_feladatok_lista.Items.Add("\tHatáridő: " + it.getHatarido());
                    surgos_feladatok_lista.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    surgos_feladatok_lista.Items.Add("\tPrioritás:" + it.getPrioritas());
                    surgos_feladatok_lista.Items.Add(hozzarendeles_keres(it));
                    surgos_feladatok_lista.Items.Add("\n");

                }
                else
                {
                    elvegzendo_feladatok_lista.Items.Add(it.getFeladat_neve());
                    elvegzendo_feladatok_lista.Items.Add("\tHatáridő: " + it.getHatarido());
                    elvegzendo_feladatok_lista.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    elvegzendo_feladatok_lista.Items.Add("\tPrioritás:" + it.getPrioritas());
                    elvegzendo_feladatok_lista.Items.Add(hozzarendeles_keres(it));
                    elvegzendo_feladatok_lista.Items.Add("\n");
                }
            }

            foreach (Team it in csapatok)
            {
                csapatok_lista.Items.Add("- " + it.getTeam_name() + ":");
                csapatok_lista.Items.Add("      Székhely: " + it.getCity());
                csapatok_lista.Items.Add("\n");
            }
        }

        //Megvizsgálja, hogy az adott feladat hozzá lett-e már rendelve valamelyik csapathoz, ha igen akkor visszaadja a csapat nevét és a dátumot
        string hozzarendeles_keres(Feladatok task)
        {
            string data = "\tHozzárendelve: -";
            foreach (Administration ad in administrations)
            {
                foreach (int i in ad.task_id)
                {
                    if (i == task.getID())
                    {
                        data = "\tHozzárendelve: " + ad.getTeam_name() + " (" + ad.getDate() + ")";
                    }
                }
            }

            return data;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vissza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void surgos_feladatok_lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void feladat_felvetel_Click(object sender, EventArgs e)
        {
            Uj_feladat_felvetele ujfeladat = new Uj_feladat_felvetele(this, belepo_form);
            ujfeladat.Show();
        }

        private void reszletek_normal_Button_Click(object sender, EventArgs e)
        {
            Feladat_részletek uj = new Feladat_részletek(feladatok, administrations, "Normál");
            uj.Show();
        }

        private void resztelek_surgos_Button_Click(object sender, EventArgs e)
        {
            Feladat_részletek uj = new Feladat_részletek(feladatok, administrations, "Sürgős");
            uj.Show();
        }

        private void csapat_hozzarendeles_Button_Click(object sender, EventArgs e)
        {
            Csapat_hozzarendeles uj = new Csapat_hozzarendeles(feladatok, csapatok, "Összes", this);
            uj.Show();

        }

        private void foward_button_Click(object sender, EventArgs e)
        {
            calendar.Items.Clear();

            if(_month + 1 > 12)
            {
                _month = 0;
                _year++;
            }
            month_label.Text = DateTime.Now.AddMonths(_month++).ToString("MMMM");

            int days = DateTime.DaysInMonth(_year, _month);
            for (int i = 1; i <= days; i++)
            {
                calendar.Items.Add(i.ToString());
            }

            calendar_task_managment();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            calendar.Items.Clear();
            int days;

            if (_month - 1 < 1)
            {
                _month = 12;
                _year--;
                days = DateTime.DaysInMonth(_year, _month);
                _month++;
                month_label.Text = DateTime.Now.AddMonths(--_month).ToString("MMMM");
            }
            else
            {
                days = DateTime.DaysInMonth(_year, _month);
                month_label.Text = DateTime.Now.AddMonths(--_month).ToString("MMMM");
            }

          

            for (int i = 1; i <= days; i++)
            {
                calendar.Items.Add(i.ToString());
            }

            calendar_task_managment();
        }

        private void calendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calendar.SelectedIndices.Count <= 0)
            {
                return;
            }

            if (calendar.SelectedItems != null)
            {
                string str = calendar.SelectedItems[0].Text.ToString();

                StringBuilder sb = new StringBuilder();

                foreach (Feladatok it in feladatok)
                {
                    string[] date = it.getHatarido().Split('-');

                    if(date[1].Equals(getMonth(month_label.Text.ToString())) && date[2].Equals(getDay(calendar.SelectedItems[0].Text.ToString())))
                    {
                        sb.Append(it.getFeladat_neve() + "\n" );
                    }                    
                }
                if (!sb.ToString().Equals(""))
                {
                    string message = "A mai határidővel rendelkező feladatok listája:\n\n" + sb;
                    DialogResult task = MessageBox.Show(message, "Feladatok listája", MessageBoxButtons.OK);

                    if (task == DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void csapat_reszlet_button_Click(object sender, EventArgs e)
        {
            Csapat_reszlet uj_form = new Csapat_reszlet(csapatok, emberek, jarmuvek, eszkozok, feladatok, administrations);
            uj_form.Show();
        }
    }
}
