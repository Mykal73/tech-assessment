using CSharp.BusinessLayer;
using CSharp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSharp.ServiceLayer
{
    public class ServiceLogic : IService
    {
        private readonly BusinessLogic _businessLogic = new BusinessLogic();
        public bool CancelOrder(int orderID)
        {
            return _businessLogic.CancelOrder(orderID);
        }

        public List<Order> GetOrders()
        {
            return _businessLogic.GetOrders();
        }

        public List<Order> GetOrdersByCustomer(int customerID)
        {
            return _businessLogic.GetOrdersByCustomer(customerID);
        }

        public Order UpdateOrder(string json)
        {
            Order order = JsonSerializer.Deserialize<Order>(json);
            return _businessLogic.UpdateOrder(order);
        }

        public void CreateOrder(string json)
        {
            Order order = JsonSerializer.Deserialize<Order>(json);

            _businessLogic.CreateOrder(order);
        }
    }
}
