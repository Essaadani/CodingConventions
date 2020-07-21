using EFBestPractices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace EFBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FilterOnServer
            // Before

            //using (NorthwindContext context = new NorthwindContext())
            //{
            //    var customers = from customer in context.Customers
            //                    select customer;

            //    int count = 0;
            //    foreach (var customer in customers)
            //    {
            //        if (customer.Country == "Germany")
            //        {
            //            Console.WriteLine(customer.ContactName);
            //            count++;
            //        }
            //    }

            //    Console.WriteLine($"Records count: {count}");
            //    Console.ReadKey();
            //}


            // After (Filter on Server)
            //using (NorthwindContext context = new NorthwindContext())
            //{
            //    var customers = from customer in context.Customers
            //                    where customer.Country.Equals("Germany")
            //                    select customer;

            //    foreach (var customer in customers)
            //    {
            //        Console.WriteLine(customer.ContactName);
            //    }

            //    Console.ReadKey();
            //}
            #endregion

            #region UseProjection
            //using (NorthwindContext context = new NorthwindContext())
            //{
            //    // Without Projection
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    var customers = from customer in context.Customers
            //                    select customer;

            //    foreach (var customer in customers)
            //    {
            //        Console.WriteLine(customer.ContactName);
            //    }

            //    stopwatch.Stop();
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("Before projection: " + stopwatch.ElapsedMilliseconds);
            //    Console.ForegroundColor = ConsoleColor.White;

            //    // Using Projection
            //    stopwatch.Restart();
            //    var customerNames = from customer in context.Customers
            //                    select new { customer.ContactName};

            //    foreach (var customer in customerNames)
            //    {
            //        Console.WriteLine(customer.ContactName);
            //    }

            //    stopwatch.Stop();
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("After projection: " + stopwatch.ElapsedMilliseconds);

            //    Console.ReadKey();
            //}

            #endregion

            #region UseEagerLoading

            //using (NorthwindContext context = new NorthwindContext())
            //{
            //    var customers =
            //        context.Customers
            //        .Include(x => x.Orders)
            //        .ThenInclude(y => y.OrderDetails);

            //    foreach (var customer in customers)
            //    {
            //        Console.WriteLine($"Customer Name: {customer.ContactName}");
            //        Console.WriteLine("-----------------------------");
            //        foreach (var order in customer.Orders)
            //        {
            //            Console.WriteLine($"\tOrder Date: {order.OrderDate}");
            //            Console.WriteLine("\t-----------------------------");
            //            foreach (var detail in order.OrderDetails)
            //            {
            //                Console.WriteLine($"\t\tProduct Id: {detail.ProductId}");
            //            }
            //        }
            //    }
            //    Console.ReadKey();
            //}


            #endregion

            #region TrackEntities
            //using (NorthwindContext context = new NorthwindContext())
            //{

            //    var customers =
            //        context.Customers
            //        .Where(x => x.ContactName.StartsWith("A"));

            //    Console.WriteLine($"Customers count: {customers.Count()}");

            //    foreach (var customer in customers)
            //    {
            //        customer.Country = "Morocco";
            //    }

            //    var modifiedCustomers =
            //        context.ChangeTracker
            //        .Entries<Customers>()
            //        .Where(x => x.State == EntityState.Modified)
            //        .Select(x => x.Entity);

            //    Console.WriteLine($"Modified customers count: {modifiedCustomers.Count()}");

            //    Console.ReadKey();
            //}
            #endregion


        }


    }
}
