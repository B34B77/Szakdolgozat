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
        List<Feladatok> feladatok = new List<Feladatok>();

        List<Team> teams_without_taks = new List<Team>();

        Database_Manager db = new Database_Manager();

        public Automatikus_hozzarendeles_kezeles(List<Team> csapatok, List<Feladatok> feladatok)
        {
            InitializeComponent();

            this.csapatok = csapatok;
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
            
        }

        private void Automatikus_hozzarendeles_kezeles_Load(object sender, EventArgs e)
        {


        }

        //Feltölti a dataGridView-ot az automatikus hozzárendelés eredményével
        void dataGridView_feltolt()
        {
            List<string> date = new List<string>();

            foreach (Team team in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    if (!date.Contains(kv.Key.ToString())) date.Add(kv.Key.ToString());
                }
            }

            date = date.OrderBy(f => f).ToList();


            foreach(string i in date)
            {
                foreach (Team te in csapatok)
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
            teams_without_taks = csapatok;

            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                if(Convert.ToBoolean(row.Cells["CheckBox_Column"].Value) == false) 
                {
                    foreach (Team team in teams_without_taks)
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

            csapatok = teams_without_taks;

            feladatok.Clear();
            db.Read_Task(feladatok);

            Csapat_hozzarendeles uj_form = new Csapat_hozzarendeles(feladatok, csapatok);
            uj_form.Show();
            this.Close();
        }


    }
}
