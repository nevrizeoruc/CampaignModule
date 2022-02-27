using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Repositories
{
    public class ProductRepository : IProductRepository
    {
        List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
        }

        public void Create(Product item)
        {
            if (item != null)
            {
                products.Add(item);
            }
        }

        public Product GetInfo(string productCode)
        {
            Product findProductInfo = null;

            if (products != null)
            {
                findProductInfo = products.Where(x => x.ProductCode == productCode)?.FirstOrDefault();
            }

            return findProductInfo;
        }
    }
}
