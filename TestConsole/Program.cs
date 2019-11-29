using OrdersDisplay.Domain;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                FirstName = "John",
                LastName = "Whitaker",
                LoginName = "jwhitake",
                Password = "asddffgd",
                Email = "Chum@dolt.com"
            };
            user = user.SetUserSalt("SaltSetting");
            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.GetSaltProperty());
        }
    }
}
