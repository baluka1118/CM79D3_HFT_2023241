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
        public void Create(Firefighter item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Firefighter Read(int id)
        {
            var ff = repo.Read(id);
            if (ff == null)
            {
                throw new ArgumentException($"Firefighter doesn't exists. ({id})");
            }
            return ff;
        }

        public IQueryable<Firefighter> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Firefighter item)
        {
            this.repo.Update(item);
        }
    }
}
