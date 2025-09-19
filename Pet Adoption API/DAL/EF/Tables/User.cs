using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]

        public string Role { get; set; } // Admin / Adopter

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public virtual List<Adoption> Adoptions { get; set; }
        public virtual List<Favorite> Favorites { get; set; }
    }
}
