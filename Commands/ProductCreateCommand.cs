using CampaignModule.Interfaces;

namespace CampaignModule.Commands
{
    public class ProductCreateCommand : ICommand
    {
        public string ProductCode { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public ProductCreateCommand(string productCode, decimal price, int stock)
        {
            this.ProductCode = productCode;
            this.Price = price;
            this.Stock = stock;
        }
    }
}
