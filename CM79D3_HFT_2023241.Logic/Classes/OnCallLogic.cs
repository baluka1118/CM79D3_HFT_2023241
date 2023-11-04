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
    public class OnCallLogic : IOnCallLogic
    {
        IRepository<OnCall> repo;
        public void Create(OnCall item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public OnCall Read(int id)
        {
            var oc = repo.Read(id);
            if (oc == null)
            {
                throw new ArgumentException($"OnCall doesn't exists. ({id})");
            }
            return oc;
        }

        public IQueryable<OnCall> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(OnCall item)
        {
            this.repo.Update(item);
        }
    }
}
