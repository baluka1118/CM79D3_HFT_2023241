using CM79D3_HFT_2023241.Logic.Classes;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Test
{
    [TestFixture]
    public class NonCrudTests
    {
        FireStationLogic fsLogic;
        FirefighterLogic ffLogic;
        EmergencyCallLogic ecLogic;

        Mock<IRepository<FireStation>> mockFSRepository;
        Mock<IRepository<Firefighter>> mockFFRepository;
        Mock<IRepository<EmergencyCall>> mockECRepository;

        IQueryable<FireStation> mockFirestations;
        IQueryable<Firefighter> mockFirefighters;
        IQueryable<EmergencyCall> mockEmergencyCalls;

        [SetUp]
        public void Setup()
        {
            mockFirestations = new List<FireStation>
            {
                new FireStation
                {
                    Id = 1,
                    Name = "Station A",
                    Location = "Location A",
                    ContactInformation = "Contact A",
                    EmergencyCalls = new List<EmergencyCall>
                    {
                        new EmergencyCall { Id = 1, CallerName = "Caller A1", CallerPhone = "123-456-7890", IncidentLocation = "Location A1", IncidentType = IncidentType.Fire, DateTime = DateTime.Now },
                        new EmergencyCall { Id = 2, CallerName = "Caller A2", CallerPhone = "987-654-3210", IncidentLocation = "Location A2", IncidentType = IncidentType.MedicalEmergency, DateTime = DateTime.Now },
                    },
                    Firefighters = new List<Firefighter>
                    {
                        new Firefighter { Id = 1, FirstName = "John A", LastName = "Doe A", Rank = "Captain", ContactInformation = "John.DoeA@example.com" },
                        new Firefighter { Id = 2, FirstName = "Jane A", LastName = "Smith A", Rank = "Lieutenant", ContactInformation = "Jane.SmithA@example.com" },
                    }
                },
                new FireStation
                {
                    Id = 2,
                    Name = "Station B",
                    Location = "Location B",
                    ContactInformation = "Contact B",
                    EmergencyCalls = new List<EmergencyCall>
                    {
                        new EmergencyCall { Id = 3, CallerName = "Caller B1", CallerPhone = "123-456-7890", IncidentLocation = "Location B1", IncidentType = IncidentType.Fire, DateTime = DateTime.Now },
                        new EmergencyCall { Id = 4, CallerName = "Caller B2", CallerPhone = "987-654-3210", IncidentLocation = "Location B2", IncidentType = IncidentType.MedicalEmergency, DateTime = DateTime.Now },
                    },
                    Firefighters = new List<Firefighter>
                    {
                        new Firefighter { Id = 3, FirstName = "John B", LastName = "Doe B", Rank = "Captain", ContactInformation = "John.DoeB@example.com" },
                        new Firefighter { Id = 4, FirstName = "Jane B", LastName = "Smith B", Rank = "Lieutenant", ContactInformation = "Jane.SmithB@example.com" },
                    }
                },
            }.AsQueryable();

            mockFirefighters = new List<Firefighter>
            {
                new Firefighter
                {
                    Id = 1,
                    FirstName = "John A",
                    LastName = "Doe A",
                    Rank = "Captain",
                    ContactInformation = "John.DoeA@example.com",
                    Equipment = new List<Equipment>
                    {
                        new Equipment { Id = 1, Type = "Fire Extinguisher A", Condition = EquipmentCondition.Good },
                        new Equipment { Id = 2, Type = "Medical Kit A", Condition = EquipmentCondition.New },
                    }
                },
                new Firefighter
                {
                    Id = 2,
                    FirstName = "Jane A",
                    LastName = "Smith A",
                    Rank = "Lieutenant",
                    ContactInformation = "Jane.SmithA@example.com",
                    Equipment = new List<Equipment>
                    {
                        new Equipment { Id = 3, Type = "Fire Extinguisher B", Condition = EquipmentCondition.Good },
                        new Equipment { Id = 4, Type = "Medical Kit B", Condition = EquipmentCondition.New },
                    }
                },
            }.AsQueryable();

            mockEmergencyCalls = new List<EmergencyCall> //kell e firestation
                    {
                        new EmergencyCall { Id = 1, CallerName = "Caller A1", CallerPhone = "123-456-7890", IncidentLocation = "Location A1", IncidentType = IncidentType.Fire, DateTime = DateTime.Now, FireStation_ID = 1 },
                        new EmergencyCall { Id = 2, CallerName = "Caller A2", CallerPhone = "987-654-3210", IncidentLocation = "Location A2", IncidentType = IncidentType.MedicalEmergency, DateTime = DateTime.Now, FireStation_ID = 2},
                    }.AsQueryable();


            mockFSRepository = new Mock<IRepository<FireStation>>();
            mockFSRepository.Setup(fs => fs.ReadAll()).Returns(mockFirestations);
            fsLogic = new FireStationLogic(mockFSRepository.Object);

            mockFFRepository = new Mock<IRepository<Firefighter>>();
            mockFFRepository.Setup(ff => ff.ReadAll()).Returns(mockFirefighters);
            ffLogic = new FirefighterLogic(mockFFRepository.Object);

            mockECRepository = new Mock<IRepository<EmergencyCall>>();
            mockECRepository.Setup(ec => ec.ReadAll()).Returns(mockEmergencyCalls);
            ecLogic = new EmergencyCallLogic(mockECRepository.Object);
        }
    }
}
