using System;
using System.Text;
using Kursach.Goods;

namespace Kursach.Users
{
    public class User
    {   public string Name { get; }
        public Cart Cart { get; }
        public double Balance { get; set; }
        public List<Receipt> PurchaseHistory { get; set; }

        public User(string name)
        {
            Name = name;
            Balance = 0;
            Cart = new Cart(this);
            PurchaseHistory = new List<Receipt>();
        }

        public virtual void Add_Balance(double sum)
        {
            if (sum > 0)
            {
                Balance += sum;
            }
            else { Console.WriteLine("Incorrect amount, number must be positive. "); }
        }

        public void Transaction_History()
        {
            StringBuilder sb = new StringBuilder("Transaction history: ");
            foreach(var i in PurchaseHistory)
            {
                sb.Append(i.Receipt_Display);
            }
            Console.WriteLine(sb.ToString());

        }

        public void Add_To_Cart(Product product)
        {
            Cart.Items.Add(product);
        }

        public void Purchase(Product product)
        {
            if (Balance - product.Price <= 0)
            {
                Console.WriteLine("Your are broke:( Go get some money");
            }
            else
            {
                Balance -= product.Price;
                PurchaseHistory.Add(new Receipt(new List<Product>((IEnumerable<Product>)product)));
                Console.WriteLine($"You have succesfully purchased {product.Name} for {product.Price.ToString()} $");
            }
        }

        public virtual void Check_Balance()
        {
            Console.WriteLine($"You have {Balance}$ on your account");
        }

    }

}

