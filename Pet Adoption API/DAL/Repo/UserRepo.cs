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
    internal class UserRepo : IRepo<User, int, User>, IUserF
    {
        PAContext db;

        public UserRepo()
        {
            db = new PAContext();
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null) return false;

            db.Users.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Update(User obj)
        {
            var exobj = Get(obj.UserId); 
            if (exobj == null) return null;

            exobj.FullName = obj.FullName;
            exobj.Email = obj.Email;
            exobj.PhoneNumber = obj.PhoneNumber;
            exobj.PasswordHash = obj.PasswordHash;
            exobj.Role = obj.Role;
            exobj.UpdatedAt = obj.UpdatedAt;

            db.SaveChanges();
            return exobj;
        }

        public User Patch(int id, User obj)
        {
            var exobj = Get(id); 
            if (exobj == null) return null;

            if (!string.IsNullOrEmpty(obj.FullName)) exobj.FullName = obj.FullName;
            if (!string.IsNullOrEmpty(obj.Email)) exobj.Email = obj.Email;
            if (!string.IsNullOrEmpty(obj.PhoneNumber)) exobj.PhoneNumber = obj.PhoneNumber;
            if (!string.IsNullOrEmpty(obj.PasswordHash)) exobj.PasswordHash = obj.PasswordHash;
            if (!string.IsNullOrEmpty(obj.Role)) exobj.Role = obj.Role;

            exobj.UpdatedAt = DateTime.Now;

            db.SaveChanges();
            return exobj;
        }




    }
}
