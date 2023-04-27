namespace SamilBeySessionEx.Models
{
    public static class Data
    {
        public static List<Product> Products { get; set; }
        public static List<User> Users { get; set; }
        public static User LoginUser { get; set; }
        static Data()
        {
            Products= new List<Product>() 
            { 
                new Product()
                {
                    Id= 1,
                    Name = "telefon",
                    Price = 10000,
                    Stock = 10
                },
                new Product()
                {
                    Id= 2,
                    Name = "laptop",
                    Price = 12000,
                    Stock = 17
                },
                 new Product()
                {
                    Id= 3,
                    Name = "Tv",
                    Price = 16000,
                    Stock = 16
                }
            };

            Users = new List<User>()
            {
                new User()
                {
                    Id= 1,
                    Username = "samil",
                    Email = "samil@gmail.com",
                    Password = "1234"
                },
                 new User()
                {
                    Id= 2,
                    Username = "ibrahim",
                    Email = "ibrahim@gmail.com",
                    Password = "123"
                }
            };
        }

    }
}
