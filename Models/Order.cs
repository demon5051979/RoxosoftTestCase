using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roxosoft.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Agent Agent { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } 

    }
}
