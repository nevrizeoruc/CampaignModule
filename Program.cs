using CampaignModule.Commands;
using CampaignModule.Factories;
using CampaignModule.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace CampaignModule
{
    public class Program
    {
        static ProductRepository productRepo = ProductRepositoryFactory.GetInstance();
        static CampaignRepository campaignRepo = CampaignRepositoryFactory.GetInstance();
        static OrderRepository orderRepo = OrderRepositoryFactory.GetInstance();
        static DateTime dateTimeProperty = new DateTime(0);

        public static void CreateProduct(string productCode, decimal price, int stock)
        {
            ProductCreateCommand command = new ProductCreateCommand(productCode, price, stock);

            if (command != null)
            {
                Product product = new Product(command.ProductCode, command.Price, command.Stock);

                productRepo.Create(product);

                Console.WriteLine($"Product created; code {command.ProductCode}, price {command.Price}, stock {command.Stock} ");
            }
        }

        public static void GetProductInfo(string productCode)
        {
            Product productInfo = productRepo.GetInfo(productCode);

            if (productInfo != null)
            {
                Campaign campaign = campaignRepo.GetInfoByProduct(productCode);
                if(campaign !=null)
                {
                    
                    Console.WriteLine($"Product {productInfo.ProductCode} info; price {ManageCampaign(productInfo, campaign)}, stock {productInfo.Stock}");
                }
                else
                {
                    Console.WriteLine($"Product {productInfo.ProductCode} info; price {productInfo.Price}, stock {productInfo.Stock}");
                }
            }
        }

        public static void CreateOrder(string productCode, int quantity)
        {
            OrderCreateCommand command = new OrderCreateCommand(productCode, quantity);

            if (command != null)
            {
                Order order = new Order(command.ProductCode, command.Quantity);

                orderRepo.Create(order);

                Console.WriteLine($"Order created; product {command.ProductCode}, quantity {command.Quantity}");
            }
        }

        public static void CreateCampaign(string name, string productCode, int duration, int limit, int targetSalesCount)
        {
            CampaignCreateCommand command = new CampaignCreateCommand(name, productCode, duration, limit, targetSalesCount);

            if (command != null)
            {
                Campaign campaign = new Campaign(command.Name, command.ProductCode, command.Duration, command.PriceManipulationLimit, command.TargetSalesCount);

                campaignRepo.Create(campaign);

                Console.WriteLine($"Campaign created; name {command.Name}, product {command.ProductCode}, duration {command.Duration}, limit {command.PriceManipulationLimit} target sales count {command.TargetSalesCount}");
            }
        }

        public static decimal ManageCampaign(Product product, Campaign campaign)
        {
            double discount = 0;

            if (dateTimeProperty.Hour < campaign.Duration)
            {
                discount = Convert.ToDouble(product.Price)*5/100* dateTimeProperty.Hour;
                
            }
            
            return product.Price - Convert.ToDecimal(discount);
        }

        public static void IncreaseTime(int hour)
        {
            dateTimeProperty = dateTimeProperty.AddHours(hour);

            if (dateTimeProperty != null)
            {
                string endHour = dateTimeProperty.ToString("hh:mm");
                Console.WriteLine($"Time is {endHour}");
            }
        }

        public static void GetCampaignInfo(string name)
        {
            Campaign campaignInfo = campaignRepo.GetInfo(name);

            if(campaignInfo != null)
            {
                Console.WriteLine($"Campaign {name} info; Status Ended, Target Sales {campaignInfo.TargetSalesCount}, Total Sales 0, Turnover 0, Average Item Price -");
            }
        }

        public static void GetOrderInfo(string productCode)
        {
            Order orderInfo = orderRepo.GetInfo(productCode);
            
            if(orderInfo != null)
            {
                Console.WriteLine($"Order info; product code {orderInfo.ProductCode} quantity {orderInfo.Quantity}");
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Please enter the input file path : ");

            string inputFilePath = Console.ReadLine();

            Console.WriteLine();

            List<string> rowList = new List<string>();
            using (StreamReader sr = new StreamReader(@"" + inputFilePath))
            {
                string row;
                while ((row = sr.ReadLine()) != null)
                {
                    rowList.Add(row);
                    string[] methodNames = row.Split(' ');

                    if (methodNames[0].Contains("create_product"))
                    {
                        CreateProduct(methodNames[1], Convert.ToDecimal(methodNames[2]), Convert.ToInt32(methodNames[3]));
                    }

                    else if (methodNames[0].Contains("create_order"))
                    {
                        CreateOrder(methodNames[1], Convert.ToInt32(methodNames[2]));
                    }

                    else if (methodNames[0].Contains("create_campaign"))
                    {
                        CreateCampaign(methodNames[1], methodNames[2], Convert.ToInt32(methodNames[3]), Convert.ToInt32(methodNames[4]), Convert.ToInt32(methodNames[5]));
                    }

                    else if (methodNames[0].Contains("get_product_info"))
                    {
                        GetProductInfo(methodNames[1]);
                    }

                    else if (methodNames[0].Contains("get_campaign_info"))
                    {
                        GetCampaignInfo(methodNames[1]);
                    }

                    else if (methodNames[0].Contains("get_order_info"))
                    {
                        GetOrderInfo(methodNames[1]);
                    }

                    else if (methodNames[0].Contains("increase_time"))
                    {
                        IncreaseTime(Convert.ToInt32(methodNames[1]));
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
