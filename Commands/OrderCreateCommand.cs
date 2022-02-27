using CampaignModule.Interfaces;

namespace CampaignModule.Commands
{
    public class OrderCreateCommand: ICommand
    {
        public string ProductCode { get; private set; }
        public int Quantity { get; private set; }

        public OrderCreateCommand(string productCode, int quantity)
        {
            this.ProductCode = productCode;
            this.Quantity = quantity;
        }
    }
}
