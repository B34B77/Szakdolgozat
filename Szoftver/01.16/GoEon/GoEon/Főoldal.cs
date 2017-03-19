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
        Database_Manager db = new Database_Manager();
        List<Feladatok> feladatok = new List<Feladatok>();
        List<Team> csapatok = new List<Team>();
        Belépő_oldal belepo_form;

        public Fooldal(Belépő_oldal form)
        {
            InitializeComponent();
            belepo_form = form;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            feltolt();
        }

        public void feltolt()
        {
            feladatok.Clear();
            db.Read_Task(feladatok);

            csapatok.Clear();
            csapatok = db.Read_Team(csapatok);

            elvegzendo_feladatok_lista.Items.Clear();
            surgos_feladatok_lista.Items.Clear();
            csapatok_lista.Items.Clear();

            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Sürgős"))
                {
                    surgos_feladatok_lista.Items.Add(it.getFeladat_neve());
                    surgos_feladatok_lista.Items.Add("      Határidő: " + it.getHatarido());
                    surgos_feladatok_lista.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    surgos_feladatok_lista.Items.Add("      Prioritás:" + it.getPrioritas());
                    surgos_feladatok_lista.Items.Add("\n");

                }
                else
                {
                    elvegzendo_feladatok_lista.Items.Add(it.getFeladat_neve());
                    elvegzendo_feladatok_lista.Items.Add("      Határidő: " + it.getHatarido());
                    elvegzendo_feladatok_lista.Items.Add("      Helyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    elvegzendo_feladatok_lista.Items.Add("      Prioritás:" + it.getPrioritas());
                    elvegzendo_feladatok_lista.Items.Add("\n");
                }
            }

            foreach (Team it in csapatok)
            {
                csapatok_lista.Items.Add("- " + it.getTeam_name() + ":");
                csapatok_lista.Items.Add("      Székhely: " + it.getCity());
                csapatok_lista.Items.Add("\n");


                /*
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
                }*/
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vissza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void surgos_feladatok_lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void feladat_felvetel_Click(object sender, EventArgs e)
        {
            Uj_feladat_felvetele ujfeladat = new Uj_feladat_felvetele(this, belepo_form);
            ujfeladat.Show();
        }

        private void reszletek_normal_Button_Click(object sender, EventArgs e)
        {
            Feladat_részletek uj = new Feladat_részletek(feladatok, "Normál");
            uj.Show();
        }

        private void resztelek_surgos_Button_Click(object sender, EventArgs e)
        {
            Feladat_részletek uj = new Feladat_részletek(feladatok, "Sürgős");
            uj.Show();
        }

        private void csapat_hozzarendeles_Button_Click(object sender, EventArgs e)
        {
            Csapat_hozzarendeles uj = new Csapat_hozzarendeles(feladatok, csapatok);
            uj.Show();

        }
    }
}
