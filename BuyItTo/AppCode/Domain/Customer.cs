using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.Domain
{
    public class Customer : Aggregate
    {
        public string name { get; set; }
        public string lastname { get; set; }

        public string address { get; set; }
        public string invoiceAddress { get; set; }
        public string shippingAddress { get; set; }

        public string phone { get; set; }
        public string email { get; set; }
    }
}