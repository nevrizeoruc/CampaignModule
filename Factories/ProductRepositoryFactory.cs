using CampaignModule.Repositories;

namespace CampaignModule.Factories
{
    public static class ProductRepositoryFactory
    {
        public static ProductRepository GetInstance()
        {
            return new ProductRepository();
        }
    }
}
