using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Objects;

namespace CSharp.ServiceLayer
{
    interface IService
    {
        List<Order> GetOrders();

        List<Order> GetOrdersByCustomer(int customerID);

        Order UpdateOrder(string value);

        Boolean CancelOrder(int orderID);

        void CreateOrder(string value);
    }
}
