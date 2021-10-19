using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.Domain
{
    /// <summary>
    /// This class is used to store an order from a customer
    /// </summary>
    public class Order : Aggregate
    {
        public DateTime createDate { get; protected set; }
        public Customer customer { get; protected set; }

        public List<OrderDetail> detail { get; protected set; }
    }
}