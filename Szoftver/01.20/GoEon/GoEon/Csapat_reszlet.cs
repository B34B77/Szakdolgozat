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
    public partial class Csapat_reszlet : Form
    {
        List<Team> csapatok = new List<Team>();
        List<Person> emberek = new List<Person>();
        List<Equipmet> eszkozok = new List<Equipmet>();
        List<Vehicle> jarmuvek = new List<Vehicle>();

        public Csapat_reszlet(List<Team> list, List<Person> plist, List<Vehicle> vlist, List<Equipmet> elist)
        {
            InitializeComponent();
            csapatok = list;
            emberek = plist;
            jarmuvek = vlist;
            eszkozok = elist;            
        }

        private void Csapat_reszlet_Load(object sender, EventArgs e)
        {
            csapatok_listBox.Items.Clear();

            foreach (Team it in csapatok)
            {
                csapatok_listBox.Items.Add(it.getTeam_name());
            }
        }



        private void vissza_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void csapatok_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            person_listBox.Items.Clear();
            vehicle_listBox.Items.Clear();
            equipment_listBox.Items.Clear();

            if(csapatok_listBox.SelectedItem != null)
            {
                foreach (Team it in csapatok)
                {
                    if (csapatok_listBox.SelectedItem.Equals(it.getTeam_name()))
                    {
                        foreach (int ot in it.persons_id)
                        {
                            foreach (Person xt in emberek)
                            {
                                if (xt.getID().Equals(ot))
                                {
                                    person_listBox.Items.Add(xt.getName());
                                    person_listBox.Items.Add("  Képesítés: " + xt.getQualification());
                                    person_listBox.Items.Add("  Email: " + xt.getEmail());
                                    person_listBox.Items.Add("  Telefonszám: " + xt.getPhone_number());
                                }
                            }
                            person_listBox.Items.Add("\n");
                        }

                        foreach (int ot in it.vehicles_id)
                        {
                            foreach (Vehicle xt in jarmuvek)
                            {
                                if (xt.getID().Equals(ot))
                                {
                                    vehicle_listBox.Items.Add(xt.getVehicle_name());
                                    vehicle_listBox.Items.Add("\tTerhelhetőség: " + xt.getCapacity() + " kg");
                                    vehicle_listBox.Items.Add("\tHajtás: " + xt.getDrive());
                                    vehicle_listBox.Items.Add("\tTeljesítmény: " + xt.getPerformance() + " LE");
                                    vehicle_listBox.Items.Add("\tFogyasztás: " + xt.getConsumption() + " /100 km");
                                    vehicle_listBox.Items.Add("\tÜzemanyag: " + xt.getFuel_type());
                                    vehicle_listBox.Items.Add("\tSaját tömeg: " + xt.getWeight() + " kg");
                                    vehicle_listBox.Items.Add("\tMagasság: " + xt.getHeight() + " mm");
                                    vehicle_listBox.Items.Add("\tHosszúság: " + xt.getLength() + " mm");
                                }
                            }
                            vehicle_listBox.Items.Add("\n");
                        }


                        foreach (int ot in it.equipments_id)
                        {
                            foreach (Equipmet xt in eszkozok)
                            {
                                if (xt.getID() == ot)
                                {
                                    equipment_listBox.Items.Add(xt.getName());
                                    equipment_listBox.Items.Add("\t" + xt.getDescription());
                                }
                            }
                            equipment_listBox.Items.Add("\n");
                        }
                    }
                }
            }


        }
    }
}
