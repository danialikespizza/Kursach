using System;
namespace Kursach.Goods
{
    public class Goods_Generator
    {
        public List<Product> Goods_Gen()
        {
                List<Product> products = new List<Product>()
            {
                new Product("Nokia 3310", 1000, "Some cool text here"),
                new Product("Nike Vapormax", 99.50, "Fine shoes"),
                new Product("Nike Air Max90", 150, "Classic"),
                new Product("Some drugs", 1500, "It is prohibited by the way"),
                new Product("Polyana", 10000000, "Priceless stuff"),
            };

            return products;
        }
    }
}
