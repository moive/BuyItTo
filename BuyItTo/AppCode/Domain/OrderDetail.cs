using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.Domain
{
    public class OrderDetail : Aggregate
    {
        public Order order { get; protected set; }
        public Product product { get; protected set; }
        public int quantity { get; protected set; }
        public decimal price { get; protected set; }
    }
}