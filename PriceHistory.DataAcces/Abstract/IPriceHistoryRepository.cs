﻿using PriceHistory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.DataAcces.Abstract
{
    public interface IPriceHistoryRepository
    {
        Task<PriceHistories> savePriceHistory(PriceHistories priceHistories);

    }
}
