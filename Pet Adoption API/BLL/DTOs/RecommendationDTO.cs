using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class RecommendationDTO
    {
        public int UserId { get; set; }
        public List<PetDTO> RecommendedPets { get; set; } = new List<PetDTO>();
    }
}
