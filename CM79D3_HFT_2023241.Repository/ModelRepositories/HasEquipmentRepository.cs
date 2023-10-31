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
    public class HasEquipmentRepository : Repository<HasEquipment>, IRepository<HasEquipment>
    {
        public HasEquipmentRepository(FireFightingDbContext ctx) : base(ctx)
        {
        }

        public override HasEquipment Read(int id)
        {
            return ctx.HasEquipment.FirstOrDefault(x => x.HasEquipmentId == id);
        }

        public override void Update(HasEquipment item)
        {
            var old = Read(item.HasEquipmentId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
