using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roxosoft.Models;

namespace Roxosoft.Controllers
{
    [ApiController]
    [Route("Orders")]
    public class OrdersController : Controller
    {       
        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                using (OrdersContext db = new OrdersContext())
                {
                    var result = db.Orders.Select(o => new
                    {
                        o.Id,
                        o.CreateDate,
                        AgentName = o.Agent.Name,
                        StatusId = o.Status.Id,
                        Status = o.Status.Name
                    }).ToList();

                    return Json(result); ;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }


        [HttpGet]
        [Route("GetOrderProducts/{id}")]
        public IActionResult GetOrderProducts(long id)
        {  
            try
            {
                using (OrdersContext db = new OrdersContext())
                {
                    var result = db.OrderProducts.Where(p => p.Order.Id == id)
                        .Select(p => new
                        {
                            OrderId = p.Order.Id,
                            ProductId = p.Product.Id,
                            ProductName = p.Product.Name,
                            p.Price,
                            p.Quantity,
                            p.Amount
                        }).ToList();
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
