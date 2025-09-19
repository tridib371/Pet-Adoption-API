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
    internal class ShelterRepo : IRepo<Shelter, int, bool>
    {
        PAContext db;

        public ShelterRepo()
        {
            db = new PAContext();
        }

        public bool Create(Shelter obj)
        {
            db.Shelters.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null) return false;

            db.Shelters.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Shelter Get(int id)
        {
            return db.Shelters.Find(id);
        }

        public List<Shelter> Get()
        {
            return db.Shelters.ToList();
        }

        public bool Update(Shelter obj)
        {
            var exobj = Get(obj.ShelterId);
            if (exobj == null) return false;

            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
