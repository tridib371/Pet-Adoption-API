using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class Shelter
    {
        [Key]
        public int ShelterId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]  // Make Address required to avoid validation errors
        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]  // Make Phone required
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]  // Make Email required
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public virtual List<Pet> Pets { get; set; }
    }
}
