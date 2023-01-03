using System;
namespace Kursach.Goods
{
    public class Product
    {   public string Name { get; set; }
        public double Price { get; set; }
        public string Description{ get; set; }

        public Product(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
        public string Product_description()
        {
            return $"{Name} costs {Price.ToString()} $";
        }
        public string Product_details()
        {
            return Description;
        }
    }
}

