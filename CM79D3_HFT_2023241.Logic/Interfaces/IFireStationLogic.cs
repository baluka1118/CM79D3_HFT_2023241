using CM79D3_HFT_2023241.Logic.ClassesForQueries;
using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IFireStationLogic
    {
        IEnumerable<FireStation> ReadAll();
        FireStation Read(int id);
        void Create(FireStation item);
        void Update(FireStation item);
        void Delete(int id);
        public IEnumerable<KeyValuePair<string, int>> HowManyFirefightersByStation();
        public IEnumerable<KeyValuePair<string, Dictionary<string, int>>> RankDistribution();
        public IEnumerable<KeyValuePair<string, Dictionary<IncidentType, int>>> EmergencyCallsCountByStationAndType();
        public IEnumerable<EmergencyCallsBySeasonResult> EmergencyCallsBySeason();

    }
}
