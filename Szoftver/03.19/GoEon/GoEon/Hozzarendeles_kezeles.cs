using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml.Linq;
using System.Linq;

namespace GoEon
{

    public partial class Hozzarendeles_kezeles : Form
    {
      
        List<Team> csapatok = new List<Team>();
        List<Feladatok> feladatok = new List<Feladatok>();
        List<Administration> administrations = new List<Administration>();

        Database_Manager db = new Database_Manager();

        Csapat_hozzarendeles csapat_hozzarendeles_form;
        public Hozzarendeles_kezeles(List<Team> csapatok, List<Feladatok> feladatok, Csapat_hozzarendeles csapat_hozzarendeles_form)
        {
            InitializeComponent();
            this.csapatok = csapatok;
            this.feladatok = feladatok;
            this.csapat_hozzarendeles_form = csapat_hozzarendeles_form;
        }

        private void Hozzarendeles_kezeles_Load(object sender, EventArgs e)
        {
            db.Read_Administraton(administrations);

            foreach (Team team in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    if (kv.Value.Count != 0)
                    {
                        date_comboBox_contain(kv.Key.ToString());
                    }
                }
            }
                        
        }

        private void date_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            team_listBox.Items.Clear();
            team_task_listBox.Items.Clear();
            information_listBox.Items.Clear();
            foreach (Team te in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in te.tasks)
                {
                    if (kv.Key.Equals(date_comboBox.SelectedItem) && kv.Value.Count != 0)
                    {
                        if (!team_listBox.Items.Contains(te.getTeam_name()))
                        {
                            team_listBox.Items.Add(te.getTeam_name());
                        }
                    }
                }
            }

            //foreach (Team i in csapatok)
            //{
            //    //A csapat székhelye
            //    string depo = i.getCity();

            //    string start = depo;

            //    double utazasi_ido = 0.0;
            //    double munkaido = 0.0;

            //    foreach (KeyValuePair<string, List<Feladatok>> x in i.tasks)
            //    {
            //        if (x.Key.Equals(date_comboBox.SelectedItem.ToString()))
            //        {
            //            foreach (Feladatok j in x.Value)
            //            {
            //                //Célállomás
            //                string end = j.getVaros() + ",+" + j.getUtca() + "+" + j.getHazszam();

            //                //távolság számítás..
            //                string ido_tavolsag = tavolsag_szamitas(start, end);

            //                string[] data = ido_tavolsag.Split('_');

            //                utazasi_ido = utazasi_ido + Convert.ToDouble(data[0]);

            //                munkaido = munkaido + j.getMunkaidoInMinute();

            //                start = end;
            //            }
            //        }
            //    }

            //    string[] tmp = tavolsag_szamitas(start, depo).Split('_');
            //    utazasi_ido = utazasi_ido + Convert.ToDouble(tmp[0]);

            //    double total_time = munkaido + (utazasi_ido / 60);
            //    var working_time = TimeSpan.FromMinutes(total_time);
            //    int ora = working_time.Hours;

            //    if(ora > 4)
            //    {
            //        team_listBox.Items.Add(i.getTeam_name() + "(Munkaidő túllépés!)");
            //    }

            //}          

        }

        //Ellenörzi, hogy a data_comboBox-ban szerepek-e már ez a dátum, ha nem akkor hozzáadja
        public void date_comboBox_contain(string date)
        {
            bool contain = false;
            foreach (string st in date_comboBox.Items)
            {
                if (st.Equals(date))
                {
                    contain = true;
                }
            }
            if (!contain)
            {
                date_comboBox.Items.Add(date);
            }
        }

        private void team_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(date_comboBox.SelectedItem != null && team_listBox.SelectedItem != null)
            {
               team_information_feltolt();
            }
        }

        
        void team_information_feltolt()
        {
            team_task_listBox.Items.Clear();
            information_listBox.Items.Clear();

            if (team_listBox.SelectedItem != null && date_comboBox.SelectedItem != null)
            {
                foreach (Team i in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(i.getTeam_name()))
                    {
                        information_listBox.Items.Add("Telephely: " + i.getCity());
                        information_listBox.Items.Add("\n");
                        information_listBox.Items.Add("Célállomások:");

                        //A csapat székhelye
                        string depo = i.getCity();

                        string start = depo;

                        //Összesített távolság eltárolása
                        double tavolsag = 0.0;
                        double utazasi_ido = 0.0;
                        double munkaido = 0.0;

                        foreach (KeyValuePair<string, List<Feladatok>> x in i.tasks)
                        {
                            if (x.Key.Equals(date_comboBox.SelectedItem.ToString()))
                            {
                                foreach (Feladatok j in x.Value)
                                {
                                    team_task_listBox.Items.Add(j.getFeladat_neve());
                                    information_listBox.Items.Add("- " + j.getVaros() + ", " + j.getUtca() + " " + j.getHazszam());

                                    //Célállomás
                                    string end = j.getVaros() + ",+" + j.getUtca() + "+" + j.getHazszam();


                                    //távolság számítás..
                                    string ido_tavolsag = tavolsag_szamitas(start, end);

                                    string[] data = ido_tavolsag.Split('_');

                                    tavolsag = tavolsag + Convert.ToDouble(data[1]);
                                    utazasi_ido = utazasi_ido + Convert.ToDouble(data[0]);
                                    //

                                    //Munkaidő
                                    munkaido = munkaido + j.getMunkaidoInMinute();

                                    start = end;
                                }
                            }
                        }

                        string[] tmp = tavolsag_szamitas(start, depo).Split('_');

                        tavolsag = tavolsag + Convert.ToDouble(tmp[1]);
                        utazasi_ido = utazasi_ido + Convert.ToDouble(tmp[0]);

                        //méterből km
                        tavolsag = tavolsag / 1000;

                        information_listBox.Items.Add("\n");
                        information_listBox.Items.Add("Távolság: " + String.Format("{0:0.00}", tavolsag) + " km");

                        //Utazási idő számítás óra perc formátumban
                        var travel_time = TimeSpan.FromSeconds(utazasi_ido);
                        int ora = travel_time.Hours;
                        int perc = travel_time.Minutes;
                        information_listBox.Items.Add("Utazási idő: " + String.Format("{0} óra {1} perc", ora, perc));

                        var working_time = TimeSpan.FromMinutes(munkaido);
                        ora = working_time.Hours;
                        perc = working_time.Minutes;
                        information_listBox.Items.Add("Munkaidő: " + String.Format("{0} óra {1} perc", ora, perc));

                        double total_time = munkaido + (utazasi_ido / 60);
                        working_time = TimeSpan.FromMinutes(total_time);
                        ora = working_time.Hours;
                        perc = working_time.Minutes;
                        information_listBox.Items.Add("Teljes időigény utazással és munkaórával együtt:");
                        information_listBox.Items.Add(String.Format("{0} óra {1} perc", ora, perc));
                    }

                }
            }
        }
        
        string tavolsag_szamitas(string start, string finish)
        {
            var requestUri = string.Format("https://maps.googleapis.com/maps/api/distancematrix/xml?units=metric&origins={0}&destinations={1}&key=AIzaSyAuX1J0dVZ6tnDRHo-ncdxg56fOLu-PyRg", Uri.EscapeDataString(start), Uri.EscapeDataString(finish));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            //Feldaraboljuk, hogy megkapjuk a távolságot és az időt
            var result = xdoc.Element("DistanceMatrixResponse").Element("row");
            var duration = result.Element("element").Element("duration");
            var distance = result.Element("element").Element("distance");

            //távolság is időt tartalmazó xml értékek
            var ido = duration.Element("value");
            var tavolsag = distance.Element("value");

            //Utazási idő kiválasztása és eltárolása egy változóba
            int i = 0;
            while (!ido.ToString()[i].Equals('>'))
            {
                i++;
            }
            i++;
            string utazasi_ido = "";
            while (!ido.ToString()[i].Equals('<'))
            {
                utazasi_ido = string.Concat(utazasi_ido, ido.ToString()[i]);
                i++;
            }

            //Távolság kiválasztása és eltárolása egy változóba
            i = 0;
            while (!tavolsag.ToString()[i].Equals('>'))
            {
                i++;
            }
            i++;
            string utvonalhossz = "";
            while (!tavolsag.ToString()[i].Equals('<'))
            {
                utvonalhossz = string.Concat(utvonalhossz, tavolsag.ToString()[i]);
                i++;
            }

            return utazasi_ido + "_" + utvonalhossz;
        }

        
        private void megjelenites_Button_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (team_listBox.SelectedItem != null)
            {
                foreach (Team i in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(i.getTeam_name()))
                    {
                        foreach (KeyValuePair<string, List<Feladatok>> j in i.tasks)
                        {
                            if (j.Key.Equals(date_comboBox.SelectedItem))
                            {
                                sb.Append("https://www.google.hu/maps/dir/" + i.getCity());
                                foreach (Feladatok x in j.Value)
                                {
                                    sb.Append("/" + x.getVaros() + ",+" + x.getUtca() + "+" + x.getHazszam());
                                }
                                sb.Append("/" + i.getCity());
                            }
                        }

                    }
                }
                Terkep uj_form = new Terkep(sb.ToString());
                uj_form.Show();
            }
        }

        //Mentésnél majd vissza kell adni a csapatok és a feladatok listát is, hogy az adatok egyezenek a két formon
        
        private void task_delete_button_Click(object sender, EventArgs e)
        {
            if (team_task_listBox.SelectedItem != null)
            {
                foreach (Team i in csapatok)
                {
                    if (team_listBox.SelectedItem.Equals(i.getTeam_name()))
                    {
                        foreach (KeyValuePair<string, List<Feladatok>> kv in i.tasks)
                        {
                            foreach (Feladatok j in kv.Value)
                            {
                                if (team_task_listBox.SelectedItem.Equals(j.getFeladat_neve()))
                                {
                                    feladatok.Add(j);

                                }
                            }
                        }



                        foreach (KeyValuePair<string, List<Feladatok>> kv in i.tasks)
                        {
                            for (int x = kv.Value.Count - 1; x >= 0; x--)
                            {
                                if (team_task_listBox.SelectedItem.Equals(kv.Value[x].getFeladat_neve()))
                                {
                                    kv.Value.RemoveAt(x);
                                }
                            }
                        }

                        team_task_listBox.Items.Remove(team_task_listBox.SelectedItem);
                        information_listBox.Items.Clear();
                    }
                }
            }
        }

        private void team_task_listBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.team_task_listBox.SelectedItem == null) return;
            this.team_task_listBox.DoDragDrop(this.team_task_listBox.SelectedItem, DragDropEffects.Move);
        }

        private void team_task_listBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void team_task_listBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = team_task_listBox.PointToClient(new Point(e.X, e.Y));

            int index = this.team_task_listBox.IndexFromPoint(point);

            if (index < 0)
            {
                index = this.team_task_listBox.Items.Count - 1;
            }

            object data = team_task_listBox.SelectedItem;
            this.team_task_listBox.Items.Remove(data);
            this.team_task_listBox.Items.Insert(index, data);

            List<Feladatok> help = new List<Feladatok>();

            foreach (Team it in csapatok)
            {
                if (it.getTeam_name().Equals(team_listBox.SelectedItem))
                {

                    foreach (string x in team_task_listBox.Items)
                    {
                        foreach (KeyValuePair<string, List<Feladatok>> y in it.tasks)
                        {
                            foreach (Feladatok ot in y.Value)
                            {
                                if (ot.getFeladat_neve().Equals(x))
                                {
                                    help.Add(ot);
                                }
                            }
                        }
                    }

                    it.tasks[date_comboBox.SelectedItem.ToString()] = help;

                }
            }
            team_information_feltolt();
        }

        private void mentes_button_Click(object sender, EventArgs e)
        {
            csapat_hozzarendeles_form.update(feladatok, csapatok);
            DialogResult warning = MessageBox.Show("A változtatások mentése megtörtént!\n", "Mentés", MessageBoxButtons.OK);
            //this.Close();
        }

        private void riport_button_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            List<string> date = new List<string>();

            foreach (Team team in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    if (!date.Contains(kv.Key.ToString()) && kv.Value.Count != 0) date.Add(kv.Key.ToString());
                }
            }

            date = date.OrderBy(f => f).ToList();

            foreach (string i in date)
            {
                sb.Append(i + ":\r\n");
                foreach (Team team in csapatok)
                {
                    foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                    {
                        if (kv.Key.ToString().Equals(i))
                        {
                            foreach (Feladatok fe in kv.Value)
                            {
                                sb.Append("     " + team.getTeam_name() + "\t\t" + fe.getFeladat_neve() + "\r\n");
                            }
                        }
                    }
                }
                sb.Append("\r\n");
            }

            Riport riport = new Riport(sb.ToString());
            riport.Show();
        }

        private void vissza_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
