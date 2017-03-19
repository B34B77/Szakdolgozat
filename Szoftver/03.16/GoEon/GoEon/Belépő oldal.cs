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
        List<Administration> administrations = new List<Administration>();
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
           // WebBrowser.Navigate("file:///F:/Programoz%C3%A1s/Szakdoga/GoEon/GoEon/bin/Debug/goeon_medium_icon.jpg");
        }

        public void feltolt()
        {
            feladatok.Clear();
            db.Read_Administraton(administrations);
            db.Read_Task(feladatok);

            string today = DateTime.Now.ToString("yyyy-MM-dd");

            mai_hatarido_listBox.Items.Clear();

            foreach (Feladatok it in feladatok)
            {
                if (it.getHatarido().Equals(today))
                {
                    mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                    mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("\tPrioritás: " + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add(hozzarendeles_keres(it));
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }

        //Megvizsgálja, hogy az adott feladat hozzá lett-e már rendelve valamelyik csapathoz, ha igen akkor visszaadja a csapat nevét és a dátumot
        string hozzarendeles_keres(Feladatok task)
        {
            string data = "\tHozzárendelve: -";
            foreach (Administration ad in administrations)
            {
                foreach (int i in ad.task_id)
                {
                    if (i == task.getID())
                    {
                        data = "\tHozzárendelve: " + ad.getTeam_name() + " (" + ad.getDate() + ")";
                    }
                }
            }

            return data;
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
                    mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("\tPrioritás: " + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add(hozzarendeles_keres(it));
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }

        private void tovabb_Button_Click(object sender, EventArgs e)
        {
            Fooldal fooldal = new Fooldal(this);
            fooldal.Show();            
        }

        private void mai_hatarido_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mai_hatarido_listBox.SelectedItem != null)
            {
                pictureBox.Visible = false;
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
            hataridos_feladatok_group.Text = "Összes feladat";
            mai_hatarido_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                mai_hatarido_listBox.Items.Add("\tPrioritás:" + it.getPrioritas());
                mai_hatarido_listBox.Items.Add(hozzarendeles_keres(it));
                mai_hatarido_listBox.Items.Add("\n");
            }
        }

        private void maiHatáridővelRendelkezőFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hataridos_feladatok_group.Text = "Mai határidővel rendelkező feladatok";
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
                    mai_hatarido_listBox.Items.Add(hozzarendeles_keres(it));
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }

        private void sürgősFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hataridos_feladatok_group.Text = "Sürgős prioritással rendelkező feladatok";
            mai_hatarido_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Sürgős"))
                {
                    mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                    mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("\tPrioritás:" + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add(hozzarendeles_keres(it));
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }

        private void normálFeladatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hataridos_feladatok_group.Text = "Normál prioritással rendelkező feladatok";
            mai_hatarido_listBox.Items.Clear();
            foreach (Feladatok it in feladatok)
            {
                if (it.getPrioritas().Equals("Normál"))
                {
                    mai_hatarido_listBox.Items.Add(it.getFeladat_neve());
                    mai_hatarido_listBox.Items.Add("\tHatáridő: " + it.getHatarido());
                    mai_hatarido_listBox.Items.Add("\tHelyszín: " + it.getVaros() + ", " + it.getUtca() + ", " + it.getHazszam());
                    mai_hatarido_listBox.Items.Add("\tPrioritás:" + it.getPrioritas());
                    mai_hatarido_listBox.Items.Add(hozzarendeles_keres(it));
                    mai_hatarido_listBox.Items.Add("\n");
                }
            }
        }
    }
}
