using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Database;
using CM79D3_HFT_2023241.Repository.GenericRep;
using CM79D3_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Repository.ModelRepositories
{
    public class FirefighterRepository : Repository<Firefighter>, IRepository<Firefighter>
    {
        public FirefighterRepository(FireFightingDbContext ctx) : base(ctx)
        {
        }

        public override Firefighter Read(int id)
        {
            return ctx.Firefighters.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Firefighter item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null && prop.Name != "FullName")
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
