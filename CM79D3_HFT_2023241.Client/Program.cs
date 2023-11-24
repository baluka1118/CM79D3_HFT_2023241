using CM79D3_HFT_2023241.Models;
using System;
using ConsoleTools;
using System.Collections.Generic;


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
                    foreach (var firestation in firestations)
                    {
                        Console.WriteLine(firestation);
                    }
                    break;
                case "firefighter":
                    var firefighters = rest.Get<Firefighter>("firefighter");
                    foreach (var firefighter in firefighters)
                    {
                        Console.WriteLine(firefighter);
                    }
                    break;
                case "equipment":
                    var equipments = rest.Get<Equipment>("equipment");
                    foreach (var equipment in equipments)
                    {
                        Console.WriteLine(equipment);
                    }
                    break;
                case "emergencycall":
                    var emergencycalls = rest.Get<EmergencyCall>("emergencycall");
                    foreach (var emergencycall in emergencycalls)
                    {
                        Console.WriteLine(emergencycall);
                    }
                    break;
            }
        }
        static void Update(string firestation)
        {
            throw new NotImplementedException();
        }

        static void Delete(string firestation)
        {
            throw new NotImplementedException();
        }

        static void Create(string firestation)
        {
            throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:26947/","firestation"); //???exception vagy benne ragad

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
