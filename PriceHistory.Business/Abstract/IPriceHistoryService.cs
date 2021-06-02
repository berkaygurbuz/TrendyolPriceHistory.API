using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Business.Abstract
{
    public interface IPriceHistoryService
    {
        Task<PriceHistories> savePriceHistory(PriceHistories priceHistories);

    }
}
