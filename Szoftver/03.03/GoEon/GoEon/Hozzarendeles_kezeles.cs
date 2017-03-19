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

            foreach(Team team in csapatok)
            {
                foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                {
                    date_comboBox_contain(kv.Key.ToString());
                }
            }
            
            foreach(Administration ad in administrations)
            {
                date_comboBox_contain(ad.getDate());
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
                    if (kv.Key.Equals(date_comboBox.SelectedItem))
                    {
                        team_listBox.Items.Add(te.getTeam_name());
                    }
                }
            }
   
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

                        string[] start = tavolsag_szamit(i.getCity()).Split(' ');

                        double start_lat = double.Parse(start[0], System.Globalization.CultureInfo.InvariantCulture);
                        double start_lng = double.Parse(start[1], System.Globalization.CultureInfo.InvariantCulture);

                        double depo_lat = start_lat;
                        double depo_lng = start_lng;

                        //Összesített távolság eltárolása
                        double tavolsag = 0.0;

                        foreach (KeyValuePair<string, List<Feladatok>> x in i.tasks)
                        {
                            if (x.Key.Equals(date_comboBox.SelectedItem.ToString()))
                            {
                                foreach (Feladatok j in x.Value)
                                {
                                    team_task_listBox.Items.Add(j.getFeladat_neve());
                                    information_listBox.Items.Add("- " + j.getVaros() + ", " + j.getUtca() + " " + j.getHazszam());

                                    //Latitude és Longitude
                                    string address = j.getVaros() + ",+" + j.getUtca() + "+" + j.getHazszam();

                                    string[] end = tavolsag_szamit(address).Split(' ');

                                    double end_lat = double.Parse(end[0], System.Globalization.CultureInfo.InvariantCulture);
                                    double end_lng = double.Parse(end[1], System.Globalization.CultureInfo.InvariantCulture);

                                    //távolság számítás..
                                    tavolsag = tavolsag + distance(start_lat, start_lng, end_lat, end_lng);
                                    //

                                    start_lat = end_lat;
                                    start_lng = end_lng;
                                }
                            }
                        }                        
                        tavolsag = tavolsag + distance(start_lat, start_lng, depo_lat, depo_lng);
                        tavolsag = tavolsag * 1.4;
                        information_listBox.Items.Add("\n");
                        information_listBox.Items.Add("Távolság: " + String.Format("{0:0.00}", tavolsag) + " km");

                        double sebesseg = 70; //70 km/h
                        double utazasi_ido = tavolsag / sebesseg;
                        utazasi_ido = utazasi_ido * 60; //Óra átalakítása percre

                        //Utazási idő számítás óra perc formátumban
                        var travel_time = TimeSpan.FromMinutes(utazasi_ido);
                        int ora = travel_time.Hours;
                        int perc = travel_time.Minutes;
                        information_listBox.Items.Add("Utazási idő: " + String.Format("{0} óra {1} perc", ora, perc));

                        utazasi_ido = utazasi_ido * 2;
                        travel_time = TimeSpan.FromMinutes(utazasi_ido);
                        ora = travel_time.Hours;
                        perc = travel_time.Minutes;
                        information_listBox.Items.Add("Teljes utazási idő (oda és vissza): " + String.Format("{0} óra {1} perc", ora, perc));
                    }

                }
            }
        } 

        //Hosszasági és szélességi pont megadása
        string tavolsag_szamit(string address)
        {
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat");
            var lng = locationElement.Element("lng");

            //Latitude kiválasztása és eltárolása egy változóba
            int i = 0;
            while (!lat.ToString()[i].Equals('>'))
            {
                i++;
            }
            i++;
            string latitude = "";
            while (!lat.ToString()[i].Equals('<'))
            {
                latitude = string.Concat(latitude, lat.ToString()[i]);
                i++;
            }

            //Latitude kiválasztása és eltárolása egy változóba
            i = 0;
            while (!lng.ToString()[i].Equals('>'))
            {
                i++;
            }
            i++;
            string longitude = "";
            while (!lng.ToString()[i].Equals('<'))
            {
                longitude = string.Concat(longitude, lng.ToString()[i]);
                i++;
            }

            string lat_lng = lat.ToString() + lng.ToString();
            return latitude + " " + longitude;
        }

        //Távolság számítás két pont között
        double distance(double start_lat, double start_lng, double end_lat, double end_lng)
        {
            double theta = start_lng - end_lng;
            double dist = Math.Sin(deg2rad(start_lat)) * Math.Sin(deg2rad(end_lat)) + Math.Cos(deg2rad(start_lat)) * Math.Cos(deg2rad(end_lat)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;

            return dist;
        }

        //Fokot radiánra konvertálja
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //A radiánt fokra konvertálja vissza
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
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
                    if (!date.Contains(kv.Key.ToString())) date.Add(kv.Key.ToString());
                }
            }

            date = date.OrderBy(f => f).ToList();

            foreach (string i in date)
            {
                sb.Append(i + ":\n");
                foreach (Team team in csapatok)
                {
                    foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                    {
                        if (kv.Key.ToString().Equals(i))
                        {
                            foreach (Feladatok fe in kv.Value)
                            {
                                sb.Append("     " + team.getTeam_name() + "\t" + fe.getFeladat_neve() + "\n");
                            }
                        }
                    }
                }
            }

            DialogResult riport = MessageBox.Show("Hozzárendelések\n\n" + sb.ToString(), "Riport", MessageBoxButtons.OK);
        }

        private void vissza_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
