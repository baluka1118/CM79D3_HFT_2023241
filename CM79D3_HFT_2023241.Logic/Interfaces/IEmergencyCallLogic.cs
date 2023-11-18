using CM79D3_HFT_2023241.Logic.ClassesForQueries;
using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Interfaces
{
    public interface IEmergencyCallLogic
    {
        IEnumerable<EmergencyCall> ReadAll();
        EmergencyCall Read(int id);
        void Create(EmergencyCall item);
        void Update(EmergencyCall item);
        void Delete(int id);
        public IEnumerable<EmergencyCallsBySeasonAndFireStationResult> EmergencyCallsBySeason();
    }
}
