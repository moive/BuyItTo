using BuyItTo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo.ViewModels
{
    public class CustomerQueryService
    {
        //private GlobalDbContext _context;
        public CustomerQueryService()
        {
            //_context = context;
        }

        /// <summary>
        /// Retrieve list of customers
        /// </summary>
        /// <returns></returns>
        public List<CustomerListDTO> GetCustomerList()
        {
            using (GlobalDbContext context = new GlobalDbContext())
            {
                return context
                    .Customers()
                    .Select(c => new CustomerListDTO()
                    {
                        ID = c.ID,

                        name = c.name,
                        lastName = c.lastname,

                        phone = c.phone,
                        email = c.email

                    }).ToList();
            }
        }

        /// <summary>
        /// Retrieve customer by ID
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public CustomerDTO GetCustomerByID(int customerID)
        {
            using (GlobalDbContext context = new GlobalDbContext())
            {
                return context
                    .Customers()
                    .Where(c => c.ID == customerID)
                    .Select(c => new CustomerDTO()
                    {
                        ID = c.ID,

                        name = c.name,
                        lastName = c.lastname,

                        address = c.address,
                        invoiceAddress = c.invoiceAddress,
                        shippingAddress = c.shippingAddress,

                        phone = c.phone,
                        email = c.email

                    }).FirstOrDefault();

                }
        }
    }
}