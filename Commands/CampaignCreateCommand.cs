using CampaignModule.Interfaces;

namespace CampaignModule.Commands
{
    public class CampaignCreateCommand : ICommand
    {
        public string Name { get; private set; }
        public string ProductCode { get; private set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }

        public CampaignCreateCommand(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            this.Name = name;
            this.ProductCode = productCode;
            this.Duration = duration;
            this.PriceManipulationLimit = priceManipulationLimit;
            this.TargetSalesCount = targetSalesCount;
        }
    }
}
