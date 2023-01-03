using System;
using System.Text;
using Kursach.Users;

namespace Kursach.Goods
{
    public class Cart
    {
        User User { get; }
        public List<Product> Items { get; set; }
        public Cart(User user)
        {
            User = user;
            Items = new List<Product>();
        }

        public void Clear_cart()
        {
            Items.Clear();
        }

        public void Checkout()
        {
            if (Items.Count == 0) { Console.WriteLine("Your card is empty, try to add something before checkout"); }
            else
            {
                double total_sum = 0;
                foreach (var item in Items)
                {
                    total_sum += item.Price;
                }

                if (User.Balance - total_sum <= 0)
                {
                    Console.WriteLine("Not enough money for the payment, please top up your balance<3");
                }
                else
                {
                    User.Balance -= total_sum;
                    User.PurchaseHistory.Add(new Receipt(this.Items));
                    Console.WriteLine("Thanks for your purchase");
                    Clear_cart();
                }
            }
        }

        public void Check_cart()
        {
            double sum = 0;
            foreach(var i in Items)
            {
                sum += i.Price;
            }
            Console.WriteLine($"You have added {Items.Count.ToString()} items for a total cost {sum.ToString()}");
            Console.WriteLine("Items list: ");
            foreach(var i in Items)
            {
                Console.WriteLine(i.Product_description());
            }
        }
    }
}

