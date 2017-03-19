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

        string type;
        public Csapat_hozzarendeles(List<Feladatok> task_list, List<Team> team_list, string type)
        {
            InitializeComponent();
            feladatok = task_list;
            csapatok = team_list;
            this.type = type;            
        }

        private void Csapat_hozzarendeles_Load(object sender, EventArgs e)
        {
           // TaskControll.TabPages.Clear();
            feltolt(type);
           // Task_control_handle();
        }

        public void feltolt(string type)
        {
            db.Read_Person(emberek);
            db.Read_Equipments(eszkozok);
            db.Read_Vehicle(jarmuvek);

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


            csapatok_listBox.Items.Clear();
            foreach (Team it in csapatok)
            {
                csapatok_listBox.Items.Add("- " + it.getTeam_name() + ":");

                //TabPage hozzáadása ahány csapat van
             /*   string tabPage_title = it.getTeam_name();
                TabPage new_page = new TabPage(tabPage_title);
                TaskControll.TabPages.Add(new_page);*/

                //Csapatnevek hozzárendelése a comboBox-hoz
                csapat_comboBox.Items.Add(it.getTeam_name());

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

   /*     //Minden TabPage-hez listbox rendelése
        public void Task_control_handle()
        {
            foreach(Control c in TaskControll.Controls)
            {
                if(c is TabPage)
                {
                    ListBox new_listbox = new ListBox();
                    new_listbox.Location = new System.Drawing.Point(15, 20);
                    new_listbox.Name = "listbox";
                    new_listbox.ScrollAlwaysVisible = true;
                    new_listbox.HorizontalScrollbar = true;
                    new_listbox.Size = new System.Drawing.Size(260, 130);
                    c.Controls.Add(new_listbox);

                }
            }
        }*/

        private void csapat_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> equip = new List<string>();
            if(csapat_comboBox.SelectedItem != null)
            {
                foreach(Team i in csapatok)
                {
                    if (csapat_comboBox.SelectedItem.Equals(i.getTeam_name()))
                    {
                        foreach(int j in i.equipments_id)
                        {
                            foreach(Equipmet k in eszkozok)
                            {
                                if(k.getID() == j)
                                {
                                    equip.Add(k.getName()); 
                                }
                            }
                        }
                    }
                }

                bool contain = false;
                foreach(Feladatok i in feladatok)
                {
                    foreach(string j in i.eszkozok)
                    {
                        foreach(string k in equip)
                        {
                            if (j.Equals(k))
                            {
                                contain = true;
                            }
                            else
                            {
                                contain = false;
                            }
                        }
                    }

                    if(contain == true)
                    {
                        feladatok_comboBox.Items.Add(i.getFeladat_neve());
                    }
                }


            }
        }

        private void hozzaad_button_Click(object sender, EventArgs e)
        {
           
        }


    }
}
