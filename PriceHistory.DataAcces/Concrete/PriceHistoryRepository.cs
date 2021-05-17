using Microsoft.EntityFrameworkCore;
using PriceHistory.DataAcces.Abstract;
using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.DataAcces.Concrete
{
    public class PriceHistoryRepository : IPriceHistoryRepository
    {
        public async Task<Product> createProduct(Product product)
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                priceHistoryDbContext.Products.Add(product);
                await priceHistoryDbContext.SaveChangesAsync();
                return product;
            }
        }

        public async Task deleteProduct(int id)
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                priceHistoryDbContext.Products.Remove(await getProduct(id));
                await priceHistoryDbContext.SaveChangesAsync();
            }
        }


        public async Task<Product> getProduct(int id)
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                return await priceHistoryDbContext.Products.FindAsync(id);
            }
        }

        public async Task<List<Product>> getProducts()
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                return await priceHistoryDbContext.Products.ToListAsync();
            }
        }

        public async Task<Product> updateProduct(Product product)
        {
            using (var priceHistoryDbContext=new PriceHistoryDbContext())
            {
                priceHistoryDbContext.Update(product);
                await priceHistoryDbContext.SaveChangesAsync();
                return product;
            }
        }
    }
}
