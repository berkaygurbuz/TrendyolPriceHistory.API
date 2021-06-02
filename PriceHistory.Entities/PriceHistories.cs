using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PriceHistory.Entities
{
    public class PriceHistories

    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriceHistoryId { get; set; }
        public int ProductId { get; set; }

        public DateTime date { get; set; }

        public double price { get; set; }

    }
}
