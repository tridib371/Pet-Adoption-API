using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }

        public static IUserF UserPatchData()
        {
            return new UserRepo();
        }

        public static IRepo<Shelter, int, Shelter> ShelterData()
        {
            return new ShelterRepo();
        }


        public static IRepo<Pet, int, bool> PetData()
        {
            return new PetRepo();
        }

        public static IRepo<Adoption, int, bool> AdoptionData()
        {
            return new AdoptionRepo();
        }

        public static IRepo<Favorite, int, bool> FavoriteData()
        {
            return new FavoriteRepo();
        }
    }
}
