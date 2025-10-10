using System;

namespace BLL.DTOs
{
    public class AdoptionDTO
    {
        public int AdoptionId { get; set; }
        public int UserId { get; set; }
        public int PetId { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DecisionDate { get; set; }
    }
}
