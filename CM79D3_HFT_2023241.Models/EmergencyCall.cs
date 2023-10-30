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
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string CallerName { get; set; }
        [Required, StringLength(50)]
        public string CallerPhone { get; set;}
        [Required, StringLength(50)]
        public string IncidentLocation { get; set; }
        [Required]
        public IncidentType IncidentType { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        [NotMapped]
        public virtual ICollection<Firefighter> Firefighters { get; set; }
        public EmergencyCall()
        {
            Firefighters = new HashSet<Firefighter>();
        }
    }
}
