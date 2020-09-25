using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Objects;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using NuGet.Frameworks;

namespace CSharp.Controllers.Tests
{
    [TestClass()]
    public class OrderControllerTests
    {
        [TestMethod()]
        public void GetOrdersTest()
        {
            OrderController controller = new OrderController();

            List <Order>orders  = controller.GetOrders().ToList();
            Assert.IsTrue(orders.Count == 3);

        }

        [TestMethod()]
        public void GetOrdersByCustomerTest()
        {
            OrderController controller = new OrderController();

            List<Order> orders = controller.GetOrdersByCustomer(1).ToList();

            Assert.IsTrue(orders.Count == 2);
        }



        [TestMethod()]
        public void CreateNewOrderTest()
        {
             Item item1 = new Item
             {
                 itemId = "3",
                 itemDesc = "thingThree",
                 price = 2.00
             };

            List<Item> itemList = new List<Item>();
            itemList.Add(item1);

            Order newOrder = new Order
            {
                orderID = 0,
                customerID = "4",
                items = itemList
            };

            OrderController controller = new OrderController();

            string jsonOrder = JsonSerializer.Serialize(newOrder);

            controller.CreateNewOrder(jsonOrder);

            List<Order> allOrders = controller.GetOrders().ToList();

            Assert.IsTrue(allOrders.Count == 4);


        }

        [TestMethod()]
        public void UpdateOrdersTest()
        {
        
            Item item1 = new Item
            {
                itemId = "1",
                itemDesc = "thingOne",
                price = 1.00
            };

       Item item2 = new Item
            {
                itemId = "2",
                itemDesc = "thingTwo",
                price = 2.00
            };



        List<Item> itemList = new List<Item>();
            itemList.Add(item1);
            itemList.Add(item2);

            Order newOrder = new Order
            {
                orderID = 3,
                customerID = "2",
                items = itemList
            };

            OrderController controller = new OrderController();

            string jsonOrder = JsonSerializer.Serialize(newOrder);
            controller.UpdateOrders(jsonOrder);

            List<Order> updatedOrder = controller.GetOrdersByCustomer(2).ToList();

            Assert.IsTrue(updatedOrder[0].items.Count == 2);


        }

        [TestMethod()]
        public void CancelOrderTest()
        {
            OrderController controller = new OrderController();

            List<Order> orders = controller.GetOrders().ToList();
            int originalCount = orders.Count;

            controller.CancelOrder(1);
            orders = controller.GetOrders().ToList();
            int newCount = orders.Count;

            Assert.IsTrue(originalCount -1 == newCount);
        }
    }
}