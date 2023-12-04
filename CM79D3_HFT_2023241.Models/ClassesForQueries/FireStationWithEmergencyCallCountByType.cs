using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models.ClassesForQueries
{
    public class FireStationWithEmergencyCallCountByType
    {
        public string Name { get; set; }
        public IEnumerable<EmergencyCallCount> EmergencyCallCounts { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is FireStationWithEmergencyCallCountByType f)
            {
                return this.Name == f.Name && this.EmergencyCallCounts.SequenceEqual(f.EmergencyCallCounts);
            }

            return false;
        }
    }
}
