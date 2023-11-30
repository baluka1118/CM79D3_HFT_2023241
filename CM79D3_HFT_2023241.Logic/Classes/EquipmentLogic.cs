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
    public class EquipmentLogic : IEquipmentLogic 
    {
        IRepository<Equipment> repo;
        public EquipmentLogic(IRepository<Equipment> repo)
        {
            this.repo = repo;
        }
        public void Create(Equipment item)
        {
            if (item.Type == null || item.Type.Length > 50 || 
                !Enum.IsDefined(typeof(EquipmentCondition),item.Condition) || item.Firefighter_ID == 0)
            {
                throw new ArgumentException("The Equipment isn't defined correctly.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Equipment Read(int id)
        {
            var eq = repo.Read(id);
            if (eq == null)
            {
                throw new ArgumentException("The Equipment doesn't exist.");
            }
            return eq;
        }

        public IEnumerable<Equipment> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Equipment item)
        {
            this.repo.Update(item);
        }
    }
}
