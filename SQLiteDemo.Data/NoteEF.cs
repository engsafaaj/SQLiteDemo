using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLiteDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Data
{
    public class NoteEF : IDataHelper<Note>
    {
        private DataBaseContext db;

        private Note table;
        public NoteEF()
        {
            db = new DataBaseContext();
            table = new Note();
        }

        public int Add(Note table)
        {
            try
            {
                db.Note.Add(table);
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
                db.Note.Remove(table);
                db.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }

        public Note Find(int Id)
        {
            try
            {
                return db.Note.Where(x => x.Id == Id).FirstOrDefault() ?? new Note();
            }
            catch { return new Note(); }
        }

        public List<Note> GetAllData()
        {
            try
            {
                return db.Note.ToList();
            }
            catch { return new List<Note>(); }
        }

        public List<Note> Search(string searchIteam)
        {
            try
            {
                return db.Note.Where(x => x.Id.ToString() == searchIteam ||
                x.Title.Contains(searchIteam) ||
                x.Description.Contains(searchIteam))
                    .ToList();
            }
            catch { return new List<Note>(); }
        }

        public int Update(Note table)
        {
            try
            {
                db = new DataBaseContext();
                db.Note.Update(table);
                db.SaveChanges();
                return 1;
            }
            catch { return 0; }
        }
    }
}
