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
    public class FirefighterLogic : IFirefighterLogic
    {
        IRepository<Firefighter> repo;
        public FirefighterLogic(IRepository<Firefighter> repo)
        {
            this.repo = repo;
        }
        public void Create(Firefighter item)
        {
            if (item.FirstName == null || item.FirstName.Length > 50 || item.LastName == null || item.LastName.Length > 50 || item?.Rank?.Length > 30 || item.ContactInformation == null || item.ContactInformation.Length > 50 || item.FireStation_ID == 0)
            {
                throw new ArgumentException("The Firefighter isn't defined correctly.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.Read(id);
            this.repo.Delete(id);
        }

        public Firefighter Read(int id)
        {
            var ff = repo.Read(id);
            return ff;
        }

        public IEnumerable<Firefighter> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Firefighter item)
        {
            this.repo.Update(item);
        }
        /// <summary>
        /// Query for getting data on which firefighters have no (and therefore need to get) equipment.
        /// </summary>
        /// <returns>Collection of firefighters with no equipment.</returns>
        public IEnumerable<Firefighter> FireFightersWithoutEquipment()
        {
            return repo.ReadAll().Where(x => x.Equipment.Count == 0).ToList();
        }

    }
}
