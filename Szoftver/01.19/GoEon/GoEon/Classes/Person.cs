using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEon
{
    public class Person
    {
        protected int id;
        protected string name;
        protected string qualification;
        protected string email;
        protected string phone_number;

        public Person()
        {

        }

        public Person(int id, string name, string qualification, string email, string phone_number)
        {
            this.id = id;
            this.name = name;
            this.qualification = qualification;
            this.email = email;
            this.phone_number = phone_number;
        }

        public int getID()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public string getQualification()
        {
            return qualification;
        }

        public string getEmail()
        {
            return email;
        }

        public string getPhone_number()
        {
            return phone_number;
        }
    }
}
