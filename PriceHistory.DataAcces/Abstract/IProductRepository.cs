using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.DataAcces.Abstract
{
    public interface IProductRepository
    {
        Task<List<Product>> getProducts();
        Task<Product> getProduct(int id);
        Task<Product> createProduct(Product product);
        Task<Product> updateProduct(Product product);
        Task deleteProduct(int id);

        Task acceptRequest(int id);
    }
}
