using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEon
{
    public class Feladatok
    {
        protected string feladat_neve;
        protected string varos;
        protected string utca;
        protected int hazszam;
        protected string leiras;
        protected string hatarido;       //2016-11-04 formátum
        protected string rogzites_ideje; //2016-11-04 formátum
        protected string prioritas;
        string eszkoz;
        string kepesites;
        public List<string> eszkozok = new List<string>();
        public List<string> kepesitesek = new List<string>();
        protected string megjegyzes;

        public List<string> Eszkozok
        {
            get
            {
                return eszkozok;
            }

            set
            {
                eszkozok = value;
            }
        }

        public Feladatok()
        {
            feladat_neve = "";
            varos = "";
            utca = "";
            hazszam = 0;
            leiras = "";
            hatarido = "";
            rogzites_ideje = "";
            prioritas = "";
            megjegyzes = "";

        }

        public Feladatok(string fnev, string varos, string utca, int hazszam,
            string leiras, string hatarido, string rogzites_ideje, string prioritas,
            string eszkoz, string kepesites, string megjegyzes)
        {
            this.feladat_neve = fnev;
            this.varos = varos;
            this.utca = utca;
            this.hazszam = hazszam;
            this.leiras = leiras;
            this.hatarido = hatarido;
            this.rogzites_ideje = rogzites_ideje;
            this.prioritas = prioritas;
            this.eszkoz = eszkoz;

            string[] str = eszkoz.Split(',');
            foreach (string i in str)
            {
                if (!i.Equals(""))
                {
                    eszkozok.Add(i);
                }
            }

            this.kepesites = kepesites;
            string[] str2 = kepesites.Split(',');
            foreach (string i in str2)
            {
                if (!i.Equals(""))
                {
                    kepesitesek.Add(i);
                }
            }


            this.megjegyzes = megjegyzes;

        }


        public string getFeladat_neve()
        {
            return feladat_neve;
        }

        public string getVaros()
        {
            return varos;
        }

        public string getUtca()
        {
            return utca;
        }

        public int getHazszam()
        {
            return hazszam;
        }

        public string getLeiras()
        {
            return leiras;
        }

        public string getHatarido()
        {
            return hatarido;
        }

        public string getRogzites_ideje()
        {
            return rogzites_ideje;
        }

        public string getPrioritas()
        {
            return prioritas;
        }

        public string getMegjegyzes()
        {
            return megjegyzes;
        }
 
    }
}
