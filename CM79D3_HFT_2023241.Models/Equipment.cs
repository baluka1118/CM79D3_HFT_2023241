﻿using CM79D3_HFT_2023241.Models.Attributes;
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

    public class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int Id { get; set; }
        [Required,StringLength(50)]
        [ToString]
        public string Type { get; set; }
        [Required]
        [ToString]
        public EquipmentCondition Condition { get; set; }
        [ForeignKey(nameof(Firefighter))]
        public int Firefighter_ID { get; set; }
        [NotMapped]
        public virtual Firefighter Firefighter { get; set; }
        public Equipment()
        {
        }
        public override string ToString()
        {
            return StaticMethods.ToStringHelper(this) + "   " + "Firefighter\t\t=>" + Firefighter.FirstName + " " + Firefighter.LastName;
        }
    }
}
