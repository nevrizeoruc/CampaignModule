using CampaignModule.Repositories;

namespace CampaignModule.Factories
{
    public static class OrderRepositoryFactory
    {
        public static OrderRepository GetInstance()
        {
            return new OrderRepository();
        }
    }
}
