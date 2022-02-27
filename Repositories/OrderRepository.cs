using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModule.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        List<Order> orders;

        public OrderRepository()
        {
            orders = new List<Order>();
        }

        public void Create(Order item)
        {
            if (item != null)
            {
                orders.Add(item);
            }
        }

        public Order GetInfo(string productCode)
        {
            Order findOrderInfo = null;
            if (orders != null && orders.Count > 0)
            {
                findOrderInfo = orders.Where(x => x.ProductCode == productCode)?.FirstOrDefault();
            }
            return findOrderInfo;
        }
    }
}
