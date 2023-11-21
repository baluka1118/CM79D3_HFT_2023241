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
        public string CallerName { get; set; }
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
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (obj is EmergencyCall e)
            {
                if (this.Id == e.Id && this.CallerName == e.CallerName && this.CallerPhone == e.CallerPhone && this.IncidentType == e.IncidentType &&
                    this.IncidentLocation == e.IncidentLocation && this.FireStation_ID == e.FireStation_ID)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
