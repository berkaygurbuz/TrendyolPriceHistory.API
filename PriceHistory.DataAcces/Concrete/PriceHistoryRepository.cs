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
        public async Task<List<PriceHistories>> getPriceHistory()
        {
            using(var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                return await priceHistoryDbContext.PriceHistorys.ToListAsync();
            }
        }

        public async Task<PriceHistories> savePriceHistory(PriceHistories priceHistories)
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                priceHistoryDbContext.PriceHistorys.Add(priceHistories);
                await priceHistoryDbContext.SaveChangesAsync();
                return priceHistories;
            }
        }
    }
}
