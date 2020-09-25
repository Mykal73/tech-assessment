using CSharp.DataLayer;
using CSharp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.BusinessLayer
{
    public class BusinessLogic : IBusiness
    {
        private readonly MockRepo _repo = new MockRepo();
        public bool CancelOrder(int orderID)
        {
           return _repo.CancelOrder(orderID);
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }

        public List<Order> GetOrdersByCustomer(int customerID)
        {
            return _repo.GetOrdersByCustomer(customerID);
        }

        public Order UpdateOrder(Order order)
        {
            return _repo.UpdateOrder(order);
        }

        public void CreateOrder(Order order)
        {

            if(order.orderID == 0)
            {
                List<Order> allOrders = GetOrders();
                Order lastOrder = allOrders.Aggregate((o1, o2) => (int)o1.orderID > (int)o2.orderID ? o1 : o2);
                order.orderID = lastOrder.orderID + 1;
                
            }
            _repo.CreateOrder(order);
        }
    }
}
