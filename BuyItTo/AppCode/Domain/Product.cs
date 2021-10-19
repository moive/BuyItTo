using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.Domain
{
    /// <summary>
    /// We use this class to describe a product that can be sold in the system
    /// </summary>
    public class Product : Aggregate
    {
        public ProductCategory category { get; protected set; }

        public DateTime createDate { get; protected set; }
        public string name { get; protected set; }
        public string description { get; protected set; }
        public decimal price { get; protected set; }
    }
}