using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEon
{
    class Equipmet
    {
        protected int id;
        protected string name;
        protected string description;

        public Equipmet()
        {

        }

        public Equipmet(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public int getID()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public string getDescription()
        {
            return description;
        }
    }
}
