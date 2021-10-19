using BuyItTo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuyItTo.DB
{
    /// <summary>
    /// Main DB Context for database interaction
    /// </summary>
    public class GlobalDbContext : DbContext
    {

        public GlobalDbContext() : base("buyittoDB")
        {
            Database.SetInitializer<GlobalDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Add entity model mappings
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMapping());

            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderDetailMapping());

            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new ProductCategoryMapping());
        }

        /// <summary>
        /// Add new element to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theElement"></param>
        public void Add<T>(T theElement) where T : Aggregate
        {
            this.Set<T>().Add(theElement);
        }

        /// <summary>
        /// Delete element from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theElement"></param>
        public void Remove<T>(T theElement) where T : Aggregate
        {
            this.Set<T>().Remove(theElement);
        }

        /// <summary>
        /// Access to customers table
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<Customer> Customers(bool trackChanges = false)
        {
            return trackChanges == false ? this.Set<Customer>().AsNoTracking() : this.Set<Customer>();
        }

        /// <summary>
        /// Access to orders table
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<Order> Orders(bool trackChanges = false)
        {
            return trackChanges == false ? this.Set<Order>().AsNoTracking() : this.Set<Order>();
        }

        /// <summary>
        /// Access to products table
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<Product> Products(bool trackChanges = false)
        {
            return trackChanges == false ? this.Set<Product>().AsNoTracking() : this.Set<Product>();
        }

        /// <summary>
        /// Access to product category table
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<ProductCategory> ProductCategories(bool trackChanges = false)
        {
            return trackChanges == false ? this.Set<ProductCategory>().AsNoTracking() : this.Set<ProductCategory>();
        }
    }
}