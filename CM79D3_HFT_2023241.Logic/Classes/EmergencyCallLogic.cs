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
                throw new ArgumentException($"Emergency Call doesn't exists. ({id})");
            }
            return ec;
        }

        public IQueryable<EmergencyCall> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(EmergencyCall item)
        {
            this.repo.Update(item);
        }
    }
}
