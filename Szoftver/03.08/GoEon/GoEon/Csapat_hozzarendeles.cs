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

        List<Feladatok> osszes_feladat = new List<Feladatok>();

        Fooldal fooldal_form;
        Belépő_oldal belepo_form;

        public Csapat_hozzarendeles(List<Feladatok> task_list, List<Team> team_list)
        {
            InitializeComponent();
            feladatok = task_list;
            csapatok = team_list;
            read_previously_added_tasks();
        }

        public Csapat_hozzarendeles(List<Feladatok> task_list, List<Team> team_list, Fooldal fooldal)
        {
            InitializeComponent();
            feladatok = task_list;
            csapatok = team_list;
            fooldal_form = fooldal;
            //belepo_form = belepo_oldal;

        }

        private void Csapat_hozzarendeles_Load(object sender, EventArgs e)
        {
            db.Read_Administraton(administrations);
            db.Read_Task(osszes_feladat);                     

            feltolt();

            //CSapat hozzárendelése listbox adatai:
            team_listBox_feltolt();
            load_feladatok_listBox();

            dateTimePicker.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;       
                                  
        }

        //Az korábban hozzárendelt feladatokat hozzárendeli a csapatokhoz
        void read_previously_added_tasks()
        {

            foreach(Team team in csapatok)
            {
                foreach(KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    foreach(Feladatok fe in kv.Value)
                    {
                        for(int x = feladatok.Count -1; x>=0; x--)
                        {
                            if (fe.getFeladat_neve().Equals(feladatok[x].getFeladat_neve()))
                            {
                                feladatok.RemoveAt(x);
                            }
                        }
                    }
                }
            }            
        }

        void not_added_tasks()
        {
            foreach (Administration ad in administrations)
            {
                foreach (int i in ad.task_id)
                {
                    for (int j = feladatok.Count - 1; j >= 0; j--)
                    {
                        if (feladatok[j].getID() == i)
                        {
                            feladatok.RemoveAt(j);
                        }
                    }
                }
            }              
        }



        //Feltölti feladatokkal a feladatok listBox-t a hozzárendelésnél
        public void load_feladatok_listBox()
        {
            not_added_tasks();
            tasks_listBox.Items.Clear();
            
            //tasks_listbox adatai:
            foreach (Feladatok it in feladatok)
            {
                tasks_listBox.Items.Add(it.getFeladat_neve());
            }
        }

        //Feltölti feladatokkal a feladatok listBox-t a hozzárendelésnél
        public void update(List<Feladatok> tasks, List<Team> teams)
        {
            feladatok = tasks;
            csapatok = teams;
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
                                        string date = dateTimePicker.Text;
                                        string csapat = team_listBox.SelectedItem.ToString();
                                        string feladat = tasks_listBox.SelectedItem.ToString();
                                        DialogResult warning = MessageBox.Show("Ön a következő hozzárendelés állította össze:\n" + "Dátum: " + date + "\nCsapat: " + csapat + "\nFeladat: " + feladat + "\n\nA hozzárendeléshez kattintson az \"OK\" gombra, a visszavonáshoz pedig a \"Mégse\" gombra!\n", "A hozzárendelés megtörtént", MessageBoxButtons.OKCancel);
                                        if(warning == DialogResult.OK)
                                        {
                                            team.addTask(dateTimePicker.Text.ToString(), fe);
                                        }
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
        
       private void team_listBox_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

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

                            if (szamol_eszkoz >= equip.Count && szamol_kepesites >= quali.Count)
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

                        var working_time = TimeSpan.FromMinutes(fe.getMunkaidoInMinute());
                        int ora = working_time.Hours;
                        int perc = working_time.Minutes;
                        feladatok_listBox.Items.Add("       Munkaidő: " + String.Format("{0} óra {1} perc", ora, perc));
                        
                        feladatok_listBox.Items.Add("");
                        feladahttps://www.youtube.com/watch?v=onGynY3EaL4tok_listBox.Items.Add("       A feladatelvégzéséhez szükséges eszköz(ök): ");

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

        
        private void veglegesites_button_Click(object sender, EventArgs e)
        {
            db.clear_task_management_table();

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
            Csapat_reszlet uj_form = new Csapat_reszlet(csapatok, emberek, jarmuvek, eszkozok, osszes_feladat, administrations);
            uj_form.Show();
        }

        private void feladat_reszletek_Button_Click(object sender, EventArgs e)
        {
            Feladat_részletek uj_form = new Feladat_részletek(feladatok, administrations, "Összes");
            uj_form.Show();
        }

        private void manager_button_Click(object sender, EventArgs e)
        {
            Hozzarendeles_kezeles uj_form = new Hozzarendeles_kezeles(csapatok, feladatok, this);
            uj_form.Show();
        }

        private void riport_button_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            List<string> date = new List<string>();

            foreach (Team team in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    if (!date.Contains(kv.Key.ToString()) && kv.Value.Count != 0) date.Add(kv.Key.ToString());
                }
            }

            date = date.OrderBy(f => f).ToList();

            foreach (string i in date)
            {
                sb.Append("\n" + i + ":\n");
                foreach (Team team in csapatok)
                {
                    foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                    {
                        if (kv.Key.ToString().Equals(i))
                        {
                            foreach (Feladatok fe in kv.Value)
                            {
                                sb.Append("     " + team.getTeam_name() + "\t" + fe.getFeladat_neve() + "\n");
                            }
                        }
                    }
                }
            }

            DialogResult riport = MessageBox.Show("Hozzárendelések:\n" + sb.ToString(), "Riport", MessageBoxButtons.OK);
        }
    }
}
