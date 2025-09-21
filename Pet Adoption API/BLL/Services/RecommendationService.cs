using BLL.DTOs;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class RecommendationService
    {
        public static RecommendationDTO RecommendPets(int userId)
        {
            // Get all favorites and adoptions for the user
            var userFavorites = DataAccessFactory.FavoriteData().Get()
                                .Where(f => f.UserId == userId)
                                .Select(f => f.PetId)
                                .ToList();

            var userAdoptions = DataAccessFactory.AdoptionData().Get()
                                .Where(a => a.UserId == userId)
                                .Select(a => a.PetId)
                                .ToList();

            // Combine to exclude already owned/favored pets
            var excludePets = userFavorites.Concat(userAdoptions).ToList();

            // Get user's favorite categories
            var favoriteCategories = DataAccessFactory.PetData().Get()
                                     .Where(p => userFavorites.Contains(p.PetId))
                                     .Select(p => p.Category)
                                     .Distinct()
                                     .ToList();

            // Get pets in user's favorite categories, excluding already adopted/favorited
            var categoryPets = DataAccessFactory.PetData().Get()
                               .Where(p => favoriteCategories.Contains(p.Category) && !excludePets.Contains(p.PetId))
                               .ToList();

            // Get most popular pets overall (by number of favorites) excluding already owned/favored
            var popularPetIds = DataAccessFactory.FavoriteData().Get()
                                .GroupBy(f => f.PetId)
                                .OrderByDescending(g => g.Count())
                                .Select(g => g.Key)
                                .Where(pid => !excludePets.Contains(pid))
                                .ToList();

            var popularPets = DataAccessFactory.PetData().Get()
                               .Where(p => popularPetIds.Contains(p.PetId))
                               .ToList();

            // Combine category-based and popular pets, remove duplicates
            var recommendedPets = categoryPets.Concat(popularPets)
                                   .GroupBy(p => p.PetId)
                                   .Select(g => g.First())
                                   .Select(p => new PetDTO
                                   {
                                       PetId = p.PetId,
                                       Name = p.Name,
                                       Age = p.Age,
                                       Gender = p.Gender,
                                       Breed = p.Breed,
                                       Category = p.Category,
                                       IsAdopted = p.IsAdopted,
                                       ShelterId = p.ShelterId,
                                       CreatedAt = p.CreatedAt,
                                       UpdatedAt = p.UpdatedAt
                                   }).ToList();

            return new RecommendationDTO
            {
                UserId = userId,
                RecommendedPets = recommendedPets
            };
        }
    }
}
