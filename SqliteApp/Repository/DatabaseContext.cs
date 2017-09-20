using System;
using Microsoft.EntityFrameworkCore;
using SqliteApp.Helpers;
using SqliteApp.Models;
using Xamarin.Forms;

namespace SqliteApp.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private readonly string _databasePath;

        public DatabaseContext()
        {
            _databasePath = DependencyService.Get<IDbFileHelper>().GetLocalDbFilePath("ProductsSqlite.db");

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("Filename={0}", _databasePath));
        }
    }
}
