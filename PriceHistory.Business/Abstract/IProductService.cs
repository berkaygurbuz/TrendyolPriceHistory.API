using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> getProducts();
        Task<List<Product>> getRequests();
        Task<List<Product>> getFilterByCategoryAndGender(string category, string gender);

        Task<Product> getProduct(int id);
        Task<List<Product>> getProductSearch(string search);

        Task<Product> createProduct(Product product);
        Task<Product> updateProduct(Product product);
        Task deleteProduct(int id);
        Task acceptRequest(int id);

        Task<List<Product>> getProductBySearch(string search);

    }
}
