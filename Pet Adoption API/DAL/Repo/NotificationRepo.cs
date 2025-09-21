using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class NotificationRepo : IRepo<Notification, int, bool>
    {
        PAContext db;
        public NotificationRepo()
        {
            db = new PAContext();
        }

        public bool Create(Notification obj)
        {
            db.Notifications.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            if (ex == null) return false;
            db.Notifications.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Notification Get(int id)
        {
            return db.Notifications.Find(id);
        }

        public List<Notification> Get()
        {
            return db.Notifications.ToList();
        }

        public bool Update(Notification obj)
        {
            var ex = Get(obj.NotificationId);
            if (ex == null) return false;
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
