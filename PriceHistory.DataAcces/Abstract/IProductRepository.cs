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
        Task<List<Product>> getFilterByCategoryAndGender(string category,string gender);

        Task<List<Product>> getRequests();

        Task<Product> getProduct(int id);
        Task<List<Product>> getProductBySearch(string search);

        Task<Product> createProduct(Product product);
        Task<Product> updateProduct(Product product);
        Task deleteProduct(int id);

        Task acceptRequest(int id);


    }
}
