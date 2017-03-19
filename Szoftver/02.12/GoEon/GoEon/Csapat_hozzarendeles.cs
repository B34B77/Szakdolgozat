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
            DialogResult question = MessageBox.Show("Szeretné automatikus hozzárendelni a feladatokat a csapatokhoz?\n(Természetesen késöbbiekben ezt modósíthatja)\n", "Kérdés", MessageBoxButtons.YesNo);

            if (question == DialogResult.Yes)
            {
                task_management();
            }
            else if(question == DialogResult.No)
            {
                feladatok_load(type);
                feltolt();

                //CSapat hozzárendelése listbox adatai:
                team_listBox_feltolt();
                load_feladatok_listBox();
            }

            
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
                                    date_comboBox_contain(date);
                                    break;
                                }
                            }
                            //ha nem telt meg a csapat
                            else
                            {
                                te.addTask(date, fe);
                                feladatok.Remove(fe);
                                date_comboBox_contain(date);
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

        //Feltölti a feladatok listBoxot
        public void feladatok_load(string type)
        {
            feladatok_listBox.Items.Clear();
            administrations.Clear();

            db.Read_Administraton(administrations);

            if (type.Equals("Mai"))
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");

                feladatok_listBox.Items.Clear();

                foreach (Feladatok it in feladatok)
                {
                    if (it.getHatarido().Equals(today))
                    {
                        feladatok_listBox.Items.Add(it.getFeladat_neve());
                        feladatok_listBox.Items.Add("      Határidő: " + it.getHatarido());
                        feladatok_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                        feladatok_listBox.Items.Add("      Prioritás: " + it.getPrioritas());
                        feladatok_listBox.Items.Add(hozzarendeles_keres(it));
                        feladatok_listBox.Items.Add("\n");
                    }
                }
            }
            else
            {
                foreach (Feladatok it in feladatok)
                {
                    feladatok_listBox.Items.Add(it.getFeladat_neve());
                    feladatok_listBox.Items.Add("      Határidő: " + it.getHatarido());
                    feladatok_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    feladatok_listBox.Items.Add("      Prioritás:" + it.getPrioritas());
                    feladatok_listBox.Items.Add(hozzarendeles_keres(it));
                    feladatok_listBox.Items.Add("\n");
                }
            }

        }

        //feltölti a csapatok listBoxot és beolvassa az embereket, eszközöket, járműveket
        public void feltolt()
        {
            db.Read_Person(emberek);
            db.Read_Equipments(eszkozok);
            db.Read_Vehicle(jarmuvek);

            csapatok_listBox.Items.Clear();
            foreach (Team it in csapatok)
            {
                csapatok_listBox.Items.Add("- " + it.getTeam_name() + ":");

                csapatok_listBox.Items.Add("    Székhely: " + it.getCity());

                csapatok_listBox.Items.Add("    Eszköz:");
                foreach (int ot in it.equipments_id)
                {
                    foreach(Equipmet xt in eszkozok)
                    {
                        if(xt.getID().Equals(ot))
                        {
                            csapatok_listBox.Items.Add("        -" + xt.getName());
                        }
                    }
                    
                }
                csapatok_listBox.Items.Add("    Személy:");
                foreach (int ot in it.persons_id)
                {
                    foreach (Person xt in emberek)
                    {
                        if (ot == xt.getID())
                        {
                            csapatok_listBox.Items.Add("        -" + xt.getName());
                        }
                    }
                }
                csapatok_listBox.Items.Add("    Jármű:");
                foreach (int ot in it.vehicles_id)
                {
                    foreach (Vehicle xt in jarmuvek)
                    {
                        if (ot == xt.getID())
                        {
                            csapatok_listBox.Items.Add("        -" + xt.getVehicle_name());
                        }
                    }
                }
                csapatok_listBox.Items.Add("\n");
                csapatok_listBox.Items.Add("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
        }

        private void vissza_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void feladat_reszletek_Button_Click(object sender, EventArgs e)
        {
            Feladat_részletek uj_form = new Feladat_részletek(feladatok, administrations, "Összes");
            uj_form.Show();

        }

        private void összesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feladatok_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                feladatok_listBox.Items.Add(it.getFeladat_neve());
                feladatok_listBox.Items.Add("      Határidő: " + it.getHatarido());
                feladatok_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                feladatok_listBox.Items.Add("      Prioritás:" + it.getPrioritas());
                feladatok_listBox.Items.Add(hozzarendeles_keres(it));
                feladatok_listBox.Items.Add("\n");
            }
        }

        private void normálPriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feladatok_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Normál"))
                {
                    feladatok_listBox.Items.Add(it.getFeladat_neve());
                    feladatok_listBox.Items.Add("      Határidő: " + it.getHatarido());
                    feladatok_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    feladatok_listBox.Items.Add("      Prioritás:" + it.getPrioritas());
                    feladatok_listBox.Items.Add(hozzarendeles_keres(it));
                    feladatok_listBox.Items.Add("\n");
                }
            }
        }

        private void sügősFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feladatok_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Sürgős"))
                {
                    feladatok_listBox.Items.Add(it.getFeladat_neve());
                    feladatok_listBox.Items.Add("      Határidő: " + it.getHatarido());
                    feladatok_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    feladatok_listBox.Items.Add("      Prioritás:" + it.getPrioritas());
                    feladatok_listBox.Items.Add(hozzarendeles_keres(it));
                    feladatok_listBox.Items.Add("\n");
                }
            }
        }

        private void maiHatáridővelRendelkezőFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feladatok_listBox.Items.Clear();
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            foreach (Feladatok it in feladatok)
            {
                if (it.getHatarido().Equals(today))
                {
                    feladatok_listBox.Items.Add(it.getFeladat_neve());
                    feladatok_listBox.Items.Add("      Határidő: " + it.getHatarido());
                    feladatok_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    feladatok_listBox.Items.Add("      Prioritás: " + it.getPrioritas());
                    feladatok_listBox.Items.Add(hozzarendeles_keres(it));
                    feladatok_listBox.Items.Add("\n");
                }
            }
        }

        private void csapat_reszletel_Button_Click(object sender, EventArgs e)
        {
            Csapat_reszlet uj_form = new Csapat_reszlet(csapatok, emberek, jarmuvek, eszkozok, feladatok, administrations);
            uj_form.Show();
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

            if (tasks_listBox.SelectedItem != null && team_listBox.SelectedItem != null)
            {
                foreach(Team i in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(i.getTeam_name()))
                    {
                        foreach(Feladatok j in feladatok)
                        {
                            if (tasks_listBox.SelectedItem.Equals(j.getFeladat_neve()))
                            {
                                if(i.tasks.Count == 2)
                                {
                                    DialogResult warning = MessageBox.Show("A csapat kapacitása megtelt!\nNem rendelhető hozzájuk több feladat!\n", "Figyelmeztetés", MessageBoxButtons.OK);
                                    good = false;
                                }
                                else
                                {
                                    i.addTask(dateTimePicker.Text, j);
                                }                                    
                            }
                        }
                        
                    }
                }

                if (good)
                {
                    for (int i = feladatok.Count - 1; i >= 0; i--)
                    {
                        if (tasks_listBox.SelectedItem.Equals(feladatok[i].getFeladat_neve()))
                        {
                            feladatok.RemoveAt(i);
                        }
                    }

                    tasks_listBox.Items.Remove(tasks_listBox.SelectedItem);
                    date_comboBox_contain(dateTimePicker.Text);
                    feladatok_load(type);
                }
                
            }
            else if(team_listBox.SelectedItem == null)
            {
                DialogResult warning = MessageBox.Show("Válassza ki melyik csapathoz szeretné hozzárendelni a feladatot!\n", "Figyelmeztetés", MessageBoxButtons.OK);
            }
            team_listBox_feltolt();
        }


        //Ellenörzi, hogy a data_comboBox-ban szerepek-e már ez a dátum
        void date_comboBox_contain(string date)
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
        }
        
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
                        information_listBox.Items.Add(tavolsag_szamit(i.getCity()));
                        foreach (KeyValuePair<string, List<Feladatok>> x in i.tasks)
                        {
                            if (x.Key.Equals(date_comboBox.SelectedItem.ToString()))
                            {
                                foreach (Feladatok j in x.Value)
                                {
                                    team_task_listBox.Items.Add(j.getFeladat_neve());
                                    information_listBox.Items.Add("- " + j.getVaros() + ", " + j.getUtca() + " " + j.getHazszam());

                                    string address = j.getVaros() + ",+" + j.getUtca() + "+" + j.getHazszam();
                                    information_listBox.Items.Add(tavolsag_szamit(address));
                                }
                            }
                        }
                    }

                }
            }
        }

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

        private void team_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(date_comboBox.SelectedItem != null && team_listBox.SelectedItem != null)
            {
               team_information_feltolt();
            }
        }

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
        }

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
        }

        private void team_task_listBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.team_task_listBox.SelectedItem == null) return;
            this.team_task_listBox.DoDragDrop(this.team_task_listBox.SelectedItem, DragDropEffects.Move);
        }

        private void team_task_listBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

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
        }

        private void tasks_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            team_listBox.Items.Clear();

            equip.Clear();
            quali.Clear();
            vehic.Clear();

            if (tasks_listBox.SelectedItem != null)
            {
                foreach (Feladatok i in feladatok)
                {
                    if (tasks_listBox.SelectedItem.Equals(i.getFeladat_neve()))
                    {
                        foreach (string j in i.eszkozok)
                        {
                            equip.Add(j);
                        }

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
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void date_comboBox_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        private void veglegesites_button_Click(object sender, EventArgs e)
        {
            foreach(var item in date_comboBox.Items)
            {
                foreach(Team te in csapatok)
                {
                    foreach(KeyValuePair<string, List<Feladatok>> kv in te.tasks)
                    {
                        if (kv.Key.Equals(item.ToString()))
                        {
                            string date = item.ToString();
                            string team_name = te.getTeam_name();
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
                }
            }

            DialogResult done = MessageBox.Show("A hozzárendelések mentése megtörtént!\n", "Sikeres hozzárendelés", MessageBoxButtons.OK);
            if (done == DialogResult.OK)
            {
                this.Close();
            }

        }
      
    }
}
