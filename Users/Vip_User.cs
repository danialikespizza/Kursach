using System;
namespace Kursach.Users
{
    public class Vip_User : User
    {
        double Bonus { get; set; }
        public Vip_User(string name) : base(name)
        {
            Bonus = 0.2;
        }

        public override void Add_Balance(double sum)
        {
            if (sum > 0)
            {
                Balance += (sum + sum * Bonus);
            }
            else { Console.WriteLine("Incorrect amount, number must be positive."); }
        }

        public override void Check_Balance()
        {
            Console.WriteLine($"You have {base.Balance}$ on your account, honey<3");
        }

    }
}