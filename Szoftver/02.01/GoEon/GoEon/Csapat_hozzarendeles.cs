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

        Database_Manager db = new Database_Manager();

        List<string> equip = new List<string>();
        List<string> quali = new List<string>();
        List<string> vehic = new List<string>();

        string type;
        public Csapat_hozzarendeles(List<Feladatok> task_list, List<Team> team_list, string type)
        {
            InitializeComponent();
            feladatok = task_list;
            csapatok = team_list;
            this.type = type;        
        }

       /* public Csapat_hozzarendeles(List<Feladatok> task_list, List<Team> team_list, string type, Belépő_oldal belepo_oldal, Fooldal fooldal)
        {
            InitializeComponent();
            feladatok = task_list;
            csapatok = team_list;
            this.type = type;
            fooldal_form = fooldal;
            belepo_form = belepo_oldal;
        }*/

        private void Csapat_hozzarendeles_Load(object sender, EventArgs e)
        {
            feladatok_load(type);
            feltolt();

            //CSapatjozzárendelése listbox adatai:
            team_listBox_feltolt();
            load_feladatok_listBox();
            
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

        public void feladatok_load(string type)
        {
            feladatok_listBox.Items.Clear();
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
                    feladatok_listBox.Items.Add("\n");
                }
            }

        }

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
                csapatok_listBox.Items.Add("    Ember:");
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
            Feladat_részletek uj_form = new Feladat_részletek(feladatok, "Összes");
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
                    feladatok_listBox.Items.Add("\n");
                }
            }
        }

        private void csapat_reszletel_Button_Click(object sender, EventArgs e)
        {
            Csapat_reszlet uj_form = new Csapat_reszlet(csapatok, emberek, jarmuvek, eszkozok);
            uj_form.Show();
        }

        //private void feladatok_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    csapat_comboBox.Text = "";
        //    csapat_comboBox.Items.Clear();
        
        //    equip.Clear();
        //    quali.Clear();
        //    vehic.Clear();

        //    if(feladatok_comboBox.SelectedItem != null)
        //    {
        //        foreach(Feladatok i in feladatok)
        //        {
        //            if (feladatok_comboBox.SelectedItem.Equals(i.getFeladat_neve()))
        //            {
        //                foreach (string j in i.eszkozok)
        //                {
        //                        equip.Add(j);
        //                        //csapat_comboBox.Items.Add(j);
        //                }

        //                foreach (string j in i.kepesitesek)
        //                {
        //                        quali.Add(j);
        //                        //csapat_comboBox.Items.Add(j);                               

        //                }

        //                foreach(Team j in csapatok)
        //                {
        //                    int szamol_eszkoz = 0;
        //                    int szamol_kepesites = 0;

        //                    //Vizsgál eszköz
        //                    foreach (int k in j.equipments_id)
        //                    {
        //                        foreach(Equipmet x in eszkozok)
        //                        {
        //                            if (x.getID() == k)
        //                            {
        //                                foreach (string y in equip)
        //                                {
        //                                    if (y.Equals(x.getName()))
        //                                    {
        //                                        szamol_eszkoz++;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }

        //                    //Vizsgál képesítés
        //                    foreach (int k in j.persons_id)
        //                    {
        //                        foreach (Person x in emberek)
        //                        {
        //                            if (x.getID() == k)
        //                            {
        //                                foreach (string y in quali)
        //                                {
        //                                    if (y.Equals(x.getQualification()))
        //                                    {
        //                                        szamol_kepesites++;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }

        //                    if (szamol_eszkoz == equip.Count && szamol_kepesites == quali.Count)
        //                    {
        //                        csapat_comboBox.Items.Add(j.getTeam_name());
        //                    }

        //                }

        //            }
        //        }
        //    }
            
        //}


 
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
                    date_comboBox_contain();
                    feladatok_load(type);
                }
                
            }
            team_listBox_feltolt();
        }


        //Ellenörzi, hogy a data_comboBox-ban szerepek-e már ez a dátum
        void date_comboBox_contain()
        {
            bool contain = false;
            foreach (string st in date_comboBox.Items)
            {
                if (st.Equals(dateTimePicker.Text))
                {
                    contain = true;
                }
            }
            if (!contain)
            {
                date_comboBox.Items.Add(dateTimePicker.Text);
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
                        foreach (KeyValuePair<string, List<Feladatok>> x in i.tasks)
                        {
                            if (x.Key.Equals(date_comboBox.SelectedItem.ToString()))
                            {
                                foreach (Feladatok j in x.Value)
                                {
                                    team_task_listBox.Items.Add(j.getFeladat_neve());
                                    information_listBox.Items.Add("- " + j.getVaros() + ", " + j.getUtca() + " " + j.getHazszam());
                                }
                            }
                        }
                    }
                }
            }
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
                        sb.Append("https://www.google.hu/maps/dir/" + i.getCity());
                        foreach(KeyValuePair<string, List<Feladatok>> j in i.tasks)
                        {
                            foreach(Feladatok x in j.Value)
                            {
                                sb.Append("/" + x.getVaros() + ",+" + x.getUtca() + "+" + x.getHazszam());
                            }
                        }
                        sb.Append("/" + i.getCity());
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
    }
}
