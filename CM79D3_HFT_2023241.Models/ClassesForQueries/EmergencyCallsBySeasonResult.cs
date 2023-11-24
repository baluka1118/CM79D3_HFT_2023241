using CM79D3_HFT_2023241.Models;
using System.Collections.Generic;

namespace CM79D3_HFT_2023241.Models.ClassesForQueries
{
    public class EmergencyCallsBySeasonResult
    {
        public string Season { get; set; }
        public string FireStation { get; set; }
        public List<EmergencyCall> EmergencyCalls { get; set; }
        public override bool Equals(object obj)
        {
            bool re = true;
            if (obj is EmergencyCallsBySeasonResult x)
            {
                if(this.Season == x.Season && x.FireStation == this.FireStation)
                {
                    foreach (var item in this.EmergencyCalls)
                    {
                        bool found = false;
                        foreach (var item2 in x.EmergencyCalls)
                        {
                            if (item.Equals(item2))
                            {
                                found = true;
                            }
                        }
                        if (!found) { re = false; }
                    }
                }
                else
                {
                    re = false;
                }
            }
            return re;
        }
    }
}