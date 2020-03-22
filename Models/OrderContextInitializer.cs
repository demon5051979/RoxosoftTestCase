using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Roxosoft.Models
{
    public class OrderContextInitializer : DropCreateDatabaseAlways<OrdersContext>
    {
        protected override void Seed(OrdersContext db)
        {
            Agent agent1 = new Agent() { Id = 1, Name = "Иванов Иван" };
            db.Agents.Add(agent1);

            Agent agent2 = new Agent() { Id = 2, Name = "Петров Петр" };
            db.Agents.Add(agent2);

            db.Agents.Add(new Agent() { Id = 3, Name = "Тестовый Тестефаний" });
            db.SaveChanges();

            var status1 = new OrderStatus() { Id = 1, Name = "InProgress" };
            var status2 = new OrderStatus() { Id = 2, Name = "Complete" };
            db.OrderStatuses.Add(status1);
            db.OrderStatuses.Add(status2);
            db.SaveChanges();

            Product product1 = new Product() { Id = 1, Name = "Маска N95" };
            Product product2 = new Product() { Id = 2, Name = "Противогаз Г-5" };
            Product product3 = new Product() { Id = 3, Name = "Гречка рассыпная" };
            Product product4 = new Product() { Id = 4, Name = "Рис отборный" };
            Product product5 = new Product() { Id = 5, Name = "Говядина тушеная" };

            db.Products.Add(product1);
            db.Products.Add(product2);
            db.Products.Add(product3);
            db.Products.Add(product4);
            db.Products.Add(product5);
            db.SaveChanges();

            Order order1 = new Order() { Id = 1, Agent = agent1, Status = status1, CreateDate = DateTime.Now.AddDays(-1) };

            order1.OrderProducts = new List<OrderProduct>();

            order1.OrderProducts.Add(new OrderProduct() { Id = 1, Order = order1, Product = product1, Price = 100, Quantity = 10, Amount = 1000 });
            order1.OrderProducts.Add(new OrderProduct() { Id = 2, Order = order1, Product = product2, Price = 200, Quantity = 2, Amount = 400 });
            order1.OrderProducts.Add(new OrderProduct() { Id = 3, Order = order1, Product = product3, Price = 300, Quantity = 5, Amount = 1500 });

            db.Orders.Add(order1);
            db.SaveChanges();

            Order order2 = new Order() { Id = 2, Agent = agent2, Status = status2, CreateDate = DateTime.Now };

            order2.OrderProducts = new List<OrderProduct>();

            order2.OrderProducts.Add(new OrderProduct() { Id = 4, Order = order2, Product = product4, Price = 50, Quantity = 10, Amount = 500 });
            order2.OrderProducts.Add(new OrderProduct() { Id = 5, Order = order2, Product = product5, Price = 20, Quantity = 2, Amount = 40 });
            order2.OrderProducts.Add(new OrderProduct() { Id = 6, Order = order2, Product = product1, Price = 100, Quantity = 5, Amount = 500 });
            order2.OrderProducts.Add(new OrderProduct() { Id = 7, Order = order2, Product = product2, Price = 200, Quantity = 3, Amount = 600 });
            order2.OrderProducts.Add(new OrderProduct() { Id = 8, Order = order2, Product = product3, Price = 300, Quantity = 1, Amount = 300 });

            db.Orders.Add(order2);
            db.SaveChanges();
        }
    }
}
