using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEon
{
    public class Team
    {
        protected string team_name;
        protected string city;
        public List<int> persons_id = new List<int>();
        public List<int> vehicles_id = new List<int>();
        public List<int> equipments_id = new List<int>();
        public List<Feladatok> tasks = new List<Feladatok>();
        protected int pid;
        protected int vid;
        protected int eid;

        public Team()
        {

        }

        public Team(string csapat_nev, string szekhely)
        {
            this.team_name = csapat_nev;
            this.city = szekhely;
        }

        public Team(string csapat_nev, string szekhely, int pid, int vid, int eid)
        {
            this.team_name = csapat_nev;
            this.city = szekhely;
            this.pid = pid;
            this.vid = vid;
            this.eid = eid;
        }

        public void addTask(Feladatok task)
        {
            tasks.Add(task);
        }

        public void addPersons_id(int id)
        {
            bool included = false;
            foreach (int it in persons_id)
            {
                if (id == it)
                {
                    included = true;
                }
            }
            if (included == false)
            {
                persons_id.Add(id);
            }
        }

        public void addVehicles_id(int id)
        {
            bool included = false;
            foreach (int it in vehicles_id)
            {
                if (id == it)
                {
                    included = true;
                }
            }
            if (included == false)
            {
                vehicles_id.Add(id);
            }
        }

        public void addEquipments_id(int id)
        {
            bool included = false;
            foreach (int it in equipments_id)
            {
                if (id == it)
                {
                    included = true;
                }
            }
            if (included == false)
            {
                equipments_id.Add(id);
            }
        }

        public string getTeam_name()
        {
            return team_name;
        }

        public string getCity()
        {
            return city;
        }

        public int getPID()
        {
            return pid;
        }

        public int getVID()
        {
            return vid;
        }

        public int getEID()
        {
            return eid;
        }

    }
}
