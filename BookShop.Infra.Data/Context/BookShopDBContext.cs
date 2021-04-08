using BookShop.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infra.Data.Context
{
    public class BookShopDBContext : DbContext
    {
        private const string ConnectionString =
            @"Server=.\SQLEXPRESS; Database=BookShopDB; Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString);
        }

        public DbSet<Book> Books { get; set; }
    }
}
