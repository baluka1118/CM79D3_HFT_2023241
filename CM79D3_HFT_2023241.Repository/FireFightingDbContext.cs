using CM79D3_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Repository
{
    public class FireFightingDbContext : DbContext
    {
        public virtual DbSet<FireStation> FireStations { get; set; }
        public virtual DbSet<Firefighter> Firefighters { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EmergencyCall> EmergencyCalls { get; set; }

    }
}
