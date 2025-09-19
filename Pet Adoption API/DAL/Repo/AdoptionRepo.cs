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
    internal class AdoptionRepo : IRepo<Adoption, int, bool>
    {
        PAContext db;

        public AdoptionRepo()
        {
            db = new PAContext();
        }

        public bool Create(Adoption obj)
        {
            db.Adoptions.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null) return false;

            db.Adoptions.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Adoption Get(int id)
        {
            return db.Adoptions.Find(id);
        }

        public List<Adoption> Get()
        {
            return db.Adoptions.ToList();
        }

        public bool Update(Adoption obj)
        {
            var exobj = Get(obj.AdoptionId);
            if (exobj == null) return false;

            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
