using System.Collections.Generic;
using Kursach.Goods;
using Kursach.Users;

namespace Kursach
{
    public class Store
    {
        public List<User> UserList { get; set; }
        List<Product> Products { get; set; }
        User user { get; set; }
        public Store()
        {
            CustomerController userController = new CustomerController();
            UserList = new List<User>
            {
                userController.getUser(),
                userController.getVipUser()
            };
            Goods_Generator gg = new Goods_Generator();
            Products = gg.Goods_Gen();
        
        }

        private void Greeting()
        {
            Console.WriteLine("Welcome to our store\n" +
                "Which customer are you:" +
                "\n1. Customer" +
                "\n2. Vip customer" +
                "\nYour choice:");
            int customerSelection = Convert.ToInt32(Console.ReadLine());
            switch (customerSelection)
            {
                case 1:
                    user = UserList[0];
                    break;
                case 2:
                    user = UserList[1];
                    break;
                default:
                    Console.WriteLine("Okay, you will be a normal one.");
                    user = UserList[0];
                    break;
            }

            Console.WriteLine($"Welcome {user.Name}.");
            user.Check_Balance();
        }

        private void ProductPage(int productNumber)
        {
            Product product = Products[productNumber - 1];
            Console.WriteLine(product.Product_description());
            Console.WriteLine(product.Product_details());
            Console.WriteLine("1. Add to the cart\n2. Go back");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                user.Add_To_Cart(product);
            }
        }
        public void Run()
        {
            Greeting();


            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("1. Check the products\n" +
                                  "2. Add money to the balance\n"+
                                  "3. Check my cart\n" +
                                  "4. Exit");
                int customerSelection = Convert.ToInt32(Console.ReadLine());
                switch (customerSelection)
                {
                    case 1:
                        for (int i = 0; i < Products.Count(); i++)
                        {
                            Console.Write($"{i + 1}. ");
                             Console.WriteLine(Products[i].Product_description());
                        }
                        Console.WriteLine("Your choice: ");

                        string productNumber = Console.ReadLine();
                        if (!string.IsNullOrEmpty(productNumber) &&
                            productNumber.All(char.IsDigit) &&
                            Convert.ToInt32(productNumber) < Products.Count())
                        {
                            ProductPage(Convert.ToInt32(productNumber));
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the top up amount");
                        double input_sum;
                        if (!double.TryParse(Console.ReadLine(), out input_sum))
                        {
                            Console.WriteLine("Something went wrong, please try again");
                        }
                        else
                        {
                            user.Add_Balance(input_sum);
                            user.Check_Balance();
                        }

                        break;
                    case 3:
                        user.Cart.Check_cart();
                        Console.WriteLine("1.Buy products\n2.Go back");
                        int customerChoise = Convert.ToInt32(Console.ReadLine());
                        switch (customerChoise)
                        {
                            case 1:
                                user.Cart.Checkout();
                                break;
                            case 2:
                            default:
                                break;
                        }

                        break;
                    case 4:
                    default:
                        Console.WriteLine("Bye Bye");
                        isWorking = false;
                        break;
                }
            }


        }
    }
}