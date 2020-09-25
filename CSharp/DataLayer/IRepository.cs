using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Objects;
namespace CSharp.DataLayer
{
    interface IRepository
    {
        List<Order> GetOrders();

        List<Order> GetOrdersByCustomer(int customerID);

        Order UpdateOrder(Order order);

        Boolean CancelOrder(int orderID);

        void CreateOrder(Order order);
    }
}
