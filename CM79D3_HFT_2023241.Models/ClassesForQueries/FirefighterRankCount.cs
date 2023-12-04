using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models.ClassesForQueries
{
    public class FirefighterRankCount
    {
        public string Rank { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is FirefighterRankCount f)
            {
                return this.Rank == f.Rank && this.Count == f.Count;
            }

            return false;
        }
    }
}
