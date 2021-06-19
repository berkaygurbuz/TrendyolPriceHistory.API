using Microsoft.EntityFrameworkCore;
using PriceHistory.DataAcces.Abstract;
using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.DataAcces.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public async Task acceptRequest(int id)
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                var product=await getProduct(id);
                if (product.isApprove == false)
                {
                product.isApprove = true;
                priceHistoryDbContext.Update(product);
                await priceHistoryDbContext.SaveChangesAsync();
                }
                else
                {
                    product.isApprove = false;
                    priceHistoryDbContext.Update(product);
                    await priceHistoryDbContext.SaveChangesAsync();
                }
            }
        }

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

        public async Task<List<Product>> getProductBySearch(string search)
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {

                var product= await priceHistoryDbContext.Products.Where(x => x.brand.Contains(search)).ToListAsync();
                return product;
            }
        }

        public async Task<List<Product>> getProducts()
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                return await priceHistoryDbContext.Products.ToListAsync();
            }
        }

        public async Task<List<Product>> getRequests()
        {
            using(var priceHistoryDbContext=new PriceHistoryDbContext())
            {
                return await priceHistoryDbContext.Products.Where(x => x.isApprove == false).ToListAsync();
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
