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
        public List<string> persons = new List<string>();
        public List<string> vehicles= new List<string>();
        public List<string> equipments = new List<string>();
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

        public void addPersons(string person)
        {
            bool included = false;
            foreach (string it in persons)
            {
                if (person.Equals(it))
                {
                    included = true;
                }
            }
            if (included == false)
            {
                persons.Add(person);
            }
        }

        public void addVehicles(string vehicle)
        {
            bool included = false;
            foreach(string it in vehicles)
            {
                if(vehicle.Equals(it))
                {
                    included = true;
                }
            }
            if(included == false)
            {
                vehicles.Add(vehicle);
            }
        }

        public void addEquipments(string equipment)
        {
            bool included = false;
            foreach (string it in equipments)
            {
                if (equipment.Equals(it))
                {
                    included = true;
                }
            }
            if (included == false)
            {
                equipments.Add(equipment);
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
