using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IOnCallLogic
    {
        IQueryable<OnCall> ReadAll();
        OnCall Read(int id);
        void Create(OnCall item);
        void Update(OnCall item);
        void Delete(int id);
    }
}
