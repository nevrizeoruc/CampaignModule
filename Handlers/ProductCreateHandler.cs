using CampaignModule.Commands;
using CampaignModule.Interfaces;
using CampaignModule.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModule.Handlers
{
    public class ProductCreateHandler : ICommandHandler<ProductCreateCommand>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(ProductCreateCommand command)
        {
            Product newProduct = new Product
           (
               command.ProductCode,
               command.Price,
               command.Stock
           );

            _productRepository.Create(newProduct);
        }
    }
}
