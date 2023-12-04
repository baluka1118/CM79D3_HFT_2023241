using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models.ClassesForQueries
{
    public class FireStationWithFirefighterCount
    {
        public string Name { get; set; }
        public int FirefighterCount { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is FireStationWithFirefighterCount f)
            {
                return this.Name == f.Name && this.FirefighterCount == f.FirefighterCount;
            }

            return false;
        }
    }
}
