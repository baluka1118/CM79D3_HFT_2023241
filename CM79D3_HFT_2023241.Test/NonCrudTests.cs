using CM79D3_HFT_2023241.Logic.Classes;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Models.ClassesForQueries;

namespace CM79D3_HFT_2023241.Test
{
    [TestFixture]
    public class NonCrudTests
    {
        FireStationLogic fsLogic;
        FirefighterLogic ffLogic;
        Mock<IRepository<FireStation>> mockFSRepository;
        Mock<IRepository<Firefighter>> mockFFRepository;

        IQueryable<FireStation> mockFirestations;
        IQueryable<Firefighter> mockFirefighters;

        [SetUp]
        public void Setup()
        {
            FireStation f1 = new FireStation()
            {
                Id = 1,
                Name = "Station A",
                Location = "Location A",
                ContactInformation = "Contact A",
                Firefighters = new List<Firefighter>
                {
                    new Firefighter
                    {
                        Id = 1, FirstName = "John A", LastName = "Doe A", Rank = "Captain",
                        ContactInformation = "John.DoeA@example.com"
                    },
                    new Firefighter
                    {
                        Id = 2, FirstName = "Jane A", LastName = "Smith A", Rank = "Lieutenant",
                        ContactInformation = "Jane.SmithA@example.com"
                    },
                }
            };

            FireStation f2 = new FireStation()
            {
                Id = 2,
                Name = "Station B",
                Location = "Location B",
                ContactInformation = "Contact B",
                Firefighters = new List<Firefighter>
                {
                    new Firefighter
                    {
                        Id = 3, FirstName = "John B", LastName = "Doe B", Rank = "Captain",
                        ContactInformation = "John.DoeB@example.com"
                    },
                    new Firefighter
                    {
                        Id = 4, FirstName = "Jane B", LastName = "Smith B", Rank = "Lieutenant",
                        ContactInformation = "Jane.SmithB@example.com"
                    },
                    new Firefighter
                    {
                        Id = 5, FirstName = "Joe A", LastName = "Wayne A", Rank = "Captain",
                        ContactInformation = "Joe.WayneA@example.com"
                    },
                }
            };
            EmergencyCall ec1 = new EmergencyCall()
            {
                Id = 1,
                CallerName = "Caller A1",
                CallerPhone = "123-456-7890",
                IncidentLocation = "Location A1",
                IncidentType = IncidentType.Fire,
                DateTime = new DateTime(2023, 1, 12),
                FireStation_ID = 1,
                FireStation = f1
            };
            EmergencyCall ec2 = new EmergencyCall()
            {
                Id = 2,
                CallerName = "Caller A2",
                CallerPhone = "987-654-3210",
                IncidentLocation = "Location A2",
                IncidentType = IncidentType.MedicalEmergency,
                DateTime = new DateTime(2023, 6, 12),
                FireStation_ID = 1,
                FireStation = f1
            };
            EmergencyCall ec3 = new EmergencyCall()
            {
                Id = 3,
                CallerName = "Caller A3",
                CallerPhone = "987-654-3210",
                IncidentLocation = "Location A2",
                IncidentType = IncidentType.MedicalEmergency,
                DateTime = new DateTime(2023, 4, 12),
                FireStation_ID = 1,
                FireStation = f1
            };
            EmergencyCall ec4 = new EmergencyCall()
            {
                Id = 4,
                CallerName = "Caller B1",
                CallerPhone = "123-456-7890",
                IncidentLocation = "Location B1",
                IncidentType = IncidentType.Fire,
                DateTime = new DateTime(2023, 7, 12),
                FireStation_ID = 2,
                FireStation = f2
            };
            EmergencyCall ec5 = new EmergencyCall()
            {
                Id = 5,
                CallerName = "Caller B2",
                CallerPhone = "987-654-3210",
                IncidentLocation = "Location B2",
                IncidentType = IncidentType.MedicalEmergency,
                DateTime = new DateTime(2023, 10, 12),
                FireStation_ID = 2,
                FireStation = f2
            };
            f1.EmergencyCalls = new List<EmergencyCall> { ec1, ec2, ec3 };
            f2.EmergencyCalls = new List<EmergencyCall> { ec4, ec5 };
            mockFirestations = new List<FireStation>
            {
                f1,f2
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
                new Firefighter
                {
                    Id = 3,
                    FirstName = "Jane B",
                    LastName = "Smith B",
                    Rank = "Lieutenant",
                    ContactInformation = "Jane.SmithA@example.com",
                },
            }.AsQueryable();

            mockFSRepository = new Mock<IRepository<FireStation>>();
            mockFSRepository.Setup(fs => fs.ReadAll()).Returns(mockFirestations);
            fsLogic = new FireStationLogic(mockFSRepository.Object);

            mockFFRepository = new Mock<IRepository<Firefighter>>();
            mockFFRepository.Setup(ff => ff.ReadAll()).Returns(mockFirefighters);
            ffLogic = new FirefighterLogic(mockFFRepository.Object);
        }
        [Test]
        public void HowManyFirefightersByStationTest()
        {
            var result = fsLogic.HowManyFirefightersByStation();

            Assert.IsNotNull(result);

            IEnumerable<FireStationWithFirefighterCount> expected = new List<FireStationWithFirefighterCount>
            {
                new FireStationWithFirefighterCount { Name = "Station A", FirefighterCount = 2 },
                new FireStationWithFirefighterCount { Name = "Station B", FirefighterCount = 3 },
            };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EmergencyCallsCountByStationAndTypeTest()
        {
            var result = fsLogic.EmergencyCallsCountByStationAndType();
            ;
            Assert.IsNotNull(result);

            IEnumerable<FireStationWithEmergencyCallCountByType> expected = new List<FireStationWithEmergencyCallCountByType>
            {
                new FireStationWithEmergencyCallCountByType
                {
                    Name = "Station A",
                    EmergencyCallCounts = new List<EmergencyCallCount>
                    {
                        new EmergencyCallCount { IncidentType = IncidentType.Fire, Count = 1 },
                        new EmergencyCallCount { IncidentType = IncidentType.MedicalEmergency, Count = 2 },
                    }
                },
                new FireStationWithEmergencyCallCountByType
                {
                    Name = "Station B",
                    EmergencyCallCounts = new List<EmergencyCallCount>
                    {
                        new EmergencyCallCount { IncidentType = IncidentType.Fire, Count = 1 },
                        new EmergencyCallCount { IncidentType = IncidentType.MedicalEmergency, Count = 1 },
                    }
                },
            };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void RankDistributionTest()
        {
            var result = fsLogic.RankDistribution();

            Assert.IsNotNull(result);

            IEnumerable<FireStationWithRankDistribution> expected = new List<FireStationWithRankDistribution>
            {
                new FireStationWithRankDistribution
                {
                    Name = "Station A",
                    RankDistribution = new List<FirefighterRankCount>
                    {
                        new FirefighterRankCount { Rank = "Captain", Count = 1 },
                        new FirefighterRankCount { Rank = "Lieutenant", Count = 1 },
                    }
                },
                new FireStationWithRankDistribution
                {
                    Name = "Station B",
                    RankDistribution = new List<FirefighterRankCount>
                    {
                        new FirefighterRankCount { Rank = "Captain", Count = 2 },
                        new FirefighterRankCount { Rank = "Lieutenant", Count = 1 },
                    }
                },
            };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void EmergencyCallsBySeasonTest()
        {
            var result = fsLogic.EmergencyCallsBySeason();

            Assert.IsNotNull(result);

            IEnumerable<EmergencyCallsBySeasonResult> expected = new List<EmergencyCallsBySeasonResult>
            {
                new EmergencyCallsBySeasonResult
                {
                    FireStation = "Station B",
                    Season = "Autumn",
                    EmergencyCalls = new List<EmergencyCall>
                    {
                        new EmergencyCall
                        {
                            Id = 5, CallerName = "Caller B2", CallerPhone = "987-654-3210",
                            IncidentLocation = "Location B2", IncidentType = IncidentType.MedicalEmergency,
                            DateTime = new DateTime(2023, 10, 12)
                        }
                    }
                },
                new EmergencyCallsBySeasonResult
                {
                    FireStation = "Station A",
                    Season = "Spring",
                    EmergencyCalls = new List<EmergencyCall>
                    {
                        new EmergencyCall
                        {
                            Id = 3, CallerName = "Caller A3", CallerPhone = "987-654-3210",
                            IncidentLocation = "Location A2", IncidentType = IncidentType.MedicalEmergency,
                            DateTime = new DateTime(2023, 4, 12)
                        }
                    }
                },
                // Add other expected EmergencyCallsBySeasonResult items here...
                new EmergencyCallsBySeasonResult
                {
                    FireStation = "Station A",
                    Season = "Summer",
                    EmergencyCalls = new List<EmergencyCall>
                    {
                        new EmergencyCall
                        {
                            Id = 2, CallerName = "Caller A2", CallerPhone = "987-654-3210",
                            IncidentLocation = "Location A2", IncidentType = IncidentType.MedicalEmergency,
                            DateTime = new DateTime(2023, 6, 12)
                        }
                    }
                },
                new EmergencyCallsBySeasonResult
                {
                    FireStation = "Station B",
                    Season = "Summer",
                    EmergencyCalls = new List<EmergencyCall>
                    {
                        new EmergencyCall
                        {
                            Id = 4, CallerName = "Caller B1", CallerPhone = "123-456-7890",
                            IncidentLocation = "Location B1", IncidentType = IncidentType.Fire,
                            DateTime = new DateTime(2023, 7, 12)
                        }
                    }
                },
                new EmergencyCallsBySeasonResult
                {
                    FireStation = "Station A",
                    Season = "Winter",
                    EmergencyCalls = new List<EmergencyCall>
                    {
                        new EmergencyCall
                        {
                            Id = 1, CallerName = "Caller A1", CallerPhone = "123-456-7890",
                            IncidentLocation = "Location A1", IncidentType = IncidentType.Fire,
                            DateTime = new DateTime(2023, 1, 12)
                        }
                    }
                }
            };

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void FireFightersWithoutEquipmentTest()
        {
            var expected = ffLogic.FireFightersWithoutEquipment().ToList();
            var result = new List<Firefighter>
            {
                new Firefighter
                {
                    Id = 3,
                    FirstName = "Jane B",
                    LastName = "Smith B",
                    Rank = "Lieutenant",
                    ContactInformation = "Jane.SmithA@example.com",
                },
            };
            Assert.AreEqual(expected,result);
        }
    }
}
