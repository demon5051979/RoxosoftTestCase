using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Roxosoft.Models
{
    public class OrdersContext : DbContext
    {
        static OrdersContext()
        {
            Database.SetInitializer<OrdersContext>(new OrderContextInitializer());
        }

        public OrdersContext()
            : base("DbConnection")
        { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
