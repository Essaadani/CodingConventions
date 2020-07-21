using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFBestPractices.Models
{
    [NotMapped]
    public partial class Customers
    {



        public Customers()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Orders>();
        }

        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }


        [NotMapped]
        public string PostalCode { get; set; }



        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext(string connectionString) 
            : base(GetOptions(connectionString))
        { }
        private static DbContextOptions GetOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            return optionsBuilder.UseSqlServer(connectionString).Options;
        }
    }
}
