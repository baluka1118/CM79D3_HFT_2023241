using CM79D3_HFT_2023241.Models;
using System;
using ConsoleTools;
using System.Collections.Generic;
using CM79D3_HFT_2023241.Models.ClassesForQueries;
using System.Net.Http;
using System.Net;

namespace CM79D3_HFT_2023241.Client
{
    class Program
    {
        static RestService rest;

        static void ListIncidentTypes(string type) //submenuként megvalósítható
        {
            int i = 0;
            Type t;
            if (type == "incident")
            {
                t = typeof(IncidentType);
            }
            else
            {
                t = typeof(EquipmentCondition);
            }
            foreach (var item in Enum.GetValues(t))
            {
                Console.WriteLine("\t" + item + ":  " + i);
                i++;
            }
        }
        static void Create(string x)
        {
            switch (x)
            {
                case "firestation":
                    Console.Write("Enter FireStation Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter FireStation Location: ");
                    string location = Console.ReadLine();
                    Console.Write("Enter FireStation ContactInformation: ");
                    string contactinformation = Console.ReadLine();
                    try
                    {
                        rest.Post(new FireStation() { Name = name, Location = location, ContactInformation = contactinformation }, "firestation");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                        Console.ReadLine();
                    }
                    break;
                case "firefighter":
                    Console.Write("Enter FireFighter FirstName: ");
                    string firstname = Console.ReadLine();
                    Console.Write("Enter FireFighter LastName: ");
                    string lastname = Console.ReadLine();
                    Console.Write("Enter FireFighter Rank: ");
                    string rank = Console.ReadLine();
                    Console.Write("Enter FireStation ContactInformation: ");
                    string contactinformation2 = Console.ReadLine();
                    Console.Write("Enter FireFighter FireStation_ID: ");
                    int firestationid = int.Parse(Console.ReadLine());
                    rest.Post(new Firefighter() { FirstName = firstname,LastName = lastname, Rank = rank,ContactInformation = contactinformation2, FireStation_ID = firestationid }, "firefighter");
                    break;
                case "equipment":
                    Console.Write("Equipment Conditions to choose from:");
                    ListIncidentTypes("equipment");
                    Console.Write("Enter Equipment Condition:");
                    int condition = int.Parse(Console.ReadLine());
                    Console.Write("Enter Equipment Type: ");
                    string equipmenttype = Console.ReadLine();
                    Console.Write("Enter Equipment Firefighter_ID: ");
                    int firefighterid = int.Parse(Console.ReadLine());
                    rest.Post(new Equipment() {Condition = (EquipmentCondition)condition,Type = equipmenttype, Firefighter_ID = firefighterid }, "equipment");
                    break;
                case "emergencycall":
                    Console.Write("Enter EmergencyCall CallerName: ");
                    string callername = Console.ReadLine();
                    Console.Write("Enter EmergencyCall CallerPhone: ");
                    string callerphone = Console.ReadLine();
                    Console.Write("Enter EmergencyCall IncidentLocation: ");
                    string incidentlocation = Console.ReadLine();
                    Console.Write("Incident Types to choose from:");
                    ListIncidentTypes("incident");
                    Console.Write("Enter EmergencyCall IncidentType: ");
                    int incidenttype = int.Parse(Console.ReadLine());
                    Console.Write("Enter EmergencyCall Date (YYYY.MM.DD): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter EmergencyCall FireStation_ID: ");
                    int firestationid2 = int.Parse(Console.ReadLine());
                    rest.Post(new EmergencyCall() {CallerName = callername, CallerPhone = callerphone, IncidentLocation = incidentlocation, IncidentType = (IncidentType)incidenttype, DateTime = date, FireStation_ID = firestationid2 }, "emergencycall");
                    break;
            }
        }
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

                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "firefighter":
                    var firefighters = rest.Get<Firefighter>("firefighter");
                    Console.WriteLine("LISTING FIREFIGHTERS");
                    foreach (var firefighter in firefighters)
                    {
                        Console.WriteLine(firefighter + "\n");
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "equipment":
                    var equipments = rest.Get<Equipment>("equipment");
                    Console.WriteLine("LISTING EQUIPMENT");
                    foreach (var equipment in equipments)
                    {
                        Console.WriteLine(equipment + "\n");
                    }

                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "emergencycall":
                    var emergencycalls = rest.Get<EmergencyCall>("emergencycall");
                    Console.WriteLine("LISTING EMERGENCYCALLS");
                    foreach (var emergencycall in emergencycalls)
                    {
                        Console.WriteLine(emergencycall + "\n");
                    }

                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                    
            }
        }

        static void ListOne(string x)
        {

            switch (x)
            {
                case "firestation":
                    Console.Write("Enter FireStation ID: ");
                    int id = int.Parse(Console.ReadLine());
                    try
                    {
                        var firestation = rest.Get<FireStation>(id, "firestation");
                        Console.WriteLine("LISTING FIRESTATION");
                        Console.WriteLine(firestation + "\n");
                        Console.WriteLine("Press enter to continue...");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"ArgumentException: {e.Message}");
                    }
                    Console.ReadLine();
                    break;
                case "firefighter":
                    Console.Write("Enter FireFighter ID: ");
                    int id2 = int.Parse(Console.ReadLine());
                    try
                    {
                        var firefighter = rest.Get<Firefighter>(id2, "firefighter");
                        Console.WriteLine("LISTING FIREFIGHTER");
                        Console.WriteLine(firefighter + "\n");
                        Console.WriteLine("Press enter to continue...");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                    break;
                case "equipment":
                    Console.Write("Enter Equipment ID: ");
                    int id3 = int.Parse(Console.ReadLine());
                    try
                    {
                        var equipment = rest.Get<Equipment>(id3, "equipment");
                        Console.WriteLine("LISTING EQUIPMENT");
                        Console.WriteLine(equipment + "\n");
                        Console.WriteLine("Press enter to continue...");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                    break;
                case "emergencycall":
                    Console.Write("Enter EmergencyCall ID: ");
                    int id4 = int.Parse(Console.ReadLine());
                    try
                    {
                        var emergencycall = rest.Get<EmergencyCall>(id4, "emergencycall");
                        Console.WriteLine("LISTING EMERGENCYCALL");
                        Console.WriteLine(emergencycall + "\n");
                        Console.WriteLine("Press enter to continue...");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id,"");
        }
        static void HowManyFirefightersByStation()
        {
            Console.WriteLine("Count of Firefighters per station:");
            var result = rest.Get<KeyValuePair<string,int>>("stat/howmanyfirefightersbystation");
            foreach (var x in result)
            {
                Console.WriteLine("Station: " + x.Key + " Firefighters: " + x.Value);
            }
            Console.ReadLine();
        }

        static void EmergencyCallsCountByStationAndType()
        {
            Console.WriteLine("Count of EmergencyCalls per station and type:");
            var result = rest.Get<KeyValuePair<string, Dictionary<IncidentType, int>>>("stat/emergencycallscountbystationandtype");
            foreach (var x in result)
            {
                Console.WriteLine("Station: " + x.Key);
                foreach (var y in x.Value)
                {
                    Console.WriteLine("\tIncidentType: " + y.Key + " Count: " + y.Value);
                }
            }
            Console.ReadLine();
        }

        static void RankDistribution()
        {
            Console.WriteLine("Distribution of ranks in the Fire Stations:");
            var result = rest.Get<KeyValuePair<string, Dictionary<string, int>>>("stat/rankdistribution");
            foreach (var x in result)
            {
                Console.WriteLine("Station: " + x.Key);
                foreach (var y in x.Value)
                {
                    Console.WriteLine("\tRank: " + y.Key + " Count: " + y.Value);
                }
            }
            Console.ReadLine();
        }

        static void EmergencyCallsBySeason()
        {
            Console.WriteLine("Emergency Calls by season and station:");
            var result = rest.Get<EmergencyCallsBySeasonResult>("stat/emergencycallsbyseason");
            foreach (var x in result)
            {
                Console.WriteLine(x.Season.ToUpper() + $":\n{x.FireStation}'s Emergency Calls:");
                foreach (var VARIABLE in x.EmergencyCalls)
                {
                    Console.WriteLine("\n" + VARIABLE + "\n");
                }
            }
            Console.ReadLine();
        }

        static void FirefightersWithoutEquipment()
        { 
            Console.WriteLine("Firefighters without equipment:");
            var result = rest.Get<Firefighter>("stat/firefighterswithoutequipment");
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:26947/","firestation"); 
            var firestationSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetByID", () => ListOne("firestation"))
                .Add("List", () => List("firestation"))
                .Add("Create", () => Create("firestation"))
                .Add("Delete", () => Delete("firestation"))
                .Add("Update", () => Update("firestation"))
                .Add("Exit", ConsoleMenu.Close);

            var firefighterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetByID", () => ListOne("firefighter"))
                .Add("List", () => List("firefighter"))
                .Add("Create", () => Create("firefighter"))
                .Add("Delete", () => Delete("firefighter"))
                .Add("Update", () => Update("firefighter"))
                .Add("Exit",ConsoleMenu.Close);

            var equipmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetByID", () => ListOne("equipment"))
                .Add("List", () => List("equipment"))
                .Add("Create", () => Create("equipment"))
                .Add("Delete", () => Delete("equipment"))
                .Add("Update", () => Update("equipment"))
                .Add("Exit", ConsoleMenu.Close);

            var emergencycallSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetByID", () => ListOne("emergencycall"))
                .Add("List", () => List("emergencycall"))
                .Add("Create", () => Create("emergencycall"))
                .Add("Delete", () => Delete("emergencycall"))
                .Add("Update", () => Update("emergencycall"))
                .Add("Exit", ConsoleMenu.Close);


            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Get the count of Firefighters per station", () => HowManyFirefightersByStation())
                .Add("Get the count of EmergencyCalls per station and type", () => EmergencyCallsCountByStationAndType())
                .Add("Get the distribution of ranks in the Fire Stations", () => RankDistribution())
                .Add("Get the EmergencyCalls by season and Fire Station", () => EmergencyCallsBySeason())
                .Add("Get the Firefighters without equipment", () => FirefightersWithoutEquipment())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("FireStations", () => firestationSubMenu.Show())
                .Add("FireFighters", () => firefighterSubMenu.Show())
                .Add("Equipments", () => equipmentSubMenu.Show())
                .Add("EmergencyCalls", () => emergencycallSubMenu.Show())
                .Add("Statistics", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }


    }
}
