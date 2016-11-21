using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace GoEon
{
    public partial class Fooldal : Form
    {
        public Fooldal()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Database_Manager db = new Database_Manager();
            List<Feladatok> feladatok = new List<Feladatok>();
            List<Team> csapatok = new List<Team>();

            db.Read_Task(feladatok);
            csapatok = db.Read_Team(csapatok);

            foreach(Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Sürgős"))
                {
                    surgos_feladatok_lista.Items.Add(it.getFeladat_neve());
                    surgos_feladatok_lista.Items.Add("      Határidő: " + it.getHatarido());
                    surgos_feladatok_lista.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    surgos_feladatok_lista.Items.Add("      Prioritás:" + it.getPrioritas());

                }
                else
                {
                    elvegzendo_feladatok_lista.Items.Add(it.getFeladat_neve());
                    elvegzendo_feladatok_lista.Items.Add("      Határidő: " + it.getHatarido());
                    elvegzendo_feladatok_lista.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    elvegzendo_feladatok_lista.Items.Add("      Prioritás:" + it.getPrioritas());
                }
            }

            foreach(Team it in csapatok)
            {
                csapatok_lista.Items.Add("- " + it.getTeam_name() + ":");
                csapatok_lista.Items.Add("      Székhely: " + it.getCity());

                csapatok_lista.Items.Add("Eszköz:");
                foreach (int ot in it.equipments_id)
                {
                    csapatok_lista.Items.Add(ot + " ");
                }
                csapatok_lista.Items.Add("Ember:");
                foreach (int ot in it.persons_id)
                {
                    csapatok_lista.Items.Add(ot + " ");
                }
                csapatok_lista.Items.Add("Jármű:");
                foreach (int ot in it.vehicles_id)
                {
                    csapatok_lista.Items.Add(ot + " ");
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void surgos_feladatok_lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void feladat_felvetel_Click(object sender, EventArgs e)
        {
            Uj_feladat_felvetele ujfeladat = new Uj_feladat_felvetele();
            ujfeladat.Show();
        }
    }
}
