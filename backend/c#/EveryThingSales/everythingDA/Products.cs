using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everythingDA
{
    public class Products
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public string ProductBarCode { get; set; }
        public decimal PriceOnSeller { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal SellingPriceTraders { get; set; }
        public DateTime LastUpdated { get; set; }
        public int QuantityAvailablePerPiece { get; set; }
        public double DiscountPercentage { get; set; }
        public string Notes { get; set; }
    }
}
