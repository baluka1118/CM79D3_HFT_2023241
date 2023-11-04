using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Classes
{
    public class HasEquipmentLogic : IHasEquipmentLogic
    {
        IRepository<HasEquipment> repo;
        public void Create(HasEquipment item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public HasEquipment Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<HasEquipment> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(HasEquipment item)
        {
            this.repo.Update(item);
        }
    }
}
