using PriceHistory.Business.Abstract;
using PriceHistory.DataAcces.Abstract;
using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Business.Concrete
{
    public class IProductManager : IProductService
    {

        private IProductRepository _productRepository;
        public IProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task acceptRequest(int id)
        {
            await _productRepository.acceptRequest(id);
        }

        public async Task<Product> createProduct(Product product)
        {
            return await _productRepository.createProduct(product);
        }

        public async Task deleteProduct(int id)
        {
            await _productRepository.deleteProduct(id);
        }

        public async Task<Product> getProduct(int id)
        {
            return await _productRepository.getProduct(id);
        }

        public async Task<List<Product>> getProductBySearch(string search)
        {
            return await _productRepository.getProductBySearch(search);
        }

        public async Task<List<Product>> getProducts()
        {
            return await _productRepository.getProducts();
        }

        public async Task<List<Product>> getRequests()
        {
            return await _productRepository.getRequests();
        }

        public async Task<Product> updateProduct(Product product)
        {
            return await _productRepository.updateProduct(product);
        }
    }
}
