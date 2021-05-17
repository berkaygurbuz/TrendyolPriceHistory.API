using PriceHistory.Business.Abstract;
using PriceHistory.DataAcces.Abstract;
using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Business.Concrete
{
    public class PriceHistoryManager : IPriceHistoryService
    {

        private IPriceHistoryRepository _priceHistoryRepository;
        public PriceHistoryManager(IPriceHistoryRepository priceHistoryRepository)
        {
            _priceHistoryRepository = priceHistoryRepository;
        }
        public async Task<Product> createProduct(Product product)
        {
            return await _priceHistoryRepository.createProduct(product);
        }

        public async Task deleteProduct(int id)
        {
            await _priceHistoryRepository.deleteProduct(id);
        }

        public async Task<Product> getProduct(int id)
        {
            return await _priceHistoryRepository.getProduct(id);
        }

        public async Task<List<Product>> getProducts()
        {
            return await _priceHistoryRepository.getProducts();
        }

        public async Task<Product> updateProduct(Product product)
        {
            return await _priceHistoryRepository.updateProduct(product);
        }
    }
}
