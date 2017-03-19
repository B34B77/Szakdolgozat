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

        Fooldal fooldal;

        public Elvegzett_feladatok_megadasa(Fooldal fooldal)
        {
            InitializeComponent();

            this.fooldal = fooldal;
            administrations = DataManager.BeolvasAdministration(administrations);
            feladatok = DataManager.BeolvasFeladatok_ElvegzettekNelkul(feladatok);

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

                    for(int x = administrations.Count - 1; x>=0; x--)
                    {
                        if (administrations[x].getDate().Equals(row.Cells["Datum"].Value.ToString()) && administrations[x].getTeam_name().Equals(row.Cells["Csapat"].Value.ToString()))
                        {
                            for(int j = administrations[x].task_id.Count - 1; j>=0; j--)
                            {
                                foreach (Feladatok task in feladatok)
                                {
                                    if (task.getFeladat_neve().Equals(row.Cells["Feladat"].Value.ToString()) && administrations[x].task_id[j] == task.getID())
                                    {
                                        db.doneTask(task.getFeladat_neve(), row.Cells["Datum"].Value.ToString(), row.Cells["Csapat"].Value.ToString());
                                        administrations[x].task_id.RemoveAt(j);
                                    }
                                }
                            }
                        }
                        if(administrations[x].task_id.Count == 0)
                        {
                            administrations.RemoveAt(x);
                        }
                    }
                }
            }

            db.clear_task_management_table();

            foreach (Administration ad in administrations)
            {
                string tasks = "";
                foreach(int id in ad.task_id)
                {
                    tasks = string.Concat(tasks, id + ","); 
                }
                if (!tasks.Equals(""))
                {
                    db.add_item_task_management_table(ad.getDate(), ad.getTeam_name(), tasks);
                }
            }

            fooldal.feltolt();
            DialogResult done = MessageBox.Show("A módosítás megtörtént!\n", "Sikeres módosítás", MessageBoxButtons.OK);
            if (done == DialogResult.OK)
            {
                
                this.Close();
            }
        }
    }
}
