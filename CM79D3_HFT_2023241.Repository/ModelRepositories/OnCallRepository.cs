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
    public class OnCallRepository : Repository<OnCall>, IRepository<OnCall>
    {
        public OnCallRepository(FireFightingDbContext ctx) : base(ctx)
        {
        }

        public override OnCall Read(int id)
        {
            return ctx.OnCall.FirstOrDefault(x => x.OnCallId == id);
        }

        public override void Update(OnCall item)
        {
            var old = Read(item.OnCallId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
