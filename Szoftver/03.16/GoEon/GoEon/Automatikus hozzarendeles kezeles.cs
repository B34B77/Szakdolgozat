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
        List<Team> csapatok = new List<Team>();
        List<Team> now_added = new List<Team>();

        List<Administration> administrations = new List<Administration>();

        List<Feladatok> feladatok = new List<Feladatok>();

        List<Team> teams_without_taks = new List<Team>();

        Database_Manager db = new Database_Manager();

        public Automatikus_hozzarendeles_kezeles(List<Team> now_added, List<Feladatok> feladatok)
        {
            InitializeComponent();

            this.now_added = now_added; //csak az újonnan hozzáadott 
            this.feladatok = feladatok;

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

            db.Read_Administraton(administrations);
            csapatok = db.Read_Team(csapatok);

            read_previously_added_tasks();

            //felesleges átadni az összes hozzárendelést tartalmaz lsitát, csak azt kell amibe az ujjak vannak, abból kiszűrni melyiket fogajuk el.
            //Majd a továbbadás előtt hozzáadni az adabázisból beolvasott adatokhoz és ezt adni tovább
            
        }

        private void Automatikus_hozzarendeles_kezeles_Load(object sender, EventArgs e)
        {


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
            db.Read_Task(feladatok);

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

            Csapat_hozzarendeles uj_form = new Csapat_hozzarendeles(feladatok, csapatok);
            uj_form.Show();
            this.Close();
        }


        void read_previously_added_tasks()
        {
            foreach (Administration ad in administrations)
            {
                foreach (Team team in csapatok)
                {
                    if (team.getTeam_name().Equals(ad.getTeam_name()))
                    {
                        foreach (int i in ad.task_id)
                        {
                            foreach (Feladatok fe in feladatok)
                            {
                                if (fe.getID() == i)
                                {
                                    team.addTask(ad.getDate(), fe);
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
