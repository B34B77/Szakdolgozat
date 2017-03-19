using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml.Linq;

namespace GoEon
{
    public partial class Csapat_hozzarendeles : Form
    {
        List<Feladatok> feladatok = new List<Feladatok>();
        List<Team> csapatok = new List<Team>();
        List<Person> emberek = new List<Person>();
        List<Equipmet> eszkozok = new List<Equipmet>();
        List<Vehicle> jarmuvek = new List<Vehicle>();
        List<Administration> administrations = new List<Administration>();

        Database_Manager db = new Database_Manager();

        List<string> equip = new List<string>();
        List<string> quali = new List<string>();
        List<string> vehic = new List<string>();

        Fooldal fooldal_form;
        Belépő_oldal belepo_form;

        string type;
        public Csapat_hozzarendeles(List<Feladatok> task_list, List<Team> team_list, string type)
        {
            InitializeComponent();
            feladatok = task_list;
            csapatok = team_list;
            this.type = type;        
        }

        public Csapat_hozzarendeles(List<Feladatok> task_list, List<Team> team_list, string type, Fooldal fooldal)
        {
            InitializeComponent();
            feladatok = task_list;
            csapatok = team_list;
            db.Read_Administraton(administrations);
            this.type = type;
            fooldal_form = fooldal;
            //belepo_form = belepo_oldal;
        }

        private void Csapat_hozzarendeles_Load(object sender, EventArgs e)
        {
           
                feltolt();

                //CSapat hozzárendelése listbox adatai:
                team_listBox_feltolt();
                load_feladatok_listBox();
                      
        }

        //Feladatok hozzárendelése a csapatokhoz automatikusan
        void task_management()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            equip.Clear();
            quali.Clear();

            
            feltolt();

            //Automatikus hozzárendelés
            while(feladatok.Count > 0)
            {
                //List<Feladatok> task_list = feladatok.OrderBy(f=>f.getHatarido()).ToList();
                List<Feladatok> task_list = feladatok.OrderBy(f => f.getFeladat_neve()).ToList();

                foreach (Feladatok fe in task_list)
                {
                    foreach (string j in fe.eszkozok)
                    {
                        equip.Add(j);
                    }

                    foreach (string j in fe.kepesitesek)
                    {
                        quali.Add(j);
                    }
                    foreach (Team te in csapatok)
                    {
                        int szamol_eszkoz = 0;
                        int szamol_kepesites = 0;

                        //Vizsgál eszköz
                        foreach (int k in te.equipments_id)
                        {
                            foreach (Equipmet x in eszkozok)
                            {
                                if (x.getID() == k)
                                {
                                    foreach (string y in equip)
                                    {
                                        if (y.Equals(x.getName()))
                                        {
                                            szamol_eszkoz++;
                                        }
                                    }
                                }
                            }
                        }

                        //Vizsgál képesítés
                        foreach (int k in te.persons_id)
                        {
                            foreach (Person x in emberek)
                            {
                                if (x.getID() == k)
                                {
                                    foreach (string y in quali)
                                    {
                                        if (y.Equals(x.getQualification()))
                                        {
                                            szamol_kepesites++;
                                        }
                                    }
                                }
                            }
                        }

                        //Ha az eszközök és képesítés szempontjából is megfelel egy csapat akkor hozzárendelés
                        if (szamol_eszkoz == equip.Count && szamol_kepesites == quali.Count)
                        {
                            string date = "";

                            if (month < 10)
                            {
                                if (day < 10)
                                {
                                    date = year + "-0" + month + "-0" + day;
                                }
                                else
                                {
                                    date = year + "-0" + month + "-" + day;
                                }
                            }
                            else
                            {
                                if (day < 10)
                                {
                                    date = year + "-" + month + "-0" + day;
                                }
                                else
                                {
                                    date = year + "-" + month + "-" + day;
                                }

                            }

                            //ha megtelt a csapat
                            if (te.tasks.ContainsKey(date))
                            {
                                if (te.tasks[date].Count == 2)
                                {
                                    continue;                                    
                                }
                                else
                                {
                                    te.addTask(date, fe);
                                    feladatok.Remove(fe);
                                    break;
                                }
                            }
                            //ha nem telt meg a csapat
                            else
                            {
                                te.addTask(date, fe);
                                feladatok.Remove(fe);
                                break;

                            }
                        }

                    }
                    equip.Clear();
                    quali.Clear();
                }
                if (day+1 > DateTime.DaysInMonth(year,month))
                {
                    if (month + 1 > 12)
                    {
                        year++;
                        month = 1;
                        day = 1;
                    }
                    else
                    {
                        month++;
                        day = 1;
                    }
                }
                else
                {
                    day++;
                }
            }


            foreach (Feladatok it in feladatok)
            {
                feladatok_listBox.Items.Add(it.getFeladat_neve());
                feladatok_listBox.Items.Add("      Határidő: " + it.getHatarido());
                feladatok_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                feladatok_listBox.Items.Add("      Prioritás:" + it.getPrioritas());
                feladatok_listBox.Items.Add(hozzarendeles_keres(it));
                feladatok_listBox.Items.Add("\n");
            }

            //tasks_listbox adatai:
            foreach (Feladatok it in feladatok)
            {
                tasks_listBox.Items.Add(it.getFeladat_neve());
            }

        }


        //Feltölti feladatokkal a feladatok listBox-t a hozzárendelésnél
        public void load_feladatok_listBox()
        {
            tasks_listBox.Items.Clear();
            
            //tasks_listbox adatai:
            foreach (Feladatok it in feladatok)
            {
                tasks_listBox.Items.Add(it.getFeladat_neve());
            }
        }

        //Feltölti feladatokkal a feladatok listBox-t a hozzárendelésnél
        public void load_feladatok_listBox(List<Feladatok> tasks)
        {
            feladatok = tasks;
            tasks_listBox.Items.Clear();

            //tasks_listbox adatai:
            foreach (Feladatok it in feladatok)
            {
                tasks_listBox.Items.Add(it.getFeladat_neve());
            }
        }

        //Megvizsgálja, hogy az adott feladat hozzá lett-e már rendelve valamelyik csapathoz, ha igen akkor visszaadja a csapat nevét és a dátumot
        string hozzarendeles_keres(Feladatok task)
        {
            string data = "      Hozzárendelve: -";
            foreach (Administration ad in administrations)
            {
                foreach (int i in ad.task_id)
                {
                    if (i == task.getID())
                    {
                        data = "      Hozzárendelve: " + ad.getTeam_name() + " (" + ad.getDate() + ")";
                    }
                }
            }

            return data;
        }

        //feltölti a csapatok listBoxot és beolvassa az embereket, eszközöket, járműveket
        public void feltolt()
        {
            db.Read_Person(emberek);
            db.Read_Equipments(eszkozok);
            db.Read_Vehicle(jarmuvek);
        }

        private void vissza_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //Feltölti a team_listBox-ot a csapatok neveivel
        void team_listBox_feltolt()
        {
            team_listBox.Items.Clear();

            foreach (Team it in csapatok)
            {
                team_listBox.Items.Add(it.getTeam_name());
            }
        }

        private void hozzaad_button_Click(object sender, EventArgs e)
        {
            bool good = true;

            if (team_listBox.SelectedItem != null)
            {
                if (tasks_listBox.SelectedItem != null)
                {
                    foreach (Team team in csapatok)
                    {
                        if (team_listBox.SelectedItem.Equals(team.getTeam_name()))
                        {
                                  
                            if(team.tasks.Count == 2)
                            {
                                  DialogResult warning = MessageBox.Show("A csapat kapacitása megtelt!\nNem rendelhető hozzájuk több feladat!\n", "Figyelmeztetés", MessageBoxButtons.OK);
                                  good = false;
                            }                            
                            else
                            {
                                foreach (Feladatok fe in feladatok)
                                {
                                    if (fe.getFeladat_neve().Equals(tasks_listBox.SelectedItem))
                                    {
                                        team.addTask(dateTimePicker.Text.ToString(), fe);
                                    }
                                }

                            }
                        }
                    }

                    if (good)
                    {
                        for (int i = feladatok.Count - 1; i >= 0; i--)
                        {
                            if (feladatok[i].getFeladat_neve().Equals(tasks_listBox.SelectedItem))
                            {
                                feladatok.RemoveAt(i);
                            }
                        }
                        tasks_listBox.Items.Remove(tasks_listBox.SelectedItem);

                    }
                }
                else
                {
                    DialogResult warning = MessageBox.Show("Kérem válassza ki, hogy melyik feladatot szeretné hozzárendelni egy csapathoz!\n", "Hiba", MessageBoxButtons.OK);
                }
            }
            else
            {
                DialogResult warning = MessageBox.Show("Kérem válassza ki, hogy melyik csapat teljesítse a feladatot (a csapatok listájából)!\n", "Hiba", MessageBoxButtons.OK);
            }
        }


        //Ellenörzi, hogy a data_comboBox-ban szerepek-e már ez a dátum, ha nem akkor hozzáadja
     /*   public void date_comboBox_contain(string date)
        {
            bool contain = false;
            foreach (string st in date_comboBox.Items)
            {
                if (st.Equals(date))
                {
                    contain = true;
                }
            }
            if (!contain)
            {
                date_comboBox.Items.Add(date);
            }
        }*/
        /*
        void team_information_feltolt()
        {
            team_task_listBox.Items.Clear();
            information_listBox.Items.Clear();

            if (team_listBox.SelectedItem != null && date_comboBox.SelectedItem != null)
            {
                foreach (Team i in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(i.getTeam_name()))
                    {
                        information_listBox.Items.Add("Telephely: " + i.getCity());
                        information_listBox.Items.Add("\n");
                        information_listBox.Items.Add("Célállomások:");

                        string[] start = tavolsag_szamit(i.getCity()).Split(' ');

                        double start_lat = double.Parse(start[0], System.Globalization.CultureInfo.InvariantCulture);
                        double start_lng = double.Parse(start[1], System.Globalization.CultureInfo.InvariantCulture);

                        double depo_lat = start_lat;
                        double depo_lng = start_lng;

                        //Összesített távolság eltárolása
                        double tavolsag = 0.0;

                        foreach (KeyValuePair<string, List<Feladatok>> x in i.tasks)
                        {
                            if (x.Key.Equals(date_comboBox.SelectedItem.ToString()))
                            {
                                foreach (Feladatok j in x.Value)
                                {
                                    team_task_listBox.Items.Add(j.getFeladat_neve());
                                    information_listBox.Items.Add("- " + j.getVaros() + ", " + j.getUtca() + " " + j.getHazszam());

                                    //Latitude és Longitude
                                    string address = j.getVaros() + ",+" + j.getUtca() + "+" + j.getHazszam();

                                    string[] end = tavolsag_szamit(address).Split(' ');

                                    double end_lat = double.Parse(end[0], System.Globalization.CultureInfo.InvariantCulture);
                                    double end_lng = double.Parse(end[1], System.Globalization.CultureInfo.InvariantCulture);

                                    //távolság számítás..
                                    tavolsag = tavolsag + distance(start_lat, start_lng, end_lat, end_lng);
                                    //

                                    start_lat = end_lat;
                                    start_lng = end_lng;
                                }
                            }
                        }                        
                        tavolsag = tavolsag + distance(start_lat, start_lng, depo_lat, depo_lng);
                        tavolsag = tavolsag * 1.4;
                        information_listBox.Items.Add("\n");
                        information_listBox.Items.Add("Távolság: " + String.Format("{0:0.00}", tavolsag) + " km");

                        double sebesseg = 70; //70 km/h
                        double utazasi_ido = tavolsag / sebesseg;
                        utazasi_ido = utazasi_ido * 60; //Óra átalakítása percre

                        //Utazási idő számítás óra perc formátumban
                        var travel_time = TimeSpan.FromMinutes(utazasi_ido);
                        int ora = travel_time.Hours;
                        int perc = travel_time.Minutes;
                        information_listBox.Items.Add("Utazási idő: " + String.Format("{0} óra {1} perc", ora, perc));

                        utazasi_ido = utazasi_ido * 2;
                        travel_time = TimeSpan.FromMinutes(utazasi_ido);
                        ora = travel_time.Hours;
                        perc = travel_time.Minutes;
                        information_listBox.Items.Add("Teljes utazási idő (oda és vissza): " + String.Format("{0} óra {1} perc", ora, perc));
                    }

                }
            }
        }*/
        

        //Hosszasági és szélességi pont megadása
        string tavolsag_szamit(string address)
        {
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat");
            var lng = locationElement.Element("lng");

            //Latitude kiválasztása és eltárolása egy változóba
            int i = 0;
            while (!lat.ToString()[i].Equals('>'))
            {
                i++;
            }
            i++;
            string latitude = "";
            while (!lat.ToString()[i].Equals('<'))
            {
                latitude = string.Concat(latitude, lat.ToString()[i]);
                i++;
            }

            //Latitude kiválasztása és eltárolása egy változóba
            i = 0;
            while (!lng.ToString()[i].Equals('>'))
            {
                i++;
            }
            i++;
            string longitude = "";
            while (!lng.ToString()[i].Equals('<'))
            {
                longitude = string.Concat(longitude, lng.ToString()[i]);
                i++;
            }

            string lat_lng = lat.ToString() + lng.ToString();
            return latitude + " " + longitude;
        }

        //Távolság számítás két pont között
        double distance(double start_lat, double start_lng, double end_lat, double end_lng)
        {
            double theta = start_lng - end_lng;
            double dist = Math.Sin(deg2rad(start_lat)) * Math.Sin(deg2rad(end_lat)) + Math.Cos(deg2rad(start_lat)) * Math.Cos(deg2rad(end_lat)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;

            return dist;
        }

        //Fokot radiánra konvertálja
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //A radiánt fokra konvertálja vissza
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }


       private void team_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            if(date_comboBox.SelectedItem != null && team_listBox.SelectedItem != null)
            {
               team_information_feltolt();
            }*/
        }
        /*
        private void megjelenites_Button_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (team_listBox.SelectedItem != null)
            {
                foreach (Team i in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(i.getTeam_name()))
                    {                       
                        foreach(KeyValuePair<string, List<Feladatok>> j in i.tasks)
                        {
                            if(j.Key.Equals(date_comboBox.SelectedItem))
                            {
                                sb.Append("https://www.google.hu/maps/dir/" + i.getCity());
                                foreach (Feladatok x in j.Value)
                                {
                                    sb.Append("/" + x.getVaros() + ",+" + x.getUtca() + "+" + x.getHazszam());
                                }
                                sb.Append("/" + i.getCity());
                            }
                        }
                        
                    }
                }
                Terkep uj_form = new Terkep(sb.ToString());
                uj_form.Show();
            }
        }*/
/*
        private void task_delete_button_Click(object sender, EventArgs e)
        {
            if (team_task_listBox.SelectedItem != null)
            {
                foreach (Team i in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(i.getTeam_name()))
                    {
                        foreach(KeyValuePair<string, List<Feladatok>> kv in i.tasks)
                        {
                            foreach (Feladatok j in kv.Value)
                            {
                                if (team_task_listBox.SelectedItem.Equals(j.getFeladat_neve()))
                                {
                                    feladatok.Add(j);

                                }
                            }
                        }

                       

                        foreach (KeyValuePair<string, List<Feladatok>> kv in i.tasks)
                        {
                            for (int x = kv.Value.Count - 1; x >= 0; x--)
                            {
                                if (team_task_listBox.SelectedItem.Equals(kv.Value[x].getFeladat_neve()))
                                {
                                   kv.Value.RemoveAt(x);
                                }
                            }
                        }

                        team_task_listBox.Items.Remove(team_task_listBox.SelectedItem);
                        information_listBox.Items.Clear();
                        load_feladatok_listBox();
                        feladatok_load(type);
                    }
                }

            }
        }*/

   /*     private void team_task_listBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.team_task_listBox.SelectedItem == null) return;
            this.team_task_listBox.DoDragDrop(this.team_task_listBox.SelectedItem, DragDropEffects.Move);
        }  */

   /*     private void team_task_listBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        } */

        /*
        private void team_task_listBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = team_task_listBox.PointToClient(new Point(e.X, e.Y));

            int index = this.team_task_listBox.IndexFromPoint(point);

            if (index < 0)
            {
                index = this.team_task_listBox.Items.Count - 1;
            }
            
            object data = team_task_listBox.SelectedItem;
            this.team_task_listBox.Items.Remove(data);
            this.team_task_listBox.Items.Insert(index, data);

            List<Feladatok> help = new List<Feladatok>();

            foreach (Team it in csapatok)
            {
                if (it.getTeam_name().Equals(team_listBox.SelectedItem))
                {

                    foreach (string x in team_task_listBox.Items)
                    {                 
                        foreach(KeyValuePair<string, List<Feladatok>> y in it.tasks)
                        {
                            foreach (Feladatok ot in y.Value)
                            {
                                if (ot.getFeladat_neve().Equals(x))
                                {
                                    help.Add(ot);
                                }
                            }
                        }
                    }

                    it.tasks[date_comboBox.SelectedItem.ToString()] = help;

                }
            }
            team_information_feltolt();
        }*/

        private void tasks_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            team_listBox.Items.Clear();
            feladatok_listBox.Items.Clear();

            equip.Clear();
            quali.Clear();
            vehic.Clear();

            if (tasks_listBox.SelectedItem != null)
            {
                foreach (Feladatok i in feladatok)
                {
                    if (tasks_listBox.SelectedItem.Equals(i.getFeladat_neve()))
                    {
                        //A feladathoz szükséges eszközök
                        foreach (string j in i.eszkozok)
                        {
                            equip.Add(j);
                        }

                        //A feladathoz szükséges képesítések
                        foreach (string j in i.kepesitesek)
                        {
                            quali.Add(j);

                        }

                        foreach (Team j in csapatok)
                        {
                            int szamol_eszkoz = 0;
                            int szamol_kepesites = 0;

                            //Vizsgál eszköz
                            foreach (int k in j.equipments_id)
                            {
                                foreach (Equipmet x in eszkozok)
                                {
                                    if (x.getID() == k)
                                    {
                                        foreach (string y in equip)
                                        {
                                            if (y.Equals(x.getName()))
                                            {
                                                szamol_eszkoz++;
                                            }
                                        }
                                    }
                                }
                            }

                            //Vizsgál képesítés
                            foreach (int k in j.persons_id)
                            {
                                foreach (Person x in emberek)
                                {
                                    if (x.getID() == k)
                                    {
                                        foreach (string y in quali)
                                        {
                                            if (y.Equals(x.getQualification()))
                                            {
                                                szamol_kepesites++;
                                            }
                                        }
                                    }
                                }
                            }

                            if (szamol_eszkoz == equip.Count && szamol_kepesites == quali.Count)
                            {
                                team_listBox.Items.Add(j.getTeam_name());
                            }

                        }

                    }
                }

                //Az adott feladat részleteinek megjelenítése a feladatok listájában
                foreach(Feladatok fe in feladatok)
                {
                    if (fe.getFeladat_neve().Equals(tasks_listBox.SelectedItem))
                    {
                        feladatok_listBox.Items.Add(fe.getFeladat_neve());
                        feladatok_listBox.Items.Add("       Határidő: " + fe.getHatarido());
                        feladatok_listBox.Items.Add("       Prioritás: " + fe.getPrioritas());
                        feladatok_listBox.Items.Add("       Helyszín: " + fe.getVaros() + ", " + fe.getUtca() + " " + fe.getHazszam());
                        feladatok_listBox.Items.Add("       Munka elvégzéséhez szükséges becsült idő: " + fe.getMunkaido());
                        feladatok_listBox.Items.Add("");
                        feladatok_listBox.Items.Add("       A feladatelvégzéséhez szükséges eszköz(ök): ");

                        foreach (string eq in fe.eszkozok)
                        {
                            feladatok_listBox.Items.Add("           -" + eq);
                        }

                        feladatok_listBox.Items.Add("");
                        feladatok_listBox.Items.Add("       A feladatelvégzéséhez szükséges képesítés(ek): ");

                        foreach (string qu in fe.kepesitesek)
                        {
                            feladatok_listBox.Items.Add("           -" + qu);
                        }

                        feladatok_listBox.Items.Add("");
                        feladatok_listBox.Items.Add("       Leírás:");
                        feladatok_listBox.Items.Add("       " + fe.getLeiras());
                        feladatok_listBox.Items.Add("");
                        feladatok_listBox.Items.Add("       Megjegyzés:\n");
                        feladatok_listBox.Items.Add("       " + fe.getMegjegyzes());
                    }

                }               

            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

      /*  private void date_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            team_listBox.Items.Clear();
            team_task_listBox.Items.Clear();
            information_listBox.Items.Clear();
            foreach (Team te in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in te.tasks)
                {
                    if (kv.Key.Equals(date_comboBox.SelectedItem))
                    {
                        team_listBox.Items.Add(te.getTeam_name());
                    }
                }
            }
        }*/
        
        private void veglegesites_button_Click(object sender, EventArgs e)
        {
            foreach(Team team in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    string date = kv.Key.ToString();
                    string team_name = team.getTeam_name();
                    string task_id = "";

                    foreach (Feladatok fe in kv.Value)
                    {
                        task_id = string.Concat(task_id, fe.getID() + ",");
                    }

                    //ha az adott csapat esetében a hozzárendelt feladatok halmaza nem üres
                    if (!task_id.Equals(""))
                    {
                        db.add_item_task_management_table(date, team_name, task_id);
                    }

                }
            }

            DialogResult done = MessageBox.Show("A hozzárendelések mentése megtörtént!\n", "Sikeres hozzárendelés", MessageBoxButtons.OK);
            if (done == DialogResult.OK)
            {
                this.Close();
            }           

        }

        private void csapat_reszlet_button_Click(object sender, EventArgs e)
        {
            Csapat_reszlet uj_form = new Csapat_reszlet(csapatok, emberek, jarmuvek, eszkozok, feladatok, administrations);
            uj_form.Show();
        }

        private void feladat_reszletek_Button_Click(object sender, EventArgs e)
        {
            Feladat_részletek uj_form = new Feladat_részletek(feladatok, administrations, "Összes");
            uj_form.Show();
        }
    }
}
