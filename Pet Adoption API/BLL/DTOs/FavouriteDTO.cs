using System;

namespace BLL.DTOs
{
    public class FavoriteDTO
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int PetId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
