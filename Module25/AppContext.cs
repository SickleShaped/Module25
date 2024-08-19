using Microsoft.EntityFrameworkCore;
using Module25.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Ваша строка подключения к БД");
        }
    }
}
