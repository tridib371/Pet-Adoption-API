using System;

namespace BLL.DTOs
{
    public class AdoptionDTO
    {
        public int AdoptionId { get; set; }
        public int UserId { get; set; }
        public int PetId { get; set; }
        public DateTime AdoptionDate { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
