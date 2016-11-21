using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEon
{
    class Vehicle
    {
        protected int id;
        protected string vehicle_name;
        protected int capacity;
        protected string drive;
        protected int performance;
        protected double consumption;
        protected string fuel_type;
        protected int weight;
        protected int height;
        protected int length;

        public Vehicle()
        {

        }

        public Vehicle(int id, string name, int capacity, string drive, int perf, double cons, string fuel,
            int wei, int hei, int len)
        {
            this.id = id;
            this.vehicle_name = name;
            this.capacity = capacity;
            this.drive = drive;
            this.performance = perf;
            this.consumption = cons;
            this.fuel_type = fuel;
            this.weight = wei;
            this.height = hei;
            this.length = len;
        }

        public int getID()
        {
            return id;
        }

        public string getVehicle_name()
        {
            return vehicle_name;
        }

        public int getCapacity()
        {
            return capacity;
        }

        public string getDrive()
        {
            return drive;
        }

        public int getPerformance()
        {
            return performance;
        }

        public double getConsumption()
        {
            return consumption;
        }

        public string getFuel_type()
        {
            return fuel_type;
        }

        public int getWeight()
        {
            return weight;
        }

        public int getHeight()
        {
            return height;
        }

        public int getLength()
        {
            return length;
        }

    }
}
