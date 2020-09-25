using CSharp.Objects;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.DataLayer
{
    public class MockRepo : IRepository
    {
        private List<Order> orderList = new List<Order>
            {
                MockedValues.order1,
                MockedValues.order2,
                MockedValues.order3

            };

        public bool CancelOrder(int orderID)
        {
            bool retVal = true;
            try
            {
                orderList = orderList.Where(o => o.orderID != orderID).ToList();

            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                retVal = false;
            }
            return retVal;
        }

        public void CreateOrder(Order order)
        {
            orderList.Add(order);
        }

        public List<Order> GetOrders()
        {
           return orderList;
        }

        public List<Order> GetOrdersByCustomer(int customerID)
        {
            List<Order> orders = GetOrders();

            return orders.Where(o => o.customerID == customerID.ToString()).ToList();
        }

        public Order UpdateOrder(Order order)
        {
            List<Order> orders = GetOrders();

            List<Order> existingOrder = orders.Where(o => o.orderID != order.orderID).ToList();
            existingOrder.Add(order);
            orderList = existingOrder;
            return order;
        }

    }

    public class MockedValues
    {
        public static Item item1 = new Item
        {
            itemId = "1",
            itemDesc = "thingOne",
            price = 1.00
        };

        public static Item item2 = new Item
        {
            itemId = "2",
            itemDesc = "thingTwo",
            price = 2.00
        };

        public static Item item3 = new Item
        {
            itemId = "3",
            itemDesc = "thingThree",
            price = 2.00
        };

        public static Order order1 = new Order
        {
            orderID =1,
            customerID = "1",
            items = new List<Item>
            {
                item1,
                item2
            }
        };

        public static Order order2 = new Order
        {
            orderID = 2,
            customerID = "1",
            items = new List<Item>
            {
                item3,
                item1
            }
        };

        public static Order order3 = new Order
        {
            orderID = 3,
            customerID = "2",
            items = new List<Item>
            {
                item2
            }
        };
    }
}
