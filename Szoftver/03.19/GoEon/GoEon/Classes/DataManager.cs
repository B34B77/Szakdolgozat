using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEon
{
    public static class DataManager
    {
        static Database_Manager db = new Database_Manager();

        static List<Team> team_after_taskmanager = new List<Team>();

        //Beolvassa az összes feladatot
        public static List<Feladatok> BeolvasFeladatok(List<Feladatok> task)
        {
            db.Read_Task(task);

            return task;
        }

        //Beolvassa a feladatokat, majd kitörli azokat amelyek már el lettek végezve
        public static List<Feladatok> BeolvasFeladatok_ElvegzettekNelkul(List<Feladatok> task)
        {
            db.Read_Task(task);

            for(int x = task.Count - 1; x>=0; x--)
            {
                if (!task[x].getElvegezve().Equals("-"))
                {
                    task.RemoveAt(x);
                }
            }

            return task;
        }

        //Beolvassa az összes csapatot
        public static List<Team> BeolvasCsapatok(List<Team> team)
        {
            db.Read_Team(team);

            return team;
        }

        //Beolvassa a tárolt hozzárendeléseket
        public static List<Administration> BeolvasAdministration(List<Administration> administrations)
        {
            db.Read_Administraton(administrations);

            return administrations;
        }

        //Beolvassa az eszkozoket
        public static List<Equipmet> BeolvasEszkozok(List<Equipmet> equipments)
        {
            db.Read_Equipments(equipments);

            return equipments;
        }

        //Beolvassa a járműveket
        public static List<Vehicle> BeolvasJarmuvek(List<Vehicle> vehicles)
        {
            db.Read_Vehicle(vehicles);

            return vehicles;
        }

        //Beolvassa az embereket
        public static List<Person> BeolvasKEmberek(List<Person> persons)
        {
            db.Read_Person(persons);

            return persons;
        }

        //Beolvass a feladatokat a hozzájuk rendelt feladatokkal együtt
        public static List<Team> BeolvasCsapatok_FeladatokkalEgyutt(List<Team> team)
        {
            List<Administration> administrations = new List<Administration>();
            List<Feladatok> feladatok = new List<Feladatok>();
            db.Read_Task(feladatok);
            db.Read_Administraton(administrations);
            db.Read_Team(team);
            

            foreach (Administration ad in administrations)
            {
                foreach (Team tem in team)
                {
                    if (tem.getTeam_name().Equals(ad.getTeam_name()))
                    {
                        foreach (int i in ad.task_id)
                        {
                            foreach (Feladatok fe in feladatok)
                            {
                                if (fe.getID() == i)
                                {
                                    tem.addTask(ad.getDate(), fe);
                                }
                            }
                        }
                    }
                }
            }

            return team;
        }

        
        //Belvassa a feladatokat és kitörli a listából azokat amik már hozzá lettek rendelve egy csapathoz, illetve azokat emelyek már el lettek végezve
        public static List<Feladatok> HozzarendelesreVaroFeladatok(List<Feladatok> feladatok)
        {
            List<Administration> administrations = new List<Administration>();
            db.Read_Task(feladatok);
            db.Read_Administraton(administrations);

            foreach (Administration ad in administrations)
            {
                foreach (int i in ad.task_id)
                {
                    for (int j = feladatok.Count - 1; j >= 0; j--)
                    {
                        if (feladatok[j].getID() == i)
                        {
                            feladatok.RemoveAt(j);
                        }
                    }
                }

            }

            for (int x = feladatok.Count - 1; x >= 0; x--)
            {
                if (!feladatok[x].getElvegezve().Equals("-"))
                {
                    feladatok.RemoveAt(x);
                }
            }

            return feladatok;
        }


        public static  void setTeamList(List<Team> team)
        {
            team_after_taskmanager = team;
        }

        public static List<Team> getTeamList()
        {
            return team_after_taskmanager;
        }
    

    }
}
