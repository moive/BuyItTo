using BuyItTo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BuyItTo.DB
{
    /// <summary>
    /// Configure order mappings to database
    /// </summary>
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            this.HasKey(c => c.ID);

            this.Property(c => c.createDate).IsRequired();

            //order - customer
            this.HasRequired(c => c.customer).WithMany().Map(m => m.MapKey("customerID"));

            //order detail
            this.HasMany(c => c.detail).WithRequired(oc => oc.order).Map(m => m.MapKey("orderID"));

            this.ToTable("orders");
        }
    }

    /// <summary>
    /// Configure order detail mapping to database
    /// </summary>
    public sealed class OrderDetailMapping : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapping()
        {
            this.HasKey(c => c.ID);

            this.Property(c => c.quantity).IsRequired();
            this.Property(c => c.price).HasPrecision(10, 2).IsRequired();

            //order detail - product
            this.HasRequired(c => c.product).WithMany().Map(m => m.MapKey("productID"));

            this.ToTable("orders_detail");
        }
    }
}