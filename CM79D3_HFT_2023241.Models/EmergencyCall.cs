using CM79D3_HFT_2023241.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models
{
    public enum IncidentType
    {
        Fire,
        MedicalEmergency,
        Rescue,
        HazardousMaterials,
        NaturalDisaster,
        FalseAlarm,
        Other
    }
    public class EmergencyCall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int Id { get; set; }
        [Required, StringLength(50)]
        [ToString]
        public string callername { get; set; }
        [StringLength(50)]
        [ToString]
        public string CallerPhone { get; set;}
        [Required, StringLength(50)]
        [ToString]
        public string IncidentLocation { get; set; }
        [Required]
        [ToString]
        public IncidentType IncidentType { get; set; }
        [Required]
        [ToString]
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(FireStation))]
        public int FireStation_ID { get; set; }
        [NotMapped]
        public virtual FireStation FireStation { get; set; }
        public EmergencyCall()
        {
        }
        public override string ToString()
        {
            return StaticMethods.ToStringHelper(this) + "   " + "FireStation\t\t=>" + FireStation.Name;
        }
    }
}
