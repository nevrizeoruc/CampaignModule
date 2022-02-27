using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModule
{
    public class Product
    {
        public string ProductCode { get;}
        public decimal Price { get; set; }
        public int Stock { get; }
        public Product()
        {

        }

        public Product(string productCode, decimal price, int stock)
        {
            this.ProductCode = productCode;
            this.Price = price;
            this.Stock = stock;

        }
    }
}
