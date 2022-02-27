using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModule
{
   public class Order
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public Order()
        {

        }

        public Order(string productCode, int quantity)
        {
            this.ProductCode = productCode;
            this.Quantity = quantity;
        }
    }
}
