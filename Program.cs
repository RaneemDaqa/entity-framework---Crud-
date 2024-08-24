using Microsoft.EntityFrameworkCore;
using session3.Data;
using session3.Models;

namespace session3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            // insert
            Product product1 = new Product () {Name = "Product1",Price =10};
            Product product2 = new Product() { Name = "Product2", Price = 20 };
            Product product3 = new Product() { Name = "Product3", Price =30 };
            dbContext.Products.AddRange(product1,product2,product3);
            dbContext.SaveChanges();

            Order order1 = new Order {Address = "Main St1",CreatedAt = DateTime.Today };
            Order order2 = new Order { Address = "Main St2", CreatedAt = DateTime.Today };
            Order order3 = new Order { Address = "Main St3", CreatedAt = DateTime.Today };
            dbContext.Orders.AddRange(order1, order2, order3);
            dbContext.SaveChanges();
           
           
            //selsect
            var products = dbContext.Products.ToList();
            Console.WriteLine("Products:");
            foreach (var P in products)
            {
                Console.WriteLine($"Id: {P.Id}, Name: {P.Name}, Price: {P.Price}");
            }

            // Get all orders
            var orders = dbContext.Orders.ToList();
            Console.WriteLine("\nOrders:");
            foreach (var O in orders)
            {
                Console.WriteLine($"Id: {O.Id}, Address: {O.Address}, Created At: {O.CreatedAt}");
            }

          
            //update
            var product4 = dbContext.Products.First(P => P.Id == 1);
            product4.Name = "Product99";
            dbContext.SaveChanges();
            Console.WriteLine($"\n\nProducts After update:");
            foreach (var P in products)
            {
                Console.WriteLine($"Id: {P.Id}, Name: {P.Name}, Price: {P.Price}");
            }

            var order4 = dbContext.Orders.First(O => O.Id == 1);
            order4.CreatedAt =  DateTime.Now;
            dbContext.SaveChanges();
            Console.WriteLine("\nOrders After update:");
            foreach (var O in orders)
            {
                Console.WriteLine($"Id: {O.Id}, Address: {O.Address}, Created At: {O.CreatedAt}");
            }


            // Remove 
            var removeProduct = dbContext.Products.First(p => p.Id == 2);
            dbContext.Products.Remove(removeProduct);
            dbContext.SaveChanges();
            var product5 = dbContext.Products.ToList();
            Console.WriteLine($"\n\nProducts After remove:");
            foreach (var P in product5)
            {
                Console.WriteLine($"Id: {P.Id}, Name: {P.Name}, Price: {P.Price}");
            }


            var removeOrder = dbContext.Orders.First(o => o.Id == 3);
            dbContext.Orders.Remove(removeOrder);
            dbContext.SaveChanges();
            var orders5 = dbContext.Orders.ToList();
            Console.WriteLine("\nOrders After remove:");
            foreach (var O in orders5)
            {
                Console.WriteLine($"Id: {O.Id}, Address: {O.Address}, Created At: {O.CreatedAt}");
            }

            Console.WriteLine("Done");

        }
    }
}
