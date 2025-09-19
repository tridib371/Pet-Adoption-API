using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(10)]

        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Breed { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Category { get; set; } // Dog, Cat, Bird, etc.

        [Required]
        public bool IsAdopted { get; set; } = false;

        [ForeignKey("Shelter")]
        public int ShelterId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public virtual Shelter Shelter { get; set; }
        public virtual List<Adoption> Adoptions { get; set; }
        public virtual List<Favorite> Favorites { get; set; }
    }
}
