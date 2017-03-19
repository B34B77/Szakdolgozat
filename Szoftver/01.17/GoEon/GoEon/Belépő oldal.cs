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
    public partial class Belépő_oldal : Form
    {
        Database_Manager db = new Database_Manager();
        List<Feladatok> feladatok = new List<Feladatok>();
        List<Team> csapatok = new List<Team>();
        public Belépő_oldal()
        {
            InitializeComponent();
        }

        private void Belépő_oldal_Load(object sender, EventArgs e)
        {
            feltolt();
            csapatok = db.Read_Team(csapatok);
        }

        public void feltolt()
        {
            feladatok.Clear();
            db.Read_Task(feladatok);

            string today = DateTime.Now.ToString("yyyy-MM-dd");

            mai_hatarido_listBox.Items.Clear();

            foreach (Feladatok it in feladatok)
            {
                if (it.getHatarido().Equals(today))
                {
                    mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                    mai_hatarido_listBox.Items.Add("      Határidő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("      Prioritás: " + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }
        private void tovabb_Button_Click(object sender, EventArgs e)
        {
            Fooldal fooldal = new Fooldal(this);
            fooldal.Show();            
        }

        private void csapat_hozzarendeles_Button_Click(object sender, EventArgs e)
        {
            Csapat_hozzarendeles uj = new Csapat_hozzarendeles(feladatok, csapatok, "Mai" );
            uj.Show();
        }
    }
}
