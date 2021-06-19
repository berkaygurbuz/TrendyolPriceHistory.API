using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceHistory.Entities
{
    public class Product
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string linkUrl { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string category { get; set; }
        public double price { get; set; }

        public bool isApprove { get; set; }
    }
}
