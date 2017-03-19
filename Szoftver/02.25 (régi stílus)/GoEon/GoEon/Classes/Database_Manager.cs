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
                    lista.Add(new Feladatok(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2),
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
                    lista.Add(new Team(help.First().getTeam_name(), help.First().getCity(), help.First().getPID(), help.First().getVID(), help.First().getEID()));

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

        public void Read_Equipments(List<Equipmet> lista)
        {
            
            conn = null;
            rdr = null;

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                string stm = "SELECT * FROM equipment_table";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lista.Add(new Equipmet(rdr.GetInt32(0), rdr.GetString(1),rdr.GetString(2)));
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

        public void Read_Person(List<Person> lista)
        {
            conn = null;
            rdr = null;

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                string stm = "SELECT * FROM goeon_db.person_table";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lista.Add(new Person(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4)));
                }
            }
            catch (MySqlException ex)
            {

                string messageBoxText = "Hiba történt az adatbázisból való beolvasás során:" + ex;
                string caption = "Adatbázis kezelés hiba";
                DialogResult warning = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK);

                if (warning == DialogResult.OK)
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

        public void Read_Vehicle(List<Vehicle> list)
        {
            conn = null;
            rdr = null;

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                string stm = "SELECT * FROM goeon_db.vehicle_table";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(new Vehicle(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetInt32(4), rdr.GetDouble(5), rdr.GetString(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9)));
                }
            }
            catch (MySqlException ex)
            {

                string messageBoxText = "Hiba történt az adatbázisból való beolvasás során:" + ex;
                string caption = "Adatbázis kezelés hiba";
                DialogResult warning = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK);

                if (warning == DialogResult.OK)
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

        public void add_item_task_management_table(string date, string csapatnev, string tasks)
        {
            string dbinfo = @"server=localhost;userid=root;password=85fl94;database=goeon_db";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO task_management_table(id, date, team_name, task_id) VALUES(null, @date, @team_name, @task_id)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@team_name", csapatnev);
                cmd.Parameters.AddWithValue("@task_id", tasks);

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {               
                string messageBoxText = "Hiba történt az adatbázisba való bevitel során!\n\n" + ex;
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

        }

        //Beolvassok egy listába a task_managemet_table adatait, hogy később használni tudjuk őket
        public void Read_Administraton(List<Administration> lista)
        {
            conn = null;
            rdr = null;

            try
            {
                conn = new MySqlConnection(dbinfo);
                conn.Open();

                string stm = "SELECT * FROM goeon_db.task_management_table";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lista.Add(new Administration(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)));
                }
            }
            catch (MySqlException ex)
            {

                string messageBoxText = "Hiba történt az adatbázisból való beolvasás során:" + ex;
                string caption = "Adatbázis kezelés hiba";
                DialogResult warning = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK);

                if (warning == DialogResult.OK)
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


    }

}
 