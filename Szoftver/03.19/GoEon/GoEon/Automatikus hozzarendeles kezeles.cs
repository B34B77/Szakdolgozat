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
    public partial class Automatikus_hozzarendeles_kezeles : Form
    {
        List<Team> now_added = new List<Team>();
        
        List<Administration> administrations = new List<Administration>();

        List<Feladatok> feladatok = new List<Feladatok>();
        List<Feladatok> not_added_task = new List<Feladatok>();
        List<Team> csapatok = new List<Team>();
        List<Person> emberek = new List<Person>();
        List<Equipmet> eszkozok = new List<Equipmet>(); 

        Database_Manager db = new Database_Manager();

        List<string> equip = new List<string>();
        List<string> quali = new List<string>();
        List<string> vehic = new List<string>();

        public Automatikus_hozzarendeles_kezeles()
        {
            InitializeComponent();
        }

        private void Automatikus_hozzarendeles_kezeles_Load(object sender, EventArgs e)
        {

            now_added = DataManager.BeolvasCsapatok_FeladatokkalEgyutt(now_added);

            feladatok = DataManager.HozzarendelesreVaroFeladatok(feladatok);
            administrations = DataManager.BeolvasAdministration(administrations);
            csapatok = DataManager.BeolvasCsapatok_FeladatokkalEgyutt(csapatok);
            emberek = DataManager.BeolvasKEmberek(emberek);
            eszkozok = DataManager.BeolvasEszkozok(eszkozok);

            task_management(now_added);
            now_added = remove_previosly_added_task(now_added);

            dataGridView.Columns.Add("Datum", "Várható teljesítés dátuma");
            dataGridView.Columns.Add("Csapat", "Csapat neve");
            dataGridView.Columns.Add("Feladat", "Feladat neve");

            DataGridViewCheckBoxColumn ok = new DataGridViewCheckBoxColumn();
            ok.HeaderText = "Hozzárendel";
            ok.Name = "CheckBox_Column";
            ok.FalseValue = false;
            ok.TrueValue = true;
            dataGridView.Columns.Add(ok);

            dataGridView_feltolt();

        }

        //Feladatok hozzárendelése a csapatokhoz automatikusan
        void task_management(List<Team> teams)
        {
            
            not_added_task = DataManager.HozzarendelesreVaroFeladatok(not_added_task);

            int counter = 0;

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            equip.Clear();
            quali.Clear();

            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = not_added_task.Count;

            //Automatikus hozzárendelés
            while (not_added_task.Count > 0)
            {
                List<Feladatok> task_list = not_added_task.OrderBy(f => f.getHatarido()).ToList();

                // List<Feladatok> task_list = feladatok.OrderBy(f=>f.getHatarido()).ToList();
                // List<Feladatok> task_list = feladatok.OrderBy(f => f.getFeladat_neve()).ToList();

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
                    foreach (Team te in teams)
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
                                    not_added_task.Remove(fe);
                                    progressBar.PerformStep();
                                    break;
                                }
                            }
                            //ha nem telt meg a csapat
                            else
                            {
                                te.addTask(date, fe);
                                not_added_task.Remove(fe);
                                progressBar.PerformStep();
                                break;

                            }
                        }

                    }
                    equip.Clear();
                    quali.Clear();
                }
                if (day + 1 > DateTime.DaysInMonth(year, month))
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

                counter++;

                if (counter > 10)
                {

                    DialogResult warning = MessageBox.Show("A következő 10 napra egyik csapathoz sem sikerült hozzárendelni egy (vagy több) feladatot.\n\n" +
                        "Valószínűsíthetően azért, mert egyik csapat sem képes elvégezni, eszköz, és/vagy képseítés hiány következtében\n\n" +
                        "Kérem ellenőrizze!\n", "Hiba", MessageBoxButtons.OK);

                    break;

                }
            }

           // progressBar.Visible = false;
        }




        //Kitörli azokat a feladatokat a csapatok dictionary-ból, amik ár hozzá lettek rendelve másik csapathoz
        List<Team> remove_previosly_added_task(List<Team> team)
        {
        
            foreach (Administration ad in administrations)
            {
                foreach (Team t in team)
                {
                    if (t.getTeam_name().Equals(ad.getTeam_name()))
                    {
                        foreach (KeyValuePair<string, List<Feladatok>> kv in t.tasks)
                        {
                            if (kv.Key.ToString().Equals(ad.getDate()))
                            {
                                foreach (int i in ad.task_id)
                                {
                                    for (int x = kv.Value.Count - 1; x >= 0; x--)
                                    {
                                        if (kv.Value[x].getID() == i)
                                        {
                                            kv.Value.RemoveAt(x);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }

            return team;
        }

        //Feltölti a dataGridView-ot az automatikus hozzárendelés eredményével
        void dataGridView_feltolt()
        {
            List<string> date = new List<string>();

            foreach (Team team in now_added)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    if (!date.Contains(kv.Key.ToString())) date.Add(kv.Key.ToString());
                }
            }

            date = date.OrderBy(f => f).ToList();


            foreach(string i in date)
            {
                foreach (Team te in now_added)
                {
                    foreach (KeyValuePair<string, List<Feladatok>> kv in te.tasks)
                    {
                        if (kv.Key.ToString().Equals(i))
                        {
                            foreach (Feladatok fe in kv.Value)
                            {
                                dataGridView.Rows.Add(i, te.getTeam_name(), fe.getFeladat_neve());
                            }
                        }
                    }
                }
            }

            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["CheckBox_Column"].Value = true;
            }

        }

        private void hozzarendeles_button_Click(object sender, EventArgs e)
        {

            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                if(Convert.ToBoolean(row.Cells["CheckBox_Column"].Value) == false) 
                {
                    foreach (Team team in now_added)
                    {
                        try
                        {
                            if (team.getTeam_name().Equals(row.Cells["Csapat"].Value.ToString()))
                            {
                                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                                {
                                    for (int x = kv.Value.Count - 1; x >= 0; x--)
                                    {
                                        if (row.Cells["Feladat"].Value.ToString().Equals(kv.Value[x].getFeladat_neve()))
                                        {
                                            kv.Value.RemoveAt(x);
                                        }
                                    }
                                }
                            }
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                       
                    }
                }
            }

            feladatok.Clear();
            feladatok = DataManager.BeolvasFeladatok(feladatok);

            foreach(Team te in now_added)
            {
                foreach (Team cs in csapatok)
                {
                    if (cs.getTeam_name().Equals(te.getTeam_name()))
                    {
                        foreach (KeyValuePair<string, List<Feladatok>> kv in te.tasks)
                        {
                            foreach (Feladatok fe in kv.Value)
                            {
                                cs.addTask(kv.Key.ToString(), fe);
                            }
                        }
                    }
                }
                
            }
            DataManager.setTeamList(csapatok);

            Csapat_hozzarendeles uj_form = new Csapat_hozzarendeles("taskManager");
            uj_form.Show();
            this.Close();
        }


    }
}
