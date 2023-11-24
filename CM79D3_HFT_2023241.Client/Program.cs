using CM79D3_HFT_2023241.Models;
using System;
using ConsoleTools;
using System.Collections.Generic;
using CM79D3_HFT_2023241.Models.ClassesForQueries;

namespace CM79D3_HFT_2023241.Client
{
    class Program
    {
        static RestService rest;

        static void List(string x)
        {
            switch (x)
            {
                case "firestation":
                    var firestations = rest.Get<FireStation>("firestation");
                    Console.WriteLine("LISTING FIRESTATIONS");
                    foreach (var firestation in firestations)
                    {
                        Console.WriteLine(firestation + "\n");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "firefighter":
                    var firefighters = rest.Get<Firefighter>("firefighter");
                    Console.WriteLine("LISTING FIREFIGHTERS");
                    foreach (var firefighter in firefighters)
                    {
                        Console.WriteLine(firefighter + "\n");
                    }
                    Console.ReadLine();
                    Console.WriteLine("Press any key to continue...");
                    break;
                case "equipment":
                    var equipments = rest.Get<Equipment>("equipment");
                    Console.WriteLine("LISTING EQUIPMENT");
                    foreach (var equipment in equipments)
                    {
                        Console.WriteLine(equipment + "\n");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case "emergencycall":
                    var emergencycalls = rest.Get<EmergencyCall>("emergencycall");
                    Console.WriteLine("LISTING EMERGENCYCALLS");
                    foreach (var emergencycall in emergencycalls)
                    {
                        Console.WriteLine(emergencycall + "\n");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                    
            }
        }
        static void Update(string x)
        {
            throw new NotImplementedException();
        }

        static void Delete(string x)
        {
            throw new NotImplementedException();
        }

        static void Create(string x)
        {
            throw new NotImplementedException();
        }

        static void HowManyFirefightersByStation()
        {
            var result = rest.Get<KeyValuePair<string,int>>("stat/howmanyfirefightersbystation");
        }

        static void EmergencyCallsCountByStationAndType()
        {
            var result = rest.Get<KeyValuePair<string, Dictionary<IncidentType, int>>>("stat/emergencycallscountbystationandtype");
        }

        static void RankDistribution()
        {
            var result = rest.Get<KeyValuePair<string, Dictionary<string, int>>>("stat/rankdistribution");
        }

        static void EmergencyCallsBySeason()
        {
            var result = rest.Get<EmergencyCallsBySeasonResult>("stat/emergencycallsbyseason");
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:26947/","firestation"); 
            var firestationSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("firestation"))
                .Add("Create", () => Create("firestation"))
                .Add("Delete", () => Delete("firestation"))
                .Add("Update", () => Update("firestation"))
                .Add("Exit", ConsoleMenu.Close);

            var firefighterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("firefighter"))
                .Add("Create", () => Create("firefighter"))
                .Add("Delete", () => Delete("firefighter"))
                .Add("Update", () => Update("firefighter"))
                .Add("Exit",ConsoleMenu.Close);

            var equipmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("equipment"))
                .Add("Create", () => Create("equipment"))
                .Add("Delete", () => Delete("equipment"))
                .Add("Update", () => Update("equipment"))
                .Add("Exit", ConsoleMenu.Close);

            var emergencycallSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("emergencycall"))
                .Add("Create", () => Create("emergencycall"))
                .Add("Delete", () => Delete("emergencycall"))
                .Add("Update", () => Update("emergencycall"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("FireStations", () => firestationSubMenu.Show())
                .Add("FireFighters", () => firefighterSubMenu.Show())
                .Add("Equipments", () => equipmentSubMenu.Show())
                .Add("EmergencyCalls", () => emergencycallSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
            ;
        }


    }
}
