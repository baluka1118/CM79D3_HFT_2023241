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
    public class EquipmentRepository : Repository<Equipment>, IRepository<Equipment>
    {
        public EquipmentRepository(FireFightingDbContext ctx) : base(ctx)
        {
        }

        public override Equipment Read(int id)
        {
             return ctx.Equipments.FirstOrDefault(x => x.Id == id); 
        }

        public override void Update(Equipment item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
