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
                    rest.Post(new FireStation() { Name = name, Location = location, ContactInformation = contactinformation }, "firestation");
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
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
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
        }


    }
}
