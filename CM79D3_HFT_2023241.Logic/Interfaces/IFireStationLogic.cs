using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IFireStationLogic
    {
        IQueryable<FireStation> ReadAll();
        FireStation Read(int id);
        void Create(FireStation item);
        void Update(FireStation item);
        void Delete(int id);
    }
}
