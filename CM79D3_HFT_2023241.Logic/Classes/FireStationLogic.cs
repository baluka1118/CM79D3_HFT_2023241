using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository;
using CM79D3_HFT_2023241.Repository.Interfaces;
using System;
using System.Linq;

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
            repo.Create(item);
        }

        public void Delete(int id)
        {
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

        public IQueryable<FireStation> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(FireStation item)
        {
            repo.Update(item);
        }
        /// <summary>
        /// Returns how many firefighters there are in the fire station with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int HowManyFirefighters(int id)
        {
            return this.repo.Read(id).Firefighters.Count;
        }
    }
}
