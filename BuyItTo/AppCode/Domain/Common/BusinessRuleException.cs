using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo
{
    public sealed class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message)
        {

        }
    }
}