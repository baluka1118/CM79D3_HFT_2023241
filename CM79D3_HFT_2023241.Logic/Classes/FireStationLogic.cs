using CM79D3_HFT_2023241.Logic.ClassesForQueries;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository;
using CM79D3_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                throw new ArgumentException($"Fire Station doesn't exist. ({id})");
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
        /// <returns>How many firefighters there are in each fire station.</returns>
        public IEnumerable<KeyValuePair<string,int>> HowManyFirefightersByStation() 
        {
            var q1 = from x in repo.ReadAll()
                     select new KeyValuePair<string, int>(x.Name, x.Firefighters.Count);
            return q1;
        }
        /// <summary>
        /// Query for getting data on how many calls a station receive by type.
        /// </summary>
        /// <returns>KeyValuePair where the key is the name of the FireStation and the value is a Dictionary consisting of IncidentTypes and the count of EmergencyCalls with that type.</returns>
        public IEnumerable<KeyValuePair<string, Dictionary<IncidentType, int>>> EmergencyCallsCountByStationAndType()
        {
            var result = repo.ReadAll()
                .Select(fireStation => new KeyValuePair<string, Dictionary<IncidentType, int>>(
                    fireStation.Name,
                    fireStation.EmergencyCalls
                        .GroupBy(ec => ec.IncidentType)
                        .ToDictionary(
                            group => group.Key,
                            group => group.Count()
                        )
                ));
            return result;
        }
        /// <summary>
        /// Query for getting data on the distribution of ranks in the station.
        /// </summary>
        /// <returns>KeyValuePairs where the key is the rank and the value is the count of firefighters with that rank.</returns>
        public IEnumerable<KeyValuePair<string, int>> RankDistribution()
        {
            var result = from x in repo.ReadAll().SelectMany(t => t.Firefighters)
                         group x by x.Rank into grp
                         select new KeyValuePair<string, int>
                         (
                             grp.Key, grp.Count()
                         );
            return result;
        }
        
    }
}
