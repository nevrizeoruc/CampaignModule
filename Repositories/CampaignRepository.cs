using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        List<Campaign> campaigns = new List<Campaign>();

        public void Create(Campaign item)
        {
            if (item != null)
            {
                campaigns.Add(item);
            }
        }

        public Campaign GetInfo(string name)
        {
            Campaign findCampaignInfo = null;

            if (campaigns != null && campaigns.Count > 0)
            {
                findCampaignInfo = campaigns.Where(x => x.Name == name)?.FirstOrDefault();
            }
            return findCampaignInfo;
        }

        public Campaign GetInfoByProduct(string productCode)
        {
            Campaign findCampaignInfo = null;

            if (campaigns != null && campaigns.Count > 0)
            {
                findCampaignInfo = campaigns.Where(x => x.ProductCode == productCode)?.FirstOrDefault();
            }
            return findCampaignInfo;
        }
    }
}
