using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.ViewModels
{
    public class CustomerListDTO
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }

        public string phone { get; set; }
        public string email { get; set; }
    }
}