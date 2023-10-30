using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models
{
    public class OnCall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OnCallId { get; set; }
        public int FirefighterId { get; set; }
        public int EmergencyCallId { get; set; }
        public virtual Firefighter Firefighter { get; private set; }
        public virtual EmergencyCall EmergencyCall { get; private set; }
    }
}
