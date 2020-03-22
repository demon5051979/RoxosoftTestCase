using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roxosoft.Models
{
    public class OrderProduct
    {
        [Key]
        public long Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
