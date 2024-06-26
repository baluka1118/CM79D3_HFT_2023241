﻿using CM79D3_HFT_2023241.Logic;
using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Models.ClassesForQueries;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IFireStationLogic
    {
        IEnumerable<FireStation> ReadAll();
        FireStation Read(int id);
        void Create(FireStation item);
        void Update(FireStation item);
        void Delete(int id);
        public IEnumerable<FireStationWithFirefighterCount> HowManyFirefightersByStation();
        public IEnumerable<FireStationWithRankDistribution> RankDistribution();
        public IEnumerable<FireStationWithEmergencyCallCountByType> EmergencyCallsCountByStationAndType();
        public IEnumerable<EmergencyCallsBySeasonResult> EmergencyCallsBySeason();

    }
}
