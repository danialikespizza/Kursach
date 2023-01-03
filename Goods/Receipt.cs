using System;
using System.Text;

namespace Kursach.Goods
{
    public class Receipt
    {   double Total_price { get; }
        int Items_num { get; }
        List<Product> Items { get; }
        DateTime OrderTime { get; }
        public Receipt(List<Product> items)
        {
            double total_sum = 0;
            foreach(var i in items)
            {
                total_sum += i.Price;
            }
            Total_price = total_sum;
            Items_num = items.Count;
            Items = items;
            OrderTime = DateTime.Now;
        }
        public string Receipt_Display()
        {
            StringBuilder sb = new StringBuilder();
                sb.Append($"You have purchased {Items_num.ToString()} items for a total cost {Total_price.ToString()}");
                sb.Append("Items list: ");
                foreach (var i in Items)
                {
                    sb.Append(i.Product_description());
                }

            return sb.ToString();
        }
    }
}

