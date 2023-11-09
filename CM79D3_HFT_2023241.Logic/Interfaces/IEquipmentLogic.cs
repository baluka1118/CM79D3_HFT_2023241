using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IEquipmentLogic
    {
        IEnumerable<Equipment> ReadAll();
        Equipment Read(int id);
        void Create(Equipment item);
        void Update(Equipment item);
        void Delete(int id);
    }
}
