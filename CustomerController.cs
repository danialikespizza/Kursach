using Kursach.Users;
using Kursach.Goods;
namespace Kursach;

    class CustomerController
    {
        public User getUser()
        {
            return new User("Bichara");
        }

        public User getVipUser()
        {
            return new Vip_User("Mazhik");
        }
    }
