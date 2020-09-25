using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharp.Objects
{
    public class Order
    {
        public int orderID { get; set; }
        public string customerID { get; set; }
        public List<Item> items { get; set; }

    }
}
