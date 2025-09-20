using System;

namespace BLL.DTOs
{
    public class PetDTO
    {
        public int PetId { get; set; }

        
        public string Name { get; set; }

        public int Age { get; set; }

        

        public string Gender { get; set; }

        
        public string Breed { get; set; }

        
        public string Category { get; set; } // Dog, Cat, Bird, etc.

        public bool IsAdopted { get; set; } = false;

        public int ShelterId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
