using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IHasEquipmentLogic
    {
        IQueryable<HasEquipment> ReadAll();
        HasEquipment Read(int id);
        void Create(HasEquipment item);
        void Update(HasEquipment item);
        void Delete(int id);
    }
}
