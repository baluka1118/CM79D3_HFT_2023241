using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models
{
    /// <summary>
    /// Defines a firefighter working at a fire station.
    /// </summary>
    class Firefighter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Rank { get; set; }
        [Required,StringLength(50)]
        public string ContactInformation { get; set; }
        //ide még kapcsolatok

    }
}
