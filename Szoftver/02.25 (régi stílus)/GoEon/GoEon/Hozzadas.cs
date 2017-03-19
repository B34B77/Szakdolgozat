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
    public partial class Hozzadas : Form
    {
        List<Team> csapatok = new List<Team>();
        List<Feladatok> tasks = new List<Feladatok>();
        string datum;
        Feladatok feladat;
        
        Csapat_hozzarendeles csapat_hozzarendeles_form;

        public Hozzadas(List<Feladatok> tasks, Feladatok feladat, List<Team> csapatok, string  datum, List<string> csapat_nevek, Csapat_hozzarendeles csapat_hozzarendeles_form)
        {
            InitializeComponent();
            team_listBox.Items.Clear();

            foreach(string nevek in csapat_nevek)
            {
                team_listBox.Items.Add(nevek);
            }

            this.datum = datum;
            this.feladat = feladat;
            this.csapatok = csapatok;
            this.tasks = tasks;
            this.csapat_hozzarendeles_form = csapat_hozzarendeles_form;
        }

        private void Hozzadas_Load(object sender, EventArgs e)
        {
            
        }

        private void hozzaadas_button_Click(object sender, EventArgs e)
        {
            bool good = true;

            if(team_listBox.SelectedItem != null)
            {
                foreach(Team team in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(team.getTeam_name()))
                    {
                        if (team.tasks.Count == 2)
                        {
                            DialogResult warning = MessageBox.Show("A csapat kapacitása megtelt!\nNem rendelhető hozzájuk több feladat!\n", "Figyelmeztetés", MessageBoxButtons.OK);
                            good = false;
                        }
                        else
                        {
                            team.addTask(datum, feladat);
                        }
                    }
                }

                if (good)
                {
                    for (int i = tasks.Count - 1; i >= 0; i--)
                    {
                        if (tasks[i].getFeladat_neve().Equals(feladat.getFeladat_neve()))
                        {
                            tasks.RemoveAt(i);
                        }
                    }

                    csapat_hozzarendeles_form.date_comboBox_contain(datum);
                    csapat_hozzarendeles_form.load_feladatok_listBox(tasks);
                    csapat_hozzarendeles_form.feladatok_load("");

                }
                this.Close();
            }
        }
    }
}
