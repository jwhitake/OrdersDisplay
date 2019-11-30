using OrderDisplay.Core;
using OrdersDisplay.Domain;
using OrderDisplay.Data;
using OrderDisplay.CustomerUI;
using System;
using Microsoft.EntityFrameworkCore;
using OrderDisplay.CustomerUI.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           PopulateOrdersTable();
            //Configuration configuration = new Configuration();
            //Console.WriteLine(configuration.ApiUrl);

            //User user = new User
            //{
            //    FirstName = "John",
            //    LastName = "Whitaker",
            //    LoginName = "jwhitake",
            //    //Password = "asddffgd",
            //    Email = "Chum@dolt.com"
            //};
            //user.SetUserPassword("asddffgd");

            //var representation = user.ToString();
            //Console.WriteLine(representation);

            //user = user.SetUserSalt("SaltSetting");
            //Console.WriteLine($"Users first name is {user.FirstName}");
            //Console.WriteLine($"User's password is {user.Password}");
            //Console.WriteLine(user.GetSaltProperty());
        }

        private async static void PopulateOrdersTable()
        {
            Configuration config = new Configuration();
            var optionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>();
            optionsBuilder.UseSqlServer(config.ConnectionString);
            var context = new OrdersDbContext(optionsBuilder.Options);

            var user = new User
            {
                LoginName = "LightBringer",
                FirstName = "Lucifer",
                LastName = "MorningStar",
                Email = "Satan@Celestial.gov"
            };
            user.SetUserPassword("H3llF1r3!1");
            var salt = Cipher.GetSalt();
            user.SetUserPassword(Cipher.HashPassword(user.Password, salt));
            var encryptedSalt = Cipher.Encrypt(Convert.ToBase64String(salt));
            user = user.SetUserSalt(encryptedSalt);
            //context.Users.Add(user);
            //try
            //{
            //    var result = await context.SaveChangesAsync();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);
            //}
            //return 1;


            // var users = context.Users.ToListAsync().Result;
            //// var users = JsonConvert.DeserializeObject<List<User>>(result);
            // foreach (var u in users)
            // {
            //     Console.WriteLine(u.LoginName);
            // }





            //context.Users.Add(user);
            //await context.SaveChangesAsync();
            Thread.Sleep(6000);
            HttpHelper api = new HttpHelper();
            var client = api.Initial();
            IEnumerable<User> users;
            var strJson = JsonConvert.SerializeObject(user);
            HttpResponseMessage res = await client.PostAsync("api/Users/", new StringContent(strJson, Encoding.UTF8, "application/json"));
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(result);
                foreach (var u in users)
                {
                    Console.WriteLine(u.LoginName);
                }
            }
            
        }
    }
}
