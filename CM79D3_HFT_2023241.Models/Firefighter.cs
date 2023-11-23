using CM79D3_HFT_2023241.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models
{
    /// <summary>
    /// Defines a firefighter working at a fire station.
    /// </summary>
    public class Firefighter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int Id { get; set; }
        [Required,StringLength(50)]
        [ToString]
        public string FirstName { get; set; }
        [Required,StringLength(50)]
        [ToString]
        public string LastName { get; set; }
        [StringLength(30)]
        [ToString]
        public string Rank { get; set; }
        [Required,StringLength(50)]
        [ToString]
        public string ContactInformation { get; set; }
        [ForeignKey(nameof(FireStation))]
        public int FireStation_ID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual FireStation FireStation { get; set; }
        [NotMapped]
        public virtual ICollection<Equipment> Equipment { get; set; }
        public Firefighter()
        {
            Equipment = new HashSet<Equipment>();
        }
        public override string ToString()
        {
            return StaticMethods.ToStringHelper(this) + "   " + "FireStation\t\t=> " + FireStation?.Name;
        }
        public override bool Equals(object obj)
        {
            if(obj is Firefighter f)
            {
                return this.Id == f.Id &&
                    this.FirstName == f.FirstName &&
                    this.LastName == f.LastName &&
                    this.Rank == f.Rank &&
                    this.ContactInformation == f.ContactInformation &&
                    this.FireStation_ID == f.FireStation_ID;
            }
            return false;
        }
    }
}
