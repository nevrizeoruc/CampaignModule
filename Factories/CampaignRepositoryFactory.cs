using CampaignModule.Repositories;

namespace CampaignModule.Factories
{
    public static class CampaignRepositoryFactory
    {
        public static CampaignRepository GetInstance()
        {
            return new CampaignRepository();
        }
    }
}
