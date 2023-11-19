using CM79D3_HFT_2023241.Logic.Classes;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Test
{
    [TestFixture]
    public class CrudTests
    {
        FireStationLogic fsLogic;
        FirefighterLogic ffLogic;
        EmergencyCallLogic ecLogic;
        EquipmentLogic eqLogic;
        Mock<IRepository<FireStation>> mockFSRepository;
        Mock<IRepository<Firefighter>> mockFFRepository;
        Mock<IRepository<EmergencyCall>> mockECRepository;
        Mock<IRepository<Equipment>> mockEQRepository;

        [SetUp]
        public void Setup()
        {
            mockFSRepository = new Mock<IRepository<FireStation>>();
            mockFFRepository = new Mock<IRepository<Firefighter>>();
            mockECRepository = new Mock<IRepository<EmergencyCall>>();
            mockEQRepository = new Mock<IRepository<Equipment>>();
            fsLogic = new FireStationLogic(mockFSRepository.Object);
            ffLogic = new FirefighterLogic(mockFFRepository.Object);
            ecLogic = new EmergencyCallLogic(mockECRepository.Object);
            eqLogic = new EquipmentLogic(mockEQRepository.Object);
        }
        [TestCase(null,"TestLocation", "TestContact")]
        [TestCase("acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab",
            "TestLocation", "TestContact")]
        [TestCase("TestName", null, "TestContact")]
        [TestCase("TestName", "TestLocation", "acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab")]
        public void FireStationCreate(string Name, string Location, string ContactInfo)
        {
            Assert.Throws<ArgumentException>(() => { fsLogic.Create(new FireStation() { Name = Name,
                Location = Location, ContactInformation = ContactInfo}); });
        }
        [Test]
        public void FireStationRead()
        {
            Assert.Throws<ArgumentException>(() => { fsLogic.Read(0); });
        }
        [Test]
        public void FireStationDelete()
        {
            Assert.Throws<ArgumentException>(() => { fsLogic.Delete(0); });
        }
        [TestCase(null, "TestLastName", "TestRank","TestContact",1)]
        [TestCase("acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab", "TestLastName", "TestRank","TestContact",1)]
        [TestCase("TestFirstName", null, "TestRank", "TestContact", 1)]
        [TestCase("TestFirstName", "acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab", "TestRank", "TestContact", 1)]
        [TestCase("TestFirstName", "TestLastName", "acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab", "TestContact", 1)]
        [TestCase("TestFirstName", "TestLastName", "TestRank", null, 1)]
        [TestCase("TestFirstName", "TestLastName", "TestRank", "acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab", 1)]
        [TestCase("TestFirstName", "TestLastName", "TestRank", "TestContact", 0)]
        public void FirefighterCreate(string FirstName, string LastName, string Rank, string ContactInfo, int FS_ID)
        {
            Assert.Throws<ArgumentException>(() => {
                ffLogic.Create(
                    new Firefighter
                    {
                        FirstName = FirstName, LastName = LastName, Rank = Rank,
                        ContactInformation = ContactInfo, FireStation_ID = FS_ID
                    }
                    );
            });
        }
        [Test]
        public void FirefighterRead()
        {
            Assert.Throws<ArgumentException>(() => { ffLogic.Read(0); });
        }
        [Test]
        public void FirefighterDelete()
        {
            Assert.Throws<ArgumentException>(() => { ffLogic.Delete(0); });
        }
        [TestCase(null,EquipmentCondition.New,1)]
        [TestCase("acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab",EquipmentCondition.New, 1)]
        [TestCase("TestType",100,1)]
        [TestCase("TestType", EquipmentCondition.New, 0)]
        public void EquipmentCreate(string Type, EquipmentCondition eq, int firefighterID)
        {
            Assert.Throws<ArgumentException>(() => {
                eqLogic.Create(
                    new Equipment()
                    {
                        Type = Type, Condition = eq, Firefighter_ID = firefighterID
                    }
                    );
            });
        }
        [Test]
        public void EquipmentRead()
        {
            Assert.Throws<ArgumentException>(() => { eqLogic.Read(0); });
        }
        [Test]
        public void EquipmentDelete()
        {
            Assert.Throws<ArgumentException>(() => { eqLogic.Delete(0); });
        }


        [TestCase(null,"TestCallerPhone","TestLocation",IncidentType.MedicalEmergency, 1)]
        [TestCase("acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab", "TestCallerPhone","TestLocation",IncidentType.MedicalEmergency, 1)]
        [TestCase("TestCallerName", "acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab", "TestLocation",IncidentType.MedicalEmergency, 1)]
        [TestCase("TestCallerName", "TestCallerPhone", null, IncidentType.MedicalEmergency, 1)]
        [TestCase("TestCallerName", "TestCallerPhone", "acbabbaacbbaabacbccbaabbaaacbabbacbabbccbbaacbacacbacab", IncidentType.MedicalEmergency, 1)]
        [TestCase("TestCallerName", "TestCallerPhone", "TestLocation", 100, 1)]
        [TestCase("TestCallerName", "TestCallerPhone", "TestLocation", IncidentType.MedicalEmergency, 0)]
        public void EmCallCreate(string callerName, string callerPhone, string incidentLocation, IncidentType incident,int fsID)
        {
            Assert.Throws<ArgumentException>(() => {
                ecLogic.Create(
                    new EmergencyCall()
                    {
                        CallerName = callerName, CallerPhone = callerPhone, 
                        IncidentLocation = incidentLocation, IncidentType = incident, DateTime = DateTime.Now,
                        FireStation_ID = fsID
                    }
                    );
            });
        }
        [Test]
        public void EmCallCreateWithBadDateTime()
        {
            Assert.Throws<ArgumentException>(() => {
                ecLogic.Create(
                    new EmergencyCall()
                    {
                        CallerName = "TestCallerName",
                        CallerPhone = "TestCallerPhone",
                        IncidentLocation = "TestLocation",
                        IncidentType = IncidentType.Fire,
                        DateTime = DateTime.MinValue,
                        FireStation_ID = 1
                    }
                    );
            });
        }
        [Test]
        public void EmCallRead()
        {
            Assert.Throws<ArgumentException>(() => { ecLogic.Read(0); });
        }
        [Test]
        public void EmCallDelete()
        {
            Assert.Throws<ArgumentException>(() => { ecLogic.Delete(0); });
        }
    }
}
