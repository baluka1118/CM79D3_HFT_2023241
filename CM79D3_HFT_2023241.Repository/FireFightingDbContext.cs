using CM79D3_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Repository
{
    public class FireFightingDbContext : DbContext
    {
        public virtual DbSet<FireStation> FireStations { get; set; }
        public virtual DbSet<Firefighter> Firefighters { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EmergencyCall> EmergencyCalls { get; set; }
        public virtual DbSet<HasEquipment> HasEquipment { get; set; }
        public virtual DbSet<OnCall> OnCall { get; set; }
        public FireFightingDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename=|DataDirectory|\TemporaryDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                .UseSqlServer(conn)
                .UseLazyLoadingProxies();
                //.UseInMemoryDatabase("DATABASE");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firefighter>(fighter =>
                fighter.HasOne(fighter => fighter.FireStation)
                       .WithMany(station => station.Firefighters)
                       .HasForeignKey(fighter => fighter.FireStation_ID)
                       .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Equipment>()
                .HasMany(x => x.Firefighters)
                .WithMany(x => x.Equipment)
                .UsingEntity<HasEquipment>(
                    x => x.HasOne(x => x.Firefighter)
                    .WithMany().HasForeignKey(x => x.FirefighterId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.Equipment)
                    .WithMany().HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<EmergencyCall>()
                .HasMany(x => x.Firefighters)
                .WithMany(x => x.EmergencyCalls)
                .UsingEntity<OnCall>(
                    x => x.HasOne(x => x.Firefighter)
                    .WithMany().HasForeignKey(x => x.FirefighterId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.EmergencyCall)
                    .WithMany().HasForeignKey(x => x.EmergencyCallId).OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<FireStation>().HasData(new FireStation[]
            {
                new FireStation { Id = 1, Name = "Central Fire Station", Location = "123 Main St, Cityville, State", ContactInformation = "123-456-7890" },
                new FireStation { Id = 2, Name = "Eastside Fire Department", Location = "456 Elm St, Townsville, State", ContactInformation = "987-654-3210" },
                new FireStation { Id = 3, Name = "West End Firehouse", Location = "789 Oak St, Villageburg, State", ContactInformation = "555-123-4567" },
                new FireStation { Id = 4, Name = "Downtown Fire Station", Location = "234 Pine St, Metroville, State", ContactInformation = "111-222-3333" },
                new FireStation { Id = 5, Name = "Southside Fire Department", Location = "789 Birch St, Suburbia, State", ContactInformation = "444-555-6666" },
            });

            modelBuilder.Entity<Firefighter>().HasData(new Firefighter[]
            {
                // Fire Station 1
                new Firefighter { Id = 1, FirstName = "John", LastName = "Smith", Rank = "Captain", ContactInformation = "111-222-3333", FireStation_ID = 1 },
                new Firefighter { Id = 2, FirstName = "Jane", LastName = "Doe", Rank = "Lieutenant", ContactInformation = "444-555-6666", FireStation_ID = 1 },
                new Firefighter { Id = 3, FirstName = "Andrew", LastName = "Gonzalez", Rank = "Firefighter", ContactInformation = "123-234-5678", FireStation_ID = 1 },
                new Firefighter { Id = 4, FirstName = "Avery", LastName = "Green", Rank = "Firefighter", ContactInformation = "555-444-3333", FireStation_ID = 1 },
                new Firefighter { Id = 5, FirstName = "Daniel", LastName = "Miller", Rank = "Firefighter", ContactInformation = "123-234-5678", FireStation_ID = 1 },
    
                // Fire Station 2
                new Firefighter { Id = 6, FirstName = "Robert", LastName = "Johnson", Rank = "Captain", ContactInformation = "777-888-9999", FireStation_ID = 2 },
                new Firefighter { Id = 7, FirstName = "Linda", LastName = "Williams", Rank = "Firefighter", ContactInformation = "999-888-7777", FireStation_ID = 2 },
                new Firefighter { Id = 8, FirstName = "Benjamin", LastName = "Harris", Rank = "Firefighter", ContactInformation = "999-999-9999", FireStation_ID = 2 },
                new Firefighter { Id = 9, FirstName = "Catherine", LastName = "Scott", Rank = "Firefighter", ContactInformation = "555-444-3333", FireStation_ID = 2 },
                new Firefighter { Id = 10, FirstName = "Ella", LastName = "Ward", Rank = "Firefighter", ContactInformation = "555-444-3333", FireStation_ID = 2 },

                // Fire Station 3
                new Firefighter { Id = 11, FirstName = "Michael", LastName = "Brown", Rank = "Captain", ContactInformation = "555-123-4567", FireStation_ID = 3 },
                new Firefighter { Id = 12, FirstName = "Sarah", LastName = "Davis", Rank = "Lieutenant", ContactInformation = "987-654-3210", FireStation_ID = 3 },
                new Firefighter { Id = 13, FirstName = "Mark", LastName = "Allen", Rank = "Firefighter", ContactInformation = "111-111-1111", FireStation_ID = 3 },
                new Firefighter { Id = 14, FirstName = "Emily", LastName = "Wright", Rank = "Firefighter", ContactInformation = "333-222-1111", FireStation_ID = 3 },
                new Firefighter { Id = 15, FirstName = "Ethan", LastName = "Evans", Rank = "Firefighter", ContactInformation = "999-999-9999", FireStation_ID = 3 },

                // Fire Station 4
                new Firefighter { Id = 16, FirstName = "William", LastName = "Garcia", Rank = "Firefighter", ContactInformation = "123-456-7890", FireStation_ID = 4 },
                new Firefighter { Id = 17, FirstName = "Karen", LastName = "Hall", Rank = "Firefighter", ContactInformation = "666-555-4444", FireStation_ID = 4 },
                new Firefighter { Id = 18, FirstName = "Nicholas", LastName = "Roberts", Rank = "Captain", ContactInformation = "555-222-1111", FireStation_ID = 4 },
                new Firefighter { Id = 19, FirstName = "Olivia", LastName = "Lee", Rank = "Lieutenant", ContactInformation = "333-222-1111", FireStation_ID = 4 },
                new Firefighter { Id = 20, FirstName = "Grace", LastName = "Hernandez", Rank = "Firefighter", ContactInformation = "444-666-8888", FireStation_ID = 4 },
    
                // Fire Station 5
                new Firefighter { Id = 21, FirstName = "David", LastName = "Martinez", Rank = "Firefighter", ContactInformation = "555-555-5555", FireStation_ID = 5 },
                new Firefighter { Id = 22, FirstName = "Nancy", LastName = "Lewis", Rank = "Lieutenant", ContactInformation = "777-777-7777", FireStation_ID = 5 },
                new Firefighter { Id = 23, FirstName = "Matthew", LastName = "Hall", Rank = "Firefighter", ContactInformation = "555-123-4567", FireStation_ID = 5 },
                new Firefighter { Id = 24, FirstName = "Ava", LastName = "Adams", Rank = "Firefighter", ContactInformation = "987-654-3210", FireStation_ID = 5 },
                new Firefighter { Id = 25, FirstName = "Liam", LastName = "Morris", Rank = "Captain", ContactInformation = "111-111-1111", FireStation_ID = 5 },
            });
            modelBuilder.Entity<Equipment>().HasData(new Equipment[]
            {
                new Equipment { Id = 1, Type = "Fire Hose", Condition = EquipmentCondition.Good},
                new Equipment { Id = 2, Type = "AED", Condition = EquipmentCondition.New},
                new Equipment { Id = 3, Type = "Ladder", Condition = EquipmentCondition.Good},
                new Equipment { Id = 4, Type = "Fire Extinguisher", Condition = EquipmentCondition.Fair},
                new Equipment { Id = 5, Type = "Bunker Gear", Condition = EquipmentCondition.Good },
                new Equipment { Id = 6, Type = "Thermal Imaging Camera", Condition = EquipmentCondition.New },
                new Equipment { Id = 7, Type = "Jaws of Life", Condition = EquipmentCondition.Poor},
                new Equipment { Id = 8, Type = "Oxygen Tank", Condition = EquipmentCondition.Good },
                new Equipment { Id = 9, Type = "Fire Hose", Condition = EquipmentCondition.Good },
                new Equipment { Id = 10, Type = "First Aid Kit", Condition = EquipmentCondition.Fair},
            });
            modelBuilder.Entity<EmergencyCall>().HasData(new EmergencyCall[]
            {
                new EmergencyCall { Id = 1, CallerName = "911 Operator", CallerPhone = "123-477-7891", IncidentLocation = "123 Elm St, Cityville", IncidentType = IncidentType.Fire, DateTime = DateTime.Now},
                new EmergencyCall { Id = 2, CallerName = "John Doe", IncidentLocation = "456 Oak St, Townsville", IncidentType = IncidentType.MedicalEmergency, DateTime = DateTime.Now },
                new EmergencyCall { Id = 3, CallerName = "Jane Smith", IncidentLocation = "789 Pine St, Villageburg", IncidentType = IncidentType.Rescue, DateTime = DateTime.Now },
                new EmergencyCall { Id = 4, CallerName = "Robert Johnson",CallerPhone = "623-673-8211", IncidentLocation = "234 Cedar St, Metroville", IncidentType = IncidentType.HazardousMaterials, DateTime = DateTime.Now },
                new EmergencyCall { Id = 5, CallerName = "Linda Williams", IncidentLocation = "555 Willow St, Suburbia", IncidentType = IncidentType.NaturalDisaster, DateTime = DateTime.Now },
                new EmergencyCall { Id = 6, CallerName = "Michael Brown", CallerPhone = "523-173-8811", IncidentLocation = "789 Fir St, Ruralville", IncidentType = IncidentType.FalseAlarm, DateTime = DateTime.Now },
                new EmergencyCall { Id = 7, CallerName = "Sarah Davis", IncidentLocation = "987 Birch St, Mountainside", IncidentType = IncidentType.Other, DateTime = DateTime.Now },
                new EmergencyCall { Id = 8, CallerName = "William Garcia", IncidentLocation = "345 Maple St, Beachtown", IncidentType = IncidentType.MedicalEmergency, DateTime = DateTime.Now },
                new EmergencyCall { Id = 9, CallerName = "Karen Hall", IncidentLocation = "321 Cedar St, Towncenter", IncidentType = IncidentType.HazardousMaterials, DateTime = DateTime.Now },
                new EmergencyCall { Id = 10, CallerName = "David Martinez", IncidentLocation = "666 Oak St, Riverside", IncidentType = IncidentType.Fire, DateTime = DateTime.Now },
            });
            modelBuilder.Entity<HasEquipment>().HasData(new HasEquipment[]
            {
                new HasEquipment { HasEquipmentId = 1, EquipmentId = 1, FirefighterId = 1},
                new HasEquipment { HasEquipmentId = 2, EquipmentId = 2, FirefighterId = 2},
                new HasEquipment { HasEquipmentId = 3, EquipmentId = 3, FirefighterId = 3},
                new HasEquipment { HasEquipmentId = 4, EquipmentId = 4, FirefighterId = 4},
                new HasEquipment { HasEquipmentId = 5, EquipmentId = 5, FirefighterId = 5},
                new HasEquipment { HasEquipmentId = 6, EquipmentId = 6, FirefighterId = 6},
                new HasEquipment { HasEquipmentId = 7, EquipmentId = 7, FirefighterId = 7},
                new HasEquipment { HasEquipmentId = 8, EquipmentId = 8, FirefighterId = 8},
                new HasEquipment { HasEquipmentId = 9, EquipmentId = 9, FirefighterId = 9},
                new HasEquipment { HasEquipmentId = 10, EquipmentId = 10, FirefighterId = 10},
                new HasEquipment { HasEquipmentId = 11, EquipmentId = 2, FirefighterId = 11},
                new HasEquipment { HasEquipmentId = 12, EquipmentId = 5, FirefighterId = 12},
                new HasEquipment { HasEquipmentId = 13, EquipmentId = 2, FirefighterId = 13},
                new HasEquipment { HasEquipmentId = 14, EquipmentId = 6, FirefighterId = 14},
                new HasEquipment { HasEquipmentId = 15, EquipmentId = 9, FirefighterId = 15},
                new HasEquipment { HasEquipmentId = 16, EquipmentId = 4, FirefighterId = 16},
                new HasEquipment { HasEquipmentId = 17, EquipmentId = 2, FirefighterId = 17},
                new HasEquipment { HasEquipmentId = 18, EquipmentId = 4, FirefighterId = 18},
                new HasEquipment { HasEquipmentId = 19, EquipmentId = 6, FirefighterId = 19},
                new HasEquipment { HasEquipmentId = 20, EquipmentId = 7, FirefighterId = 20},
                new HasEquipment { HasEquipmentId = 21, EquipmentId = 7, FirefighterId = 21},
                new HasEquipment { HasEquipmentId = 22, EquipmentId = 7, FirefighterId = 22},
                new HasEquipment { HasEquipmentId = 23, EquipmentId = 7, FirefighterId = 23},
                new HasEquipment { HasEquipmentId = 24, EquipmentId = 7, FirefighterId = 24},
                new HasEquipment { HasEquipmentId = 25, EquipmentId = 7, FirefighterId = 25},
                new HasEquipment { HasEquipmentId = 26, EquipmentId = 9, FirefighterId = 9},
                new HasEquipment { HasEquipmentId = 27, EquipmentId = 10, FirefighterId = 20},
                new HasEquipment { HasEquipmentId = 28, EquipmentId = 4, FirefighterId = 16},
                new HasEquipment { HasEquipmentId = 29, EquipmentId = 5, FirefighterId = 13},
                new HasEquipment { HasEquipmentId = 30, EquipmentId = 2, FirefighterId = 2},
                new HasEquipment { HasEquipmentId = 31, EquipmentId = 6, FirefighterId = 5},
                new HasEquipment { HasEquipmentId = 32, EquipmentId = 9, FirefighterId = 7},
                new HasEquipment { HasEquipmentId = 33, EquipmentId = 7, FirefighterId = 24},
                new HasEquipment { HasEquipmentId = 34, EquipmentId = 3, FirefighterId = 23},
                new HasEquipment { HasEquipmentId = 35, EquipmentId = 4, FirefighterId = 10},
            });



            modelBuilder.Entity<OnCall>().HasData(new OnCall[]
            {
                new OnCall { OnCallId = 1, EmergencyCallId = 1, FirefighterId = 1},
                new OnCall { OnCallId = 2, EmergencyCallId = 2, FirefighterId = 2},
                new OnCall { OnCallId = 3, EmergencyCallId = 3, FirefighterId = 3},
                new OnCall { OnCallId = 4, EmergencyCallId = 4, FirefighterId = 4},
                new OnCall { OnCallId = 5, EmergencyCallId = 5, FirefighterId = 5},
                new OnCall { OnCallId = 6, EmergencyCallId = 6, FirefighterId = 6},
                new OnCall { OnCallId = 7, EmergencyCallId = 7, FirefighterId = 7},
                new OnCall { OnCallId = 8, EmergencyCallId = 8, FirefighterId = 8},
                new OnCall { OnCallId = 9, EmergencyCallId = 9, FirefighterId = 9},
                new OnCall { OnCallId = 10, EmergencyCallId = 10, FirefighterId = 10},
                new OnCall { OnCallId = 11, EmergencyCallId = 2, FirefighterId = 11},
                new OnCall { OnCallId = 12, EmergencyCallId = 5, FirefighterId = 12},
                new OnCall { OnCallId = 13, EmergencyCallId = 2, FirefighterId = 13},
                new OnCall { OnCallId = 14, EmergencyCallId = 6, FirefighterId = 14},
                new OnCall { OnCallId = 15, EmergencyCallId = 9, FirefighterId = 15},
                new OnCall { OnCallId = 16, EmergencyCallId = 4, FirefighterId = 16},
                new OnCall { OnCallId = 17, EmergencyCallId = 2, FirefighterId = 17},
                new OnCall { OnCallId = 18, EmergencyCallId = 4, FirefighterId = 18},
                new OnCall { OnCallId = 19, EmergencyCallId = 6, FirefighterId = 19},
                new OnCall { OnCallId = 20, EmergencyCallId = 7, FirefighterId = 20},
                new OnCall { OnCallId = 21, EmergencyCallId = 7, FirefighterId = 21},
                new OnCall { OnCallId = 22, EmergencyCallId = 7, FirefighterId = 22},
                new OnCall { OnCallId = 23, EmergencyCallId = 7, FirefighterId = 23},
                new OnCall { OnCallId = 24, EmergencyCallId = 7, FirefighterId = 24},
                new OnCall { OnCallId = 25, EmergencyCallId = 7, FirefighterId = 25},
                new OnCall { OnCallId = 26, EmergencyCallId = 9, FirefighterId = 9},
                new OnCall { OnCallId = 27, EmergencyCallId = 10, FirefighterId = 20},
                new OnCall { OnCallId = 28, EmergencyCallId = 4, FirefighterId = 16},
                new OnCall { OnCallId = 29, EmergencyCallId = 5, FirefighterId = 13},
                new OnCall { OnCallId = 30, EmergencyCallId = 2, FirefighterId = 2},
                new OnCall { OnCallId = 31, EmergencyCallId = 6, FirefighterId = 5},
                new OnCall { OnCallId = 32, EmergencyCallId = 9, FirefighterId = 7},
                new OnCall { OnCallId = 33, EmergencyCallId = 7, FirefighterId = 24},
                new OnCall { OnCallId = 34, EmergencyCallId = 3, FirefighterId = 23},
                new OnCall { OnCallId = 35, EmergencyCallId = 4, FirefighterId = 10},
            });
        }
    }
}
