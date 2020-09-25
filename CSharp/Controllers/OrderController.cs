using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Objects;
using CSharp.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ServiceLogic _serviceLogic = new ServiceLogic();
        // GET: api/<OrderControllerr>
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _serviceLogic.GetOrders();
        }

        // GET api/<OrderControllerr>/5
        [HttpGet("{id}")]
        public IEnumerable<Order> GetOrdersByCustomer(int id)
        {
           return  _serviceLogic.GetOrdersByCustomer(id);
        }

        // POST api/<OrderControllerr>
        [HttpPost]
        public void CreateNewOrder([FromBody] string value)
        {
            _serviceLogic.CreateOrder( value);
        }

        // PUT api/<OrderControllerr>/5
        [HttpPut("{id}")]
        public void UpdateOrders( [FromBody] string value)
        {
            _serviceLogic.UpdateOrder(value);
        }

        // DELETE api/<OrderControllerr>/5
        [HttpDelete("{id}")]
        public void CancelOrder(int id)
        {
            _serviceLogic.CancelOrder(id);
        }
    }
}
