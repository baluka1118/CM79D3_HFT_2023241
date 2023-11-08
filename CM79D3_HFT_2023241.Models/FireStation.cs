using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM79D3_HFT_2023241.Models
{
    /// <summary>
    /// Defines a fire station where firefighters work.
    /// </summary>
    public class FireStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [StringLength(100)]
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
    }
}
