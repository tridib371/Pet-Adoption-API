using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FavoriteRepo : IRepo<Favorite, int, bool>
    {
        PAContext db;

        public FavoriteRepo()
        {
            db = new PAContext();
        }

        public bool Create(Favorite obj)
        {
            db.Favorites.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null) return false;

            db.Favorites.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Favorite Get(int id)
        {
            return db.Favorites.Find(id);
        }

        public List<Favorite> Get()
        {
            return db.Favorites.ToList();
        }

        public bool Update(Favorite obj)
        {
            var exobj = Get(obj.FavoriteId);
            if (exobj == null) return false;

            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
