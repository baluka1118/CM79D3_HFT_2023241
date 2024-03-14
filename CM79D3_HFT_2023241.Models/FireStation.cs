using CM79D3_HFT_2023241.Models.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

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
        [Required, StringLength(50)]
        [ToString]
        public string Name { get; set; }
        [Required]
        [ToString]
        public string Location { get; set; }
        [StringLength(50)]
        [ToString]
        public string ContactInformation { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Firefighter> Firefighters { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<EmergencyCall> EmergencyCalls { get; set; }
        public FireStation()
        {
            Firefighters = new HashSet<Firefighter>();
            EmergencyCalls = new HashSet<EmergencyCall>();
        }

        public override string ToString()
        {
            return StaticMethods.ToStringHelper(this)
                + "EmergencyCalls\t\t  => " + EmergencyCalls.Count;
        }

        public override bool Equals(object obj)
        {
            if (obj is FireStation f)
            {
                return this.Id == f.Id &&
                    this.Name == f.Name &&
                    this.Location == f.Location &&
                    this.ContactInformation == f.ContactInformation;
            }
            return false;
        }
    }
}
