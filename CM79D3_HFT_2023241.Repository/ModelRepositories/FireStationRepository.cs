﻿using CM79D3_HFT_2023241.Models;
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
    public class FireStationRepository : Repository<FireStation>, IRepository<FireStation>
    {
        public FireStationRepository(FireFightingDbContext ctx) : base(ctx)
        {
        }

        public override FireStation Read(int id)
        {
            return ctx.FireStations.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(FireStation item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
