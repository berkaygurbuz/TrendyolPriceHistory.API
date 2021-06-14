using Microsoft.EntityFrameworkCore;
using PriceHistory.Entities;
using System;

namespace PriceHistory.DataAcces
{ 
    public class PriceHistoryDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Change your mssql server name 
            optionsBuilder.UseSqlServer("Server=DESKTOP-KGIRMRG\\SQLEXPRESS;Database=DbPriceHistory;Integrated Security=True;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceHistories> PriceHistorys { get; set; }
    }
}
