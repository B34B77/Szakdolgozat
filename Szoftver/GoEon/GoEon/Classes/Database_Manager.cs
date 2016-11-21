using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GoEon
{
    class Database_Manager
    {
        private MySqlConnection conn;
        private MySqlDataReader rdr;
        private string dbinfo;
      

        public Database_Manager()
        {
            dbinfo = @"server=localhost;userid=root;password=85fl94;database=goeon_db";


        }


        public void Read_Task(List<Feladatok> lista)
        {
            
            conn = null;
            rdr = null;

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                string stm = "SELECT * FROM task_table";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lista.Add(new Feladatok(rdr.GetString(1), rdr.GetString(2),
                        rdr.GetString(3), rdr.GetInt32(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11)));
                }
            }
            catch (MySqlException ex)
            {

                string messageBoxText = "Hiba történt az adatbázisból való beolvasás során:" + ex;
                string caption = "Adatbázis kezelés hiba";
                DialogResult warning = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK);
                
                if(warning == DialogResult.OK)
                {
                    
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public List<Team> Read_Team(List<Team> lista)
        {
            conn = null;
            rdr = null;
            List<Team> help = new List<Team>();
            lista = new List<Team>();

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                string stm = "SELECT * FROM team_table";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    help.Add(new Team(rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5)));
                }
            }
            catch (MySqlException ex)
            {

                string messageBoxText = "Hiba történt az adatbázisból való beolvasás során:" + ex;
                string caption = "Adatbázis kezelés hiba";
                DialogResult warning = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK);
                
                if(warning == DialogResult.OK)
                {
                    
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
                if (lista.Count() == 0)
                {
                    lista.Add(new Team(help.First().getTeam_name(), help.First().getCity()));

                }

                foreach (Team it in help)
                {
                    bool included = false;
                    foreach (Team ot in lista)
                    {
                        if (ot.getTeam_name().Equals(it.getTeam_name()))
                        {
                            included = true;
                            ot.addVehicles_id(it.getVID());
                            ot.addPersons_id(it.getPID());
                            ot.addEquipments_id(it.getEID());
                        }
                    }
                    if (included == false)
                    {
                        lista.Add(new Team(it.getTeam_name(), it.getCity()));
                        foreach (Team ot in lista)
                        {
                            if (ot.getTeam_name().Equals(it.getTeam_name()))
                            {
                                ot.addVehicles_id(it.getVID());
                                ot.addPersons_id(it.getPID());
                                ot.addEquipments_id(it.getEID());
                            }
                        }
                    }

                }
                
           

            return lista;
        }

    }
}
 