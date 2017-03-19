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
    public partial class Feladat_részletek : Form
    {
        private string feladat_tipus; //Normál | Sürgős
        List<Feladatok> feladatok = new List<Feladatok>();

        public Feladat_részletek(List<Feladatok> lista, string type)
        {
            InitializeComponent();
            feladat_tipus = type;
            feladatok = lista;
            
        }

        private void Feladat_részletek_Load(object sender, EventArgs e)
        {

            if (feladat_tipus.Equals("Összes"))
            {
                foreach (Feladatok it in feladatok)
                {
                    
                    feladatok_listBox.Items.Add(it.getFeladat_neve());
                    

                }
            }
            else
            {
                foreach (Feladatok it in feladatok)
                {
                    if (it.getPrioritas().Equals(feladat_tipus))
                    {
                        feladatok_listBox.Items.Add(it.getFeladat_neve());
                    }

                }
            }
        }

        private void feladatok_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            adatok_listBox.Items.Clear();
            szukseges_kepesites_listBox.Items.Clear();
            szukseges_eszkozok_listBox.Items.Clear();

            if(feladatok_listBox.SelectedItem != null)
            {
                foreach (Feladatok it in feladatok)
                {
                    if (feladatok_listBox.SelectedItem.Equals(it.getFeladat_neve()))
                    {
                        adatok_listBox.Items.Add("Helyín:\n" + it.getVaros() + ", " + it.getUtca() + " " + it.getHazszam());
                        adatok_listBox.Items.Add("\n");
                        adatok_listBox.Items.Add(it.getLeiras());
                        adatok_listBox.Items.Add("\n");
                        adatok_listBox.Items.Add(it.getPrioritas());
                        adatok_listBox.Items.Add("\n");
                        adatok_listBox.Items.Add("Határidő: " + it.getHatarido());
                        adatok_listBox.Items.Add("\n");
                        adatok_listBox.Items.Add("Rögzítés ideje: " + it.getRogzites_ideje());
                        adatok_listBox.Items.Add("\n");
                        adatok_listBox.Items.Add(it.getMegjegyzes());

                        
                        foreach (string ot in it.eszkozok)
                        {
                            szukseges_eszkozok_listBox.Items.Add("- " + ot);
                        }

                        foreach (string ot in it.kepesitesek)
                        {
                            szukseges_kepesites_listBox.Items.Add("- " + ot);
                        }
                    }
                }
            }   
        }

        private void vissza_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
