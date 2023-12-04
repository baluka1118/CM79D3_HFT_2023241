using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository;
using CM79D3_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CM79D3_HFT_2023241.Models.ClassesForQueries;

namespace CM79D3_HFT_2023241.Logic.Classes
{
    public class FireStationLogic : IFireStationLogic
    {
        IRepository<FireStation> repo;

        public FireStationLogic(IRepository<FireStation> repo)
        {
            this.repo = repo;
        }

        public void Create(FireStation item)
        {
            if (item.Name == null || item.Name.Length > 50 || item.Location == null || 
                item?.ContactInformation?.Length > 50)
            {
                throw new ArgumentException("The FireStation isn't defined correctly.");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            this.Read(id); //throws argumentexception if station doesnt exist
            repo.Delete(id); 
        }
        public FireStation Read(int id)
        {
            var station = repo.Read(id);
            if (station == null)
            {
                throw new ArgumentException("The FireStation doesn't exist.");
            }
            return station;
        }

        public IEnumerable<FireStation> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(FireStation item)
        {
            repo.Update(item);
        }
        /// <summary>
        /// Query for getting data on the firefighters by Station.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>KeyValuePair where the key is the name of the firestation, and the value is the count of firefighters in that station.</returns>
        public IEnumerable<FireStationWithFirefighterCount> HowManyFirefightersByStation()
        {
            var result = repo.ReadAll()
                .Select(fireStation => new FireStationWithFirefighterCount
                {
                    Name = fireStation.Name,
                    FirefighterCount = fireStation.Firefighters.Count
                });

            return result;
        }
        /// <summary>
        /// Query for getting data on how many calls a station receive by type.
        /// </summary>
        /// <returns>KeyValuePair where the key is the name of the FireStation and the value is a Dictionary consisting of IncidentTypes and the count of EmergencyCalls with that type.</returns>
        public IEnumerable<FireStationWithEmergencyCallCountByType> EmergencyCallsCountByStationAndType()
        {
            var result = repo.ReadAll()
                .Select(fireStation => new FireStationWithEmergencyCallCountByType
                {
                    Name = fireStation.Name,
                    EmergencyCallCounts = fireStation.EmergencyCalls
                        .GroupBy(ec => ec.IncidentType)
                        .Select(group => new EmergencyCallCount
                        {
                            IncidentType = group.Key,
                            Count = group.Count()
                        })
                });
            return result;
        }
        /// <summary>
        /// Query for getting data on the distribution of ranks in the station.
        /// </summary>
        /// <returns>KeyValuePairs where the key is the firestation name and the value is a dictionary with keys being the ranks and values being the count of firefighters with that rank.</returns>
        public IEnumerable<FireStationWithRankDistribution> RankDistribution()
        {
            var result = repo.ReadAll()
                .Select(fireStation => new FireStationWithRankDistribution
                {
                    Name = fireStation.Name,
                    RankDistribution = fireStation.Firefighters
                        .GroupBy(ff => ff.Rank)
                        .Select(group => new FirefighterRankCount
                        {
                            Rank = group.Key,
                            Count = group.Count()
                        })
                });

            return result;
        }
        /// <summary>
        /// Query for getting data on the EC's by season.
        /// </summary>
        /// <returns>
        /// Emergency Calls grouped and ordered by season (winter, spring...) and FireStation (name).</returns>
        public IEnumerable<EmergencyCallsBySeasonResult> EmergencyCallsBySeason()
        {
            var emergencyCalls = repo.ReadAll()
                .SelectMany(fireStation => fireStation.EmergencyCalls);
            /*since we can be sure that all the emergency calls will be in the result of the query (since every emergency call has a firestation and season)
             we can use AsEnumerable() for the emergencycalls*/
            var result = from emergencyCall in emergencyCalls.AsEnumerable() 
                let season = GetSeason(emergencyCall.DateTime.Month)
                group emergencyCall by new { Season = season, FireStation = emergencyCall.FireStation.Name } into groupedCalls
                orderby groupedCalls.Key.Season, groupedCalls.Key.FireStation
                select new EmergencyCallsBySeasonResult
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
