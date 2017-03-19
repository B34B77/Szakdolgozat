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
    public partial class Uj_feladat_felvetele : Form
    {
        List<Equipmet> equipments = new List<Equipmet>();
        List<Person> persons = new List<Person>();
        List<string> eq = new List<string>();
        List<string> qu = new List<string>();
        Database_Manager db_manage = new Database_Manager();
        Fooldal fooldal_form;
        Belépő_oldal belepo_form;
        string munkaido;
        

        public Uj_feladat_felvetele(Fooldal form, Belépő_oldal form2)
        {
            InitializeComponent();
            db_manage.Read_Equipments(equipments);
            db_manage.Read_Person(persons);
            fooldal_form = form;
            belepo_form = form2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Eszközök listázása
            foreach (Equipmet it in equipments)
            {
                eszkozok_lista.Items.Add(it.getName());
            }


            //Képzettségek listázása
            foreach(Person it in persons)
            {
                elerheto_kepzettseg_lista.Items.Add(it.getQualification());
            }

            //Prioritások megadása
            prioritas_comboBox.Items.Add("Normál");
            prioritas_comboBox.Items.Add("Sürgős");

            for(int i = 0; i<13; i++)
            {
                ora_comboBox.Items.Add(i + ":00");
            }

            perc_comboBox.Items.Add("0:00");
            perc_comboBox.Items.Add("0:15");
            perc_comboBox.Items.Add("0:30");
            perc_comboBox.Items.Add("0:45");


        }

       

        private void elerheto_kepzettseg_lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vissza_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eszkozok_lista_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void feladat_felvetele_button_Click(object sender, EventArgs e)
        {
            string dbinfo = @"server=localhost;userid=root;password=85fl94;database=goeon_db";

            MySqlConnection conn = null;

            bool good = true;

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO task_table(task_id, task_name, city, street, house_number, description, deadline, recording_date, priority, equipments, qualification, comment, working_hour) VALUES(null, @task_name, @city, @street, @house_number, @description, @deadline, now(), @priority, @equipments, @qualification, @comment, @working_hour)";
                cmd.Prepare();


                string eszkoz = "";
                foreach (string i in eq)
                {
                    eszkoz = string.Concat(eszkoz, i + ",");
                }

                string kepesites = "";
                foreach (string i in qu)
                {
                    kepesites = string.Concat(kepesites, i + ",");
                }

                if (feladatnev_textbox.Text.Equals(""))
                {
                    good = false;
                }
                if (varos_textBox.Text.Equals(""))
                {
                    good = false;
                }
                if (utca_textBox.Text.Equals(""))
                {
                    good = false;
                }
                if (hazszam_textBox.Text.Equals(""))
                {
                    good = false;
                }
                if (leiras_textBox.Text.Equals(""))
                {
                    good = false;
                }
                if (prioritas_comboBox.SelectedItem == null)
                {
                    good = false;
                }
                if (szukseges_eszkozok_lista.Items.Count == 0)
                {
                    good = false;
                }
                if (szukseges_kepzettseg_lista.Items.Count == 0)
                {
                    good = false;
                }
                if (munkaido == null)
                {
                    good = false;
                }


                if (good)
                {
                    cmd.Parameters.AddWithValue("@task_name", feladatnev_textbox.Text);
                    cmd.Parameters.AddWithValue("@city", varos_textBox.Text);
                    cmd.Parameters.AddWithValue("@street", utca_textBox.Text);
                    cmd.Parameters.AddWithValue("@house_number", hazszam_textBox.Text);
                    cmd.Parameters.AddWithValue("@description", leiras_textBox.Text);
                    cmd.Parameters.AddWithValue("@deadline", hatarido.Text);
                    cmd.Parameters.AddWithValue("@priority", prioritas_comboBox.Text);
                    cmd.Parameters.AddWithValue("@equipments", eszkoz);
                    cmd.Parameters.AddWithValue("@qualification", kepesites);
                    cmd.Parameters.AddWithValue("@comment", megjegyzes_textBox.Text);
                    cmd.Parameters.AddWithValue("@working_hour", munkaido);

                    
                }

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                good = false;

                StringBuilder sb = new StringBuilder();
                if (feladatnev_textbox.Text.Equals(""))
                {
                    sb.Append("Adja meg a feladat nevét!\n");
                    feladatnev_textbox.BackColor = Color.Khaki;
                }
                if (varos_textBox.Text.Equals(""))
                {
                    sb.Append("Adja meg a Város nevét!\n");
                    varos_textBox.BackColor = Color.Khaki;
                }
                if (utca_textBox.Text.Equals(""))
                {
                    sb.Append("Adja meg a utca nevét!\n");
                    utca_textBox.BackColor = Color.Khaki;
                }
                if (hazszam_textBox.Text.Equals(""))
                {
                    sb.Append("Adja meg a házszámot!\n");
                    hazszam_textBox.BackColor = Color.Khaki;
                }
                if (leiras_textBox.Text.Equals(""))
                {
                    sb.Append("Adja meg a feladat leírását!\n");
                    leiras_textBox.BackColor = Color.Khaki;
                }
                if (prioritas_comboBox.SelectedItem == null)
                {
                    sb.Append("Válassza ki milyen prioritással rendelkezik a feladat!\n");
                    prioritas_comboBox.BackColor = Color.Khaki;
                }
                if (szukseges_eszkozok_lista.Items.Count == 0)
                {
                    sb.Append("Válassza ki milyen eszköz szükséges a munkához!\n");
                    szukseges_eszkozok_lista.BackColor = Color.Khaki;
                }
                if (szukseges_kepzettseg_lista.Items.Count == 0)
                {
                    sb.Append("Válassza ki milyen képzettség szükséges a munkához!\n");
                    szukseges_kepzettseg_lista.BackColor = Color.Khaki;
                }
                if (munkaido == null)
                {
                    sb.Append("Adja meg a feladat elvégzéséhez szükséges időt!\n");
                    ora_comboBox.BackColor = Color.Khaki;
                    perc_comboBox.BackColor = Color.Khaki;
                }

                string messageBoxText = "Hiba történt az adatbázisba való bevitel során!\n\n" + sb;
                string caption = "Adatbázis kezelés hiba";
                DialogResult warning = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK);

                if (warning == DialogResult.OK)
                {

                }

                
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            if (good == true)
            {
                fooldal_form.feltolt();
                belepo_form.feltolt();
                DialogResult felvetel = MessageBox.Show("Sikeresen felvette a feladatot az adatbázisba", "A feladat felvéve", MessageBoxButtons.OK);
                if (felvetel == DialogResult.OK)
                {
                    this.Close();
                }
            }

        }

        private void add_eszkoz_button_Click(object sender, EventArgs e)
        {
            if (eszkozok_lista.SelectedItem != null)
            {
                eq.Add(eszkozok_lista.SelectedItem.ToString());
                szukseges_eszkozok_lista.Items.Add(eszkozok_lista.SelectedItem);
                eszkozok_lista.Items.Remove(eszkozok_lista.SelectedItem);
            }
        }

        private void remove_eszkoz_button_Click(object sender, EventArgs e)
        {
            if (szukseges_eszkozok_lista.SelectedItem != null)
            {
                eq.Remove(szukseges_eszkozok_lista.SelectedItem.ToString());
                eszkozok_lista.Items.Add(szukseges_eszkozok_lista.SelectedItem);
                szukseges_eszkozok_lista.Items.Remove(szukseges_eszkozok_lista.SelectedItem);
            }
 

        }

        private void add_kepzettseg_button_Click(object sender, EventArgs e)
        {
            if(elerheto_kepzettseg_lista.SelectedItem != null)
            {
                qu.Add(elerheto_kepzettseg_lista.SelectedItem.ToString());
                szukseges_kepzettseg_lista.Items.Add(elerheto_kepzettseg_lista.SelectedItem);
                elerheto_kepzettseg_lista.Items.Remove(elerheto_kepzettseg_lista.SelectedItem);
            }          

        }

        private void remove_kepzettseg_button_Click(object sender, EventArgs e)
        {
            if(szukseges_kepzettseg_lista.SelectedItem != null)
            {
                qu.Add(szukseges_kepzettseg_lista.SelectedItem.ToString());
                elerheto_kepzettseg_lista.Items.Add(szukseges_kepzettseg_lista.SelectedItem);
                szukseges_kepzettseg_lista.Items.Remove(szukseges_kepzettseg_lista.SelectedItem);
            }
            
        }

        private void prioritas_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void hatarido_ValueChanged(object sender, EventArgs e)
        {
            hatarido.Format = DateTimePickerFormat.Custom;
            hatarido.CustomFormat = "yyyy-MM-dd";
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            string ora;
            string perc;

            if(ora_comboBox.SelectedItem == null)
            {
                ora = "0";
            }
            else
            {
                string[] tmp = ora_comboBox.SelectedItem.ToString().Split(':');
                ora = tmp[0];
            }

            if(perc_comboBox.SelectedItem == null)
            {
                perc = "00";
            }
            else
            {
                string[] tmp = perc_comboBox.SelectedItem.ToString().Split(':');
                perc = tmp[1];
            }

            munkaido = ora + ":" + perc;
            munkaido_label.Text = "Munkaidő: " + munkaido;
        }
    }
}
