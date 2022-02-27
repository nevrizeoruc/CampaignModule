using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModule
{
    public class Campaign
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }

        public Campaign()
        {

        }

        public Campaign(string name,string productCode, int duration, int limit, int targetSalesCount)
        {
            this.Name = name;
            this.ProductCode = productCode;
            this.Duration = duration;
            this.PriceManipulationLimit = limit;
            this.TargetSalesCount = targetSalesCount;
        }
    }
}
