using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.Domain
{
    /// <summary>
    /// We use this class to describe a product category
    /// </summary>
    public class ProductCategory : Aggregate
    {
        public string name { get; protected set; }
    }
}