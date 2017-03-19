using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEon
{
    public class Administration
    {
        int id;
        string date;
        string team_name;
        public List<int> task_id = new List<int>();

        public Administration(int id, string date, string team_name, string tasks)
        {
            this.id = id;
            this.team_name = team_name;
            this.date = date;

            string[] str = tasks.Split(',');
            foreach (string i in str)
            {
                if (!i.Equals(""))
                {
                    task_id.Add(Convert.ToInt32(i));
                }
            }
        }

        public int getID()
        {
            return id;
        }

        public string getDate()
        {
            return date;
        }

        public string getTeam_name()
        {
            return team_name;
        }
    }
}
