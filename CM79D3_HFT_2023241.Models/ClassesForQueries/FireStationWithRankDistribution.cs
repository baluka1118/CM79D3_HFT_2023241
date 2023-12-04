using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models.ClassesForQueries
{
    public class FireStationWithRankDistribution
    {
        public string Name { get; set; }
        public IEnumerable<FirefighterRankCount> RankDistribution { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is FireStationWithRankDistribution f)
            {
                return this.Name == f.Name && this.RankDistribution.SequenceEqual(f.RankDistribution);
            }

            return false;
        }
    }
}
