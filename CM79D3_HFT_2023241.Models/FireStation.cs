using CM79D3_HFT_2023241.Models.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace CM79D3_HFT_2023241.Models
{
    /// <summary>
    /// Defines a fire station where firefighters work and emergency calls happen.
    /// </summary>
    public class FireStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int Id { get; set; }
        [Required, StringLength(100)]
        [ToString]
        public string Name { get; set; }
        [Required]
        [ToString]
        public string Location { get; set; }
        [StringLength(100)]
        [ToString]
        public string ContactInformation { get; set; }
        [NotMapped]
        public virtual ICollection<Firefighter> Firefighters { get; set; }
        [NotMapped]
        public virtual ICollection<EmergencyCall> EmergencyCalls { get; set; }
        public FireStation()
        {
            Firefighters = new HashSet<Firefighter>();
            EmergencyCalls = new HashSet<EmergencyCall>();
        }

        public override string ToString()
        {
            return StaticMethods.ToStringHelper(this)
                + "   " + "Firefighters\t\t=> " + Firefighters.Count
                + "   " + "EmergencyCalls\t\t=> " + EmergencyCalls.Count;
        }
    }
}
