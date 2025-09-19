using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class Adoption
    {
        [Key]
        public int AdoptionId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Pet")]
        public int PetId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]

        public string Status { get; set; } // Pending, Approved, Rejected, Completed

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? DecisionDate { get; set; }

        // Navigation
        public virtual User User { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
