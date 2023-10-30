 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models
{
    public class HasEquipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HasEquipmentId { get; set; }
        public int FirefighterId { get; set; }
        public int EquipmentId { get; set; }
        public virtual Firefighter Firefighter { get; private set; }
        public virtual Equipment Equipment { get; private set; }
    }
}
