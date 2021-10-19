using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.Domain
{
    /// <summary>
    /// The unique identifier for the aggregate
    /// </summary>
    public class Aggregate
    {
        public int ID { get; protected set; }

        /// <summary>
        /// Constructor for EF
        /// </summary>
        protected Aggregate() { }
    }
}