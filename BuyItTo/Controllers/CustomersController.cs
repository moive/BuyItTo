using BuyItTo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuyItTo.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerQueryService _queryService;

        public CustomersController()
        {
            _queryService = new CustomerQueryService();
        }

        // GET: Customers
        public ActionResult Index()
        {
            CustomerListViewModel model = new CustomerListViewModel()
            {
                Customers = _queryService.GetCustomerList()
            };

            return View();
        }
    }
}