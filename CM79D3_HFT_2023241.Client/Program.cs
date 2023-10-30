using CM79D3_HFT_2023241.Repository;
using System;
using System.Linq;

namespace CM79D3_HFT_2023241.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            FireFightingDbContext db = new FireFightingDbContext();
            Console.WriteLine("--FIREFIGHTERS BY FIRESTATIONS--");
            foreach (var item in db.FireStations)
            {
                Console.WriteLine(item.Name);
                foreach (var item2 in item.Firefighters)
                {
                    Console.WriteLine("\t"+item2.FirstName + " " + item2.LastName);
                }
            }
            Console.WriteLine("--EQUIPMENTS BY FIREFIGHTER--");
            foreach (var item in db.Firefighters)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
                foreach (var item2 in item.Equipment)
                {
                    Console.WriteLine("\t" + item2.Type + " " + item2.Condition.ToString());
                }
            }
            ;
        }
    }
}
