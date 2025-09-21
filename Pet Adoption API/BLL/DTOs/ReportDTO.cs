using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class ReportDTO
    {
        public Dictionary<string, int> PetsByCategory { get; set; }
        public Dictionary<string, int> AdoptionsByStatus { get; set; }
        public Dictionary<string, int> PetsByShelter { get; set; }
    }
}
