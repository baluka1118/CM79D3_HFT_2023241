using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IFirefighterLogic
    {
        IEnumerable<Firefighter> ReadAll();
        Firefighter Read(int id);
        void Create(Firefighter item);
        void Update(Firefighter item);
        void Delete(int id);
        public IEnumerable<Firefighter> FireFightersWithoutEquipment();
    }
}
