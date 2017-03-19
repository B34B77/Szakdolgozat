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
    public partial class Elvegzett_feladatok_megadasa : Form
    {
        Database_Manager db = new Database_Manager();
        List<Feladatok> feladatok = new List<Feladatok>();

        List<Administration> administrations = new List<Administration>();


        public Elvegzett_feladatok_megadasa()
        {
            InitializeComponent();

            db.Read_Administraton(administrations);
            db.Read_Task(feladatok);

        }

        private void Elvegzett_feladatok_megadasa_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Datum", "Dátum amelyre ütemezve lett a feladat");
            dataGridView.Columns.Add("Csapat", "Csapat neve");
            dataGridView.Columns.Add("Feladat", "Feladat neve");

            DataGridViewCheckBoxColumn done = new DataGridViewCheckBoxColumn();
            done.HeaderText = "Teljesitve";
            done.Name = "CheckBox_Column";
            done.FalseValue = false;
            done.TrueValue = true;
            dataGridView.Columns.Add(done);

            dataGridView_feltolt();
        }

        void dataGridView_feltolt()
        {
            List<string> date = new List<string>();

            foreach (Administration ad in administrations)
            {
                if (!date.Contains(ad.getDate())) date.Add(ad.getDate());
            }

            date = date.OrderBy(f => f).ToList();


            foreach (string i in date)
            {
                foreach(Administration ad in administrations)
                {
                    if (ad.getDate().Equals(i))
                    {
                        foreach(int id in ad.task_id)
                        {
                           foreach(Feladatok task in feladatok)
                           {
                                if(task.getID() == id)
                                {
                                    dataGridView.Rows.Add(ad.getDate(), ad.getTeam_name(), task.getFeladat_neve());
                                }
                           }
                        }
                    }
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["CheckBox_Column"].Value = false;
            }

        }

        private void mentes_button_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells["CheckBox_Column"].Value) == true)
                {
                    foreach(Feladatok task in feladatok)
                    {
                        if (row.Cells["Feladat"].Value.ToString().Equals(task.getFeladat_neve()))
                        {
                            db.
                        }
                    }


                    //foreach (Team team in now_added)
                    //{
                    //    try
                    //    {
                    //        if (team.getTeam_name().Equals(row.Cells["Csapat"].Value.ToString()))
                    //        {
                    //            foreach (KeyValuePair<string, List<Feladatok>> kv in team.tasks)
                    //            {
                    //                for (int x = kv.Value.Count - 1; x >= 0; x--)
                    //                {
                    //                    if (row.Cells["Feladat"].Value.ToString().Equals(kv.Value[x].getFeladat_neve()))
                    //                    {
                    //                        kv.Value.RemoveAt(x);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //    catch (NullReferenceException ex)
                    //    {
                    //        Console.WriteLine(ex.ToString());
                    //    }

                    //}
                }
            }
        }
    }
}
