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
            GetOrders();
        }


        public static async Task<List<Order>> GetOrders()
        {
            HttpHelper api = new HttpHelper();
            var client = api.Initial();
            List<Order> orders = new List<Order>();
            //var strJson = JsonConvert.SerializeObject(order);
            try
            {
                HttpResponseMessage res = await client.GetAsync("api/Orders");
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<Order>>(result);
                    foreach (var o in orders)
                    {
                        Console.WriteLine($"{o.TapeType} {o.Quantity}");
                    }
                }

            }

            catch { }
            return orders;
        }

        private async static void PopulateOrders()
        {
            Configuration config = new Configuration();

            var optionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>();
            optionsBuilder.UseSqlServer(config.ConnectionString);
            var context = new OrdersDbContext(optionsBuilder.Options);
            string date = DateTime.Now.ToString();
            Order order = new Order
            {
                PurchaseOrderId = "PO1234",
                OrderDate = DateTime.Now,
                Sequence = "00001",
                TapeType = "Magnetic",
                Quantity = 7,
                InternalOrderId = "S0001",
                Location = "Los Angeles",
                Tracking = "12ZKKX87475HG",
                PointOfContact = "Lou Costello"
            };
            context.Orders.Add(order);
            order = new Order
            {
                PurchaseOrderId = "PO1235",
                OrderDate = DateTime.Now,
                Sequence = "00001",
                TapeType = "Inter-Leaf Mag",
                Quantity = 10,
                InternalOrderId = "S0002",
                Location = "Boca Raton",
                EstimatedDeliveryDate = DateTime.Now.AddDays(3),
                Tracking = "12ZKKX87475HG",
                PointOfContact = "Bud Abbott"
            };
            context.Orders.Add(order);
            order = new Order
            {
                PurchaseOrderId = "PO1236",
                OrderDate = DateTime.Now,
                Sequence = "00001",
                TapeType = "Magnetic",
                Quantity = 1,
                InternalOrderId = "S0003",
                Location = "Boca Raton",
                EstimatedDeliveryDate = DateTime.Now.AddDays(3),
                Tracking = "12ZKKX87475HG",
                PointOfContact = "Bud Abbott"
            };
            context.Orders.Add(order);
            order = new Order
            {
                PurchaseOrderId = "PO1237",
                OrderDate = DateTime.Now,
                Sequence = "00001",
                TapeType = "Magnetic",
                Quantity = 22,
                InternalOrderId = "S0004",
                Location = "Los Angeles",
                EstimatedDeliveryDate = DateTime.Now.AddDays(3),
                Tracking = "12ZKKX87475HG",
                PointOfContact = "Lou Costello"
            };
            context.Orders.Add(order);
            order = new Order
            {
                PurchaseOrderId = "PO1238",
                OrderDate = DateTime.Now,
                Sequence = "00001",
                TapeType = "Inter-Leaf Mag",
                Quantity = 13,
                InternalOrderId = "S0005",
                Location = "Los Angeles",
                EstimatedDeliveryDate = DateTime.Now.AddDays(3),
                Tracking = "12ZKKX87475HG",
                PointOfContact = "Lou Costello"
            };
            context.Orders.Add(order);
            order = new Order
            {
                PurchaseOrderId = "PO1239",
                OrderDate = DateTime.Now,
                Sequence = "00001",
                TapeType = "Magnetic",
                Quantity = 6,
                InternalOrderId = "S0006",
                Location = "Boca Raton",
                Tracking = "12ZKKX87475HG",
                EstimatedDeliveryDate = DateTime.Now.AddDays(3),
                PointOfContact = "Bud Abbott"
            };
            context.Orders.Add(order);
            try
            {
                int i = await context.SaveChangesAsync();
            }
            catch (DbUpdateException DbEx)
            {
                string strError = DbEx.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        //private async static void PopulateOrdersTable()
        //{
        //    Configuration config = new Configuration();
        //    var optionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>();
        //    optionsBuilder.UseSqlServer(config.ConnectionString);
        //    var context = new OrdersDbContext(optionsBuilder.Options);

        //    var user = new User
        //    {
        //        LoginName = "LightBringer",
        //        FirstName = "Lucifer",
        //        LastName = "MorningStar",
        //        Email = "Satan@Celestial.gov"
        //    };
        //    user.SetUserPassword("H3llF1r3!1");
        //    var salt = Cipher.GetSalt();
        //    user.SetUserPassword(Cipher.HashPassword(user.Password, salt));
        //    var encryptedSalt = Cipher.Encrypt(Convert.ToBase64String(salt));
        //    user = user.SetUserSalt(encryptedSalt);   
            


        //    //HttpHelper api = new HttpHelper();
        //    //var client = api.Initial();
        //    //IEnumerable<User> users;
        //    //var strJson = JsonConvert.SerializeObject(user);
        //    //HttpResponseMessage res = await client.PostAsync("api/Users/", new StringContent(strJson, Encoding.UTF8, "application/json"));
        //    //if (res.IsSuccessStatusCode)
        //    //{
        //    //    var result = res.Content.ReadAsStringAsync().Result;
        //    //    users = JsonConvert.DeserializeObject<List<User>>(result);
        //    //    foreach (var u in users)
        //    //    {
        //    //        Console.WriteLine(u.LoginName);
        //    //    }
        //    //}
            
        //}
    }
}
