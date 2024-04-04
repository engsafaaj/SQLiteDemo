using Microsoft.EntityFrameworkCore;
using SQLiteDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Data
{
    public class DataBaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SqliteDemoDataBase.db");

        }


        // Add Tables

        public DbSet<Note> Note { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
