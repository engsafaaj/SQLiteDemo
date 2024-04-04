using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLiteDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Data
{
    public class UsersEF : IDataHelper<Users>
    {
        private DataBaseContext db;

        private Users table;
        public UsersEF()
        {
            db = new DataBaseContext();
            table = new Users();
        }

        public int Add(Users table)
        {
            try
            {
                db.Users.Add(table);
                db.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }

        public int Delete(int Id)
        {
            try
            {
                table = Find(Id);
                db.Users.Remove(table);
                db.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }

        public Users Find(int Id)
        {
            try
            {
                return db.Users.Where(x => x.Id == Id).FirstOrDefault() ?? new Users();
            }
            catch { return new Users(); }
        }

        public List<Users> GetAllData()
        {
            try
            {
                return db.Users.ToList();
            }
            catch { return new List<Users>(); }
        }

        public List<Users> Search(string searchIteam)
        {
            try
            {
                return db.Users.Where(x => x.Id.ToString() == searchIteam ||
                x.UserName.Contains(searchIteam) ||
                x.Password.Contains(searchIteam))
                    .ToList();
            }
            catch { return new List<Users>(); }
        }

        public int Update(Users table)
        {
            try
            {
                db = new DataBaseContext();
                db.Users.Update(table);
                db.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }
    }
}
