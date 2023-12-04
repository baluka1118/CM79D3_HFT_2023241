using CM79D3_HFT_2023241.Models;
using System;
using ConsoleTools;
using System.Collections.Generic;
using CM79D3_HFT_2023241.Models.ClassesForQueries;
using System.Net.Http;
using System.Net;
using System.Linq;

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

        private static void Create(string x)
        {
            switch (x)

            {
                case "firestation":
                    Console.Write("Enter FireStation Name: ");
                    var name = Console.ReadLine();
                    while (string.IsNullOrEmpty(name) || name.Length > 50)
                    {
                        Console.Write("Name cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        name = Console.ReadLine();
                    }

                    Console.Write("Enter FireStation Location: ");
                    var location = Console.ReadLine();
                    while (string.IsNullOrEmpty(location) || location.Length > 50)
                    {
                        Console.Write("Location cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        location = Console.ReadLine();
                    }

                    Console.Write("Enter FireStation ContactInformation: ");
                    var contactinformation = Console.ReadLine();
                    while (string.IsNullOrEmpty(contactinformation) || contactinformation.Length > 50)
                    {
                        Console.Write(
                            "ContactInformation cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        contactinformation = Console.ReadLine();
                    }

                    try
                    {
                        rest.Post(
                            new FireStation
                            {
                                Name = name, Location = location, ContactInformation = contactinformation
                            }, "firestation");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                    break;
                case "firefighter":
                    Console.Write("Enter FireFighter FirstName: ");
                    var firstname = Console.ReadLine();
                    while (string.IsNullOrEmpty(firstname) || firstname.Length > 50)
                    {
                        Console.Write(
                            "FirstName cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        firstname = Console.ReadLine();
                    }

                    Console.Write("Enter FireFighter LastName: ");
                    var lastname = Console.ReadLine();
                    while (string.IsNullOrEmpty(lastname) || lastname.Length > 50)
                    {
                        Console.Write("LastName cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        lastname = Console.ReadLine();
                    }

                    Console.Write("Enter FireFighter Rank: ");
                    var rank = Console.ReadLine();
                    while (rank?.Length > 50)
                    {
                        Console.WriteLine("Rank cannot exceed 50 characters. Please enter a valid value: ");
                        rank = Console.ReadLine();
                    }

                    Console.Write("Enter FireStation ContactInformation: ");
                    var contactinformation2 = Console.ReadLine();
                    while (string.IsNullOrEmpty(contactinformation2) || contactinformation2.Length > 50)
                    {
                        Console.Write(
                            "ContactInformation cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        contactinformation2 = Console.ReadLine();
                    }

                    int firestationid;
                    Console.Write("Enter FireFighter FireStation_ID: ");
                    while (!int.TryParse(Console.ReadLine(), out firestationid))
                        Console.Write("Please enter a valid integer for FireStation_ID: ");
                    try
                    {
                        rest.Post(
                            new Firefighter
                            {
                                FirstName = firstname,
                                LastName = lastname,
                                Rank = rank,
                                ContactInformation = contactinformation2,
                                FireStation_ID = firestationid
                            }, "firefighter");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "equipment":
                    Console.Write("Equipment Conditions to choose from:");
                    ListIncidentTypes("equipment");
                    int condition;
                    Console.Write("Enter Equipment Condition:");
                    while (!int.TryParse(Console.ReadLine(), out condition) || condition < 0 || condition > 4)
                        Console.Write("Please enter a valid integer for Equipment Condition: ");
                    Console.Write("Enter Equipment Type: ");
                    var equipmenttype = Console.ReadLine();
                    while (string.IsNullOrEmpty(equipmenttype) || equipmenttype.Length > 50)
                    {
                        Console.Write(
                            "Equipment Type cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        equipmenttype = Console.ReadLine();
                    }

                    int firefighterid;
                    Console.Write("Enter Equipment Firefighter_ID: ");
                    while (!int.TryParse(Console.ReadLine(), out firefighterid))
                        Console.Write("Please enter a valid integer for Firefighter_ID: ");
                    try
                    {
                        rest.Post(
                            new Equipment
                            {
                                Condition = (EquipmentCondition)condition,
                                Type = equipmenttype,
                                Firefighter_ID = firefighterid
                            }, "equipment");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                    break;
                case "emergencycall":
                    Console.Write("Enter EmergencyCall CallerName: ");
                    var callername = Console.ReadLine();
                    while (string.IsNullOrEmpty(callername) || callername.Length > 50)
                    {
                        Console.Write(
                            "CallerName cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        callername = Console.ReadLine();
                    }

                    Console.Write("Enter EmergencyCall CallerPhone: ");
                    var callerphone = Console.ReadLine();
                    while (string.IsNullOrEmpty(callerphone) || callerphone.Length > 50)
                    {
                        Console.Write(
                            "CallerPhone cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        callerphone = Console.ReadLine();
                    }

                    Console.Write("Enter EmergencyCall IncidentLocation: ");
                    var incidentlocation = Console.ReadLine();
                    while (string.IsNullOrEmpty(incidentlocation) || incidentlocation.Length > 50)
                    {
                        Console.Write(
                            "IncidentLocation cannot be empty or exceed 50 characters. Please enter a valid value: ");
                        incidentlocation = Console.ReadLine();
                    }

                    Console.Write("Incident Types to choose from:");
                    ListIncidentTypes("incident");
                    int incidenttype;
                    Console.Write("Enter EmergencyCall IncidentType: ");
                    while (!int.TryParse(Console.ReadLine(), out incidenttype) || incidenttype < 0 || incidenttype > 6)
                        Console.Write("Please enter a valid integer for IncidentType: ");
                    DateTime date;
                    Console.Write("Enter EmergencyCall Date (YYYY.MM.DD): ");
                    while (!DateTime.TryParse(Console.ReadLine(), out date))
                        Console.Write("Please enter a valid date in the format YYYY.MM.DD: ");
                    int firestationid2;
                    Console.Write("Enter EmergencyCall FireStation_ID: ");
                    while (!int.TryParse(Console.ReadLine(), out firestationid2))
                        Console.Write("Please enter a valid integer for FireStation_ID: ");
                    try
                    {
                        rest.Post(
                            new EmergencyCall
                            {
                                CallerName = callername,
                                CallerPhone = callerphone,
                                IncidentLocation = incidentlocation,
                                IncidentType = (IncidentType)incidenttype,
                                DateTime = date,
                                FireStation_ID = firestationid2
                            }, "emergencycall");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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
                    int id;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.Write("Please enter a valid integer for ID: ");
                    }
                    try
                    {
                        var firestation = rest.Get<FireStation>(id, "firestation");
                        Console.WriteLine("LISTING FIRESTATION");
                        Console.WriteLine(firestation + "\n");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "firefighter":
                    Console.Write("Enter FireFighter ID: ");
                    int id2;
                    while (!int.TryParse(Console.ReadLine(), out id2))
                    {
                        Console.Write("Please enter a valid integer for ID: ");
                    }
                    try
                    {
                        var firefighter = rest.Get<Firefighter>(id2, "firefighter");
                        Console.WriteLine("LISTING FIREFIGHTER");
                        Console.WriteLine(firefighter + "\n");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "equipment":
                    Console.Write("Enter Equipment ID: ");
                    int id3;
                    while (!int.TryParse(Console.ReadLine(), out id3))
                    {
                        Console.Write("Please enter a valid integer for ID: ");
                    }
                    try
                    {
                        var equipment = rest.Get<Equipment>(id3, "equipment");
                        Console.WriteLine("LISTING EQUIPMENT");
                        Console.WriteLine(equipment + "\n");
                        
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "emergencycall":
                    Console.Write("Enter EmergencyCall ID: ");
                    int id4;
                    while (!int.TryParse(Console.ReadLine(), out id4))
                    {
                        Console.Write("Please enter a valid integer for ID: ");
                    }
                    try
                    {
                        var emergencycall = rest.Get<EmergencyCall>(id4, "emergencycall");
                        Console.WriteLine("LISTING EMERGENCYCALL");
                        Console.WriteLine(emergencycall + "\n");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
        static void Update(string x)
        {
            Console.Write($"Would you like to list the {x}s before choosing? (Y/N) ");
            string reply = Console.ReadLine();
            while (reply != "Y" && reply != "N")
            {
                Console.Write("Wrong input, try again! ");
                reply = Console.ReadLine();
            }
            if (reply == "Y")
            {
                Console.WriteLine($"LISTING {x.ToUpper()}'S");
                List(x);
            }
            int id;
            Console.WriteLine("First enter the ID of the entity you want to update. If it is a valid ID, the properties of it will be listed." +
                "\nPut '-' to each property you dont want to change. If you do, enter the value.");
            Console.Write("Enter the choosen ID: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Please enter a valid integer for ID: ");
            }
            switch (x)
            {
                case "firestation":
                    try
                    {
                        Console.WriteLine("-LISTING THE CHOOSEN ENTITY-");
                        var changing = rest.Get<FireStation>(id, "firestation");
                        Console.WriteLine(changing);
                        FireStation fs = new FireStation() { Id = id };
                        foreach (var property in typeof(FireStation).GetProperties().Where(t => t.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null && t.Name != "Id")) //Listing every property thats not virtual, nor the id
                        {
                            Console.Write(property.Name + ":");
                            if (property.PropertyType == typeof(int)) //if the property is an integer
                            {
                                int set;
                                string s = Console.ReadLine();
                                if (s != "-" && !int.TryParse(s, out set)) //if the input cant be converted to int
                                {
                                    Console.Write("Please enter a valid integer.");
                                    while (!int.TryParse(Console.ReadLine(), out set)) //ask for new input until it is a valid integer
                                    {
                                        Console.Write("Please enter a valid integer.");
                                    }
                                    property.SetValue(fs, set);
                                }
                                else if (s != "-") //set
                                {
                                    property.SetValue(fs, int.Parse(s));
                                }
                                else //skip, so set the original value
                                {
                                    property.SetValue(fs, property.GetValue(changing));
                                }
                                
                            }
                            else
                            {
                                string re = Console.ReadLine();
                                while (re == string.Empty) //avoiding exception by not accepting empty string
                                {
                                    Console.Write("Please give a valid input. ");
                                    re = Console.ReadLine();
                                }
                                if (re != "-") //set
                                {
                                    if (property.GetValue(fs) != re) //seeing if the 
                                    {
                                        property.SetValue(fs, re);
                                    }
                                }
                                else //skip, so setting the original value
                                {
                                    property.SetValue(fs, property.GetValue(changing));
                                }
                            }
                            
                        }
                        rest.Put(fs, "firestation");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                    break;
                case "firefighter":
                    try
                    {
                        Console.WriteLine("-LISTING THE CHOOSEN ENTITY-");
                        var changing = rest.Get<Firefighter>(id, "firefighter");
                        Console.WriteLine(changing);
                        Firefighter ff = new Firefighter() { Id = id };
                        foreach (var property in typeof(Firefighter).GetProperties().Where(t => t.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null && t.Name != "Id"))
                        {
                            Console.Write(property.Name + ":");
                            if (property.PropertyType == typeof(int))
                            {
                                int set;
                                string s = Console.ReadLine();
                                if (s != "-" && !int.TryParse(s, out set))
                                {
                                    Console.Write("Please enter a valid integer.");
                                    while (!int.TryParse(Console.ReadLine(), out set))
                                    {
                                        Console.Write("Please enter a valid integer.");
                                    }
                                    property.SetValue(ff, set);
                                }
                                else if (s != "-")
                                {
                                    property.SetValue(ff, int.Parse(s));
                                }
                                else
                                {
                                    property.SetValue(ff, property.GetValue(changing));
                                }

                            }
                            else
                            {
                                string re = Console.ReadLine();
                                while (re == string.Empty)
                                {
                                    Console.Write("Please give a valid input. ");
                                    re = Console.ReadLine();
                                }
                                if (re != "-")
                                {
                                    if (property.GetValue(ff) != re)
                                    {
                                        property.SetValue(ff, re);
                                    }
                                }
                                else
                                {
                                    property.SetValue(ff, property.GetValue(changing));
                                }
                            }

                        }
                        rest.Put(ff, "firefighter");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                    break;
                case "equipment":
                    try
                    {
                        Console.WriteLine("-LISTING THE CHOOSEN ENTITY-");
                        var changing = rest.Get<Equipment>(id, "equipment");
                        Console.WriteLine(changing);
                        Equipment eq = new Equipment() { Id = id };
                        foreach (var property in typeof(Equipment).GetProperties().Where(t => t.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null && t.Name != "Id"))
                        {
                            Console.Write(property.Name + ":");
                            if (property.PropertyType == typeof(int))
                            {
                                int set;
                                string s = Console.ReadLine();
                                if (s != "-" && !int.TryParse(s, out set))
                                {
                                    Console.Write("Please enter a valid integer.");
                                    while (!int.TryParse(Console.ReadLine(), out set))
                                    {
                                        Console.Write("Please enter a valid integer.");
                                    }
                                    property.SetValue(eq, set);
                                }
                                else if (s != "-")
                                {
                                    property.SetValue(eq, int.Parse(s));
                                }
                                else
                                {
                                    property.SetValue(eq, property.GetValue(changing));
                                }

                            }
                            else if (property.PropertyType == typeof(EquipmentCondition))
                            {
                                Console.WriteLine();
                                ListIncidentTypes("equipment");
                                int set;
                                string s = Console.ReadLine();
                                if (s != "-" && (!int.TryParse(s, out set) || int.Parse(s) <0 || int.Parse(s) > 4))
                                {
                                    Console.Write("Please enter a valid integer.");
                                    while (!int.TryParse(Console.ReadLine(), out set))
                                    {
                                        Console.Write("Please enter a valid integer.");
                                    }
                                    while (set <0 || set > 4)
                                    {
                                        Console.WriteLine("Please give a number between 0 and 4");
                                        while (!int.TryParse(Console.ReadLine(), out set))
                                        {
                                            Console.Write("Please enter a valid integer.");
                                        }
                                    }
                                    property.SetValue(eq, set);
                                }
                                else if (s != "-")
                                {
                                    property.SetValue(eq, (EquipmentCondition)int.Parse(s));
                                }
                                else
                                {
                                    property.SetValue(eq, property.GetValue(changing));
                                }
                            }
                            else
                            {
                                string re = Console.ReadLine();
                                while (re == string.Empty)
                                {
                                    Console.Write("Please give a valid input. ");
                                    re = Console.ReadLine();
                                }
                                if (re != "-")
                                {
                                    if (property.GetValue(eq) != re)
                                    {
                                        property.SetValue(eq, re);
                                    }
                                }
                                else
                                {
                                    property.SetValue(eq, property.GetValue(changing));
                                }
                            }

                        }
                        rest.Put(eq, "equipment");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                    break;
                case "emergencycall": 
                    try
                    {
                        Console.WriteLine("-LISTING THE CHOOSEN ENTITY-");
                        var changing = rest.Get<EmergencyCall>(id, "emergencycall");
                        Console.WriteLine(changing);
                        EmergencyCall ec = new EmergencyCall() { Id = id };
                        foreach (var property in typeof(EmergencyCall).GetProperties().Where(t => t.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null && t.Name != "Id"))
                        {
                            Console.Write(property.Name + ":");
                            if (property.PropertyType == typeof(int))
                            {
                                int set;
                                string s = Console.ReadLine();
                                if (s != "-" && !int.TryParse(s, out set))
                                {
                                    Console.Write("Please enter a valid integer.");
                                    while (!int.TryParse(Console.ReadLine(), out set))
                                    {
                                        Console.Write("Please enter a valid integer.");
                                    }
                                    property.SetValue(ec, set);
                                }
                                else if (s != "-")
                                {
                                    property.SetValue(ec, int.Parse(s));
                                }
                                else
                                {
                                    property.SetValue(ec, property.GetValue(changing));
                                }

                            }
                            else if (property.PropertyType == typeof(DateTime))
                            {
                                DateTime set;
                                string s = Console.ReadLine();
                                if (s != "-" && !DateTime.TryParse(s, out set))
                                {
                                    Console.Write("Please enter a valid DateTime (YYYY.MM.DD)");
                                    while (!DateTime.TryParse(Console.ReadLine(), out set))
                                    {
                                        Console.Write("Please enter a valid DateTime. (YYYY.MM.DD)");
                                    }
                                    property.SetValue(ec, set);
                                }
                                else if (s != "-")
                                {
                                    property.SetValue(ec, int.Parse(s));
                                }
                                else
                                {
                                    property.SetValue(ec, property.GetValue(changing));
                                }

                            }
                            else if (property.PropertyType == typeof(IncidentType))
                            {
                                Console.WriteLine();
                                ListIncidentTypes("incident");
                                int set;
                                string s = Console.ReadLine();
                                if (s != "-" && (!int.TryParse(s, out set) || int.Parse(s) < 0 || int.Parse(s) > 6))
                                {
                                    Console.Write("Please enter a valid integer.");
                                    while (!int.TryParse(Console.ReadLine(), out set))
                                    {
                                        Console.Write("Please enter a valid integer.");
                                    }
                                    while (set < 0 || set > 6)
                                    {
                                        Console.WriteLine("Please give a number between 0 and 6");
                                        while(!int.TryParse(Console.ReadLine(), out set))
                                        {
                                            Console.Write("Please enter a valid integer.");
                                        }
                                    }
                                    property.SetValue(ec, set);
                                }
                                else if (s != "-")
                                {
                                    property.SetValue(ec, (IncidentType)int.Parse(s));
                                }
                                else
                                {
                                    property.SetValue(ec, property.GetValue(changing));
                                }
                            }
                            else
                            {
                                string re = Console.ReadLine();
                                while (re == string.Empty)
                                {
                                    Console.Write("Please give a valid input. ");
                                    re = Console.ReadLine();
                                }
                                if (re != "-")
                                {
                                    if (property.GetValue(ec) != re)
                                    {
                                        property.SetValue(ec, re);
                                    }
                                }
                                else
                                {
                                    property.SetValue(ec, property.GetValue(changing));
                                }
                            }

                        }
                        rest.Put(ec, "emergencycall");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                    break;
            }
        }

        static void Delete(string x)
        {
            Console.Write($"Would you like to list the {x}s before choosing? (Y/N) ");
            string reply = Console.ReadLine();
            while (reply != "Y" && reply != "N")
            {
                Console.Write("Wrong input, try again! ");
                reply = Console.ReadLine();
            }
            if (reply == "Y")
            {
                Console.WriteLine($"LISTING {x.ToUpper()}'S");
                List(x);
            }
            int id;
            Console.Write("Enter the choosen ID: ");
            while (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.Write("Please enter a valid integer for ID: ");
            }
            switch (x)
            {
                case "firestation":
                    try
                    {
                        rest.Delete(id, "firestation");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "firefighter":
                    try
                    {
                        rest.Delete(id, "firefighter");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "equipment":
                    try
                    {
                        rest.Delete(id, "equipment");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "emergencycall":
                    try
                    {
                        rest.Delete(id, "emergencycall");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
        static void HowManyFirefightersByStation()
        {
            Console.WriteLine("Count of Firefighters per station:");
            var result = rest.Get<FireStationWithFirefighterCount>("stat/howmanyfirefightersbystation");
            foreach (var x in result)
            {
                Console.WriteLine("Station: " + x.Name + "|| Firefighters: " + x.FirefighterCount);
            }
            Console.ReadLine();
        }

        static void EmergencyCallsCountByStationAndType()
        {
            Console.WriteLine("Count of EmergencyCalls per station and type:");
            var result = rest.Get<FireStationWithEmergencyCallCountByType>("stat/emergencycallscountbystationandtype");
            foreach (var x in result)
            {
                Console.WriteLine("Station: " + x.Name);
                foreach (var y in x.EmergencyCallCounts)
                {
                    Console.WriteLine("\tIncidentType: " + y.IncidentType + " Count: " + y.Count);
                }
            }
            Console.ReadLine();
        }

        static void RankDistribution()
        {
            Console.WriteLine("Distribution of ranks in the Fire Stations:");
            var result = rest.Get<FireStationWithRankDistribution>("stat/rankdistribution");
            foreach (var x in result)
            {
                Console.WriteLine("Station: " + x.Name);
                foreach (var y in x.RankDistribution)
                {
                    Console.WriteLine("\tRank: " + y.Rank + " Count: " + y.Count);
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
                Console.WriteLine(x.Season.ToUpper() + $":\n{x.FireStation}'s Emergency Calls:\n");
                foreach (var VARIABLE in x.EmergencyCalls)
                {
                    Console.WriteLine("--EMERGENCY CALL--");
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
            rest = new RestService("http://localhost:26947/", "firestation"); 
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
