using CM79D3_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Repository.Database
{
    public class FireFightingDbContext : DbContext
    {
        public virtual DbSet<FireStation> FireStations { get; set; }
        public virtual DbSet<Firefighter> Firefighters { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EmergencyCall> EmergencyCalls { get; set; }
        public FireFightingDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase("firefighting");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firefighter>(fighter =>
                fighter.HasOne(fighter => fighter.FireStation)
                       .WithMany(station => station.Firefighters)
                       .HasForeignKey(fighter => fighter.FireStation_ID)
                       .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Equipment>(equipment =>
                equipment.HasOne(equipment => equipment.Firefighter)
                       .WithMany(firefighter => firefighter.Equipment)
                       .HasForeignKey(equipment => equipment.Firefighter_ID)
                       .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<EmergencyCall>(emCall =>
                emCall.HasOne(emCall => emCall.FireStation)
                       .WithMany(station => station.EmergencyCalls)
                       .HasForeignKey(emCall => emCall.FireStation_ID)
                       .OnDelete(DeleteBehavior.Cascade));


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
                new Equipment { Id = 1, Type = "Fire Hose", Condition = EquipmentCondition.New, Firefighter_ID = 1},
                new Equipment { Id = 2, Type = "AED", Condition = EquipmentCondition.New, Firefighter_ID = 2},
                new Equipment { Id = 3, Type = "Ladder", Condition = EquipmentCondition.Good, Firefighter_ID = 3},
                new Equipment { Id = 4, Type = "Fire Extinguisher", Condition = EquipmentCondition.Fair, Firefighter_ID = 4},
                new Equipment { Id = 5, Type = "Bunker Gear", Condition = EquipmentCondition.Good , Firefighter_ID = 5},
                new Equipment { Id = 6, Type = "Thermal Imaging Camera", Condition = EquipmentCondition.New , Firefighter_ID = 6},
                new Equipment { Id = 7, Type = "Jaws of Life", Condition = EquipmentCondition.Poor, Firefighter_ID = 7},
                new Equipment { Id = 8, Type = "Oxygen Tank", Condition = EquipmentCondition.Good , Firefighter_ID = 8},
                new Equipment { Id = 9, Type = "Fire Hose", Condition = EquipmentCondition.Good , Firefighter_ID = 9},
                new Equipment { Id = 10, Type = "First Aid Kit", Condition = EquipmentCondition.Fair, Firefighter_ID = 10},
                new Equipment { Id = 11, Type = "First Aid Kit", Condition = EquipmentCondition.Good, Firefighter_ID = 3},
            });
            modelBuilder.Entity<EmergencyCall>().HasData(new EmergencyCall[]
            {
                new EmergencyCall { Id = 1, CallerName = "911 Operator", CallerPhone = "123-477-7891", IncidentLocation = "123 Elm St, Cityville", IncidentType = IncidentType.Fire, DateTime = new DateTime(2023,6,12), FireStation_ID = 1},
                new EmergencyCall { Id = 2, CallerName = "John Doe", IncidentLocation = "456 Oak St, Townsville", IncidentType = IncidentType.MedicalEmergency, DateTime = new DateTime(2023,7,2), FireStation_ID = 2 },
                new EmergencyCall { Id = 3, CallerName = "Jane Smith", IncidentLocation = "789 Pine St, Villageburg", IncidentType = IncidentType.Rescue, DateTime = new DateTime(2023,5,13), FireStation_ID = 3 },
                new EmergencyCall { Id = 4, CallerName = "Robert Johnson",CallerPhone = "623-673-8211", IncidentLocation = "234 Cedar St, Metroville", IncidentType = IncidentType.HazardousMaterials, DateTime = new DateTime(2023,6,14), FireStation_ID = 4 },
                new EmergencyCall { Id = 5, CallerName = "Linda Williams", IncidentLocation = "555 Willow St, Suburbia", IncidentType = IncidentType.NaturalDisaster, DateTime = new DateTime(2023,6,12), FireStation_ID = 5 },
                new EmergencyCall { Id = 6, CallerName = "Michael Brown", CallerPhone = "523-173-8811", IncidentLocation = "789 Fir St, Ruralville", IncidentType = IncidentType.FalseAlarm, DateTime = new DateTime(2023,5,22), FireStation_ID = 1 },
                new EmergencyCall { Id = 7, CallerName = "Sarah Davis", IncidentLocation = "987 Birch St, Mountainside", IncidentType = IncidentType.Other, DateTime = new DateTime(2023,6,11), FireStation_ID = 2 },
                new EmergencyCall { Id = 8, CallerName = "William Garcia", IncidentLocation = "345 Maple St, Beachtown", IncidentType = IncidentType.MedicalEmergency, DateTime = new DateTime(2023,8,2), FireStation_ID = 2 },
                new EmergencyCall { Id = 9, CallerName = "Karen Hall", IncidentLocation = "321 Cedar St, Towncenter", IncidentType = IncidentType.HazardousMaterials, DateTime = new DateTime(2023,7,30), FireStation_ID = 4 },
                new EmergencyCall { Id = 10, CallerName = "David Martinez", IncidentLocation = "666 Oak St, Riverside", IncidentType = IncidentType.Fire, DateTime = new DateTime(2023,8,1), FireStation_ID = 5},
            });
        }
    }
}
