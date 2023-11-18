using CM79D3_HFT_2023241.Models;
using System.Collections.Generic;

namespace CM79D3_HFT_2023241.Logic.ClassesForQueries
{
    public class EmergencyCallsBySeasonAndFireStationResult
    {
        public string Season { get; set; }
        public string FireStation { get; set; }
        public IEnumerable<EmergencyCall> EmergencyCalls { get; set; }
    }
}