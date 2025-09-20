using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class ShelterRepo : IRepo<Shelter, int, Shelter>
    {
        PAContext db;

        public ShelterRepo()
        {
            db = new PAContext();
        }

        public Shelter Create(Shelter obj)
        {
            db.Shelters.Add(obj);
            db.SaveChanges();
            return obj;
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

        public Shelter Update(Shelter obj)
        {
            var exobj = Get(obj.ShelterId);
            if (exobj == null) return null;

            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return exobj;
        }
    }
}
