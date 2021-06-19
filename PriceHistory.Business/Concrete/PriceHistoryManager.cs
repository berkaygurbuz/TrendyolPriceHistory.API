using PriceHistory.Business.Abstract;
using PriceHistory.DataAcces.Abstract;
using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Business.Concrete
{
    public class IPriceHistoryManager : IPriceHistoryService
    {

        private IPriceHistoryRepository _priceHistoryRepository;
        public IPriceHistoryManager(IPriceHistoryRepository priceHistoryRepository)
        {
            _priceHistoryRepository = priceHistoryRepository;
        }

        public async Task<List<PriceHistories>> getPriceHistory()
        {
            return await _priceHistoryRepository.getPriceHistory();
        }

        public async Task<PriceHistories> savePriceHistory(PriceHistories priceHistories)
        {
            return await _priceHistoryRepository.savePriceHistory(priceHistories);

        }
    }
}
