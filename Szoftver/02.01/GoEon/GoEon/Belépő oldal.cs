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
            Gecko.Xpcom.Initialize(@"..\xulrunner");
        }

        private void Belépő_oldal_Load(object sender, EventArgs e)
        {
            feltolt();
            csapatok = db.Read_Team(csapatok);
            WebBrowser.Navigate("file:///F:/Programoz%C3%A1s/Szakdoga/GoEon/GoEon/bin/Debug/goeon_medium_icon.jpg");

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

        //Ideiglenes, ha hozzáadtunk egy feladatot egy csapathoz akkor azok nem jelennek meg
        public void feltolt(List<Feladatok> lista)
        {
            feladatok.Clear();
            feladatok = lista;
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
            Csapat_hozzarendeles uj = new Csapat_hozzarendeles(feladatok, csapatok, "Mai");
            uj.Show();
        }

        private void mai_hatarido_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mai_hatarido_listBox.SelectedItem != null)
            {
                foreach(Feladatok it in feladatok)
                {
                    if (mai_hatarido_listBox.SelectedItem.Equals(it.getFeladat_neve()))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("www.google.com/maps/place/");
                        sb.Append(it.getVaros() + ",+" + it.getUtca() + "+" + it.getHazszam());
                        WebBrowser.Navigate(sb.ToString());
                    }
                }
            }
        }

        private void összesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mai_hatarido_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                mai_hatarido_listBox.Items.Add("\tPrioritás:" + it.getPrioritas());
                mai_hatarido_listBox.Items.Add("\n");
            }
        }

        private void maiHatáridővelRendelkezőFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mai_hatarido_listBox.Items.Clear();
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            foreach (Feladatok it in feladatok)
            {
                if (it.getHatarido().Equals(today))
                {
                    mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                    mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("\tPrioritás:" + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }

        private void sürgősFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mai_hatarido_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Sürgős"))
                {
                    mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                    mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("\tPrioritás:" + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }

        private void normálFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mai_hatarido_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Normál"))
                {
                    mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                    mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("\tPrioritás:" + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }
    }
}
