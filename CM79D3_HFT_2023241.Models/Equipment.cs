using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models
{
    public enum EquipmentCondition
    {
        New,
        Good,
        Fair,
        Poor,
        OutOfService
    }

    class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Type { get; set; }
        [Required]
        public EquipmentCondition Condition { get; set; }
        //ide még kapcsolatok

    }
}
