using CM79D3_HFT_2023241.Logic.ClassesForQueries;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Classes
{
    public class EmergencyCallLogic : IEmergencyCallLogic
    {
        IRepository<EmergencyCall> repo;
        public EmergencyCallLogic(IRepository<EmergencyCall> repo)
        {
            this.repo = repo;
        }
        public void Create(EmergencyCall item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public EmergencyCall Read(int id)
        {
            var ec = repo.Read(id);
            if (ec == null)
            {
                throw new ArgumentException($"Emergency Call doesn't exist. ({id})");
            }
            return ec;
        }

        public IEnumerable<EmergencyCall> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(EmergencyCall item)
        {
            this.repo.Update(item);
        }
        /// <summary>
        /// Query for getting data on the EC's by season.
        /// </summary>
        /// <returns>
        ///Emergency Calls grouped and ordered by season (winter, spring...) and FireStation (name).</returns>
        public IEnumerable<EmergencyCallsBySeasonAndFireStationResult> EmergencyCallsBySeason()
        {
            var result = from emergencyCall in repo.ReadAll()
                         let season = GetSeason(emergencyCall.DateTime.Month)
                         orderby emergencyCall.FireStation.Name, season
                         group emergencyCall by new { Season = season, FireStation = emergencyCall.FireStation.Name } into groupedCalls
                         select new EmergencyCallsBySeasonAndFireStationResult
                         {
                             Season = groupedCalls.Key.Season,
                             FireStation = groupedCalls.Key.FireStation,
                             EmergencyCalls = groupedCalls
                         };

            return result;
        }
        private static string GetSeason(int month)
        {
            switch (month)
            {
                case 12:
                case 1:
                case 2:
                    return "Winter";
                case 3:
                case 4:
                case 5:
                    return "Spring";
                case 6:
                case 7:
                case 8:
                    return "Summer";
                case 9:
                case 10:
                case 11:
                    return "Autumn";
                default:
                    return "Unknown";
            }
        }
    }
}
