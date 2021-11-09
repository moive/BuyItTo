using BuyItTo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            return View("CustomerList", model);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View("Customer", new CustomerDTO());
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,lastname,address,invoiceAddress,shippingAddress,phone,email")] CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerDTO customerDTO = _queryService.GetCustomerByID(id.Value);
            if (customerDTO == null)
            {
                return HttpNotFound();
            }

            return View("Customer", customerDTO);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,lastname,address,invoiceAddress,shippingAddress,phone,email")] CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerDTO customerDTO = _queryService.GetCustomerByID(id.Value);

            if (customerDTO == null)
            {
                return HttpNotFound();
            }

            return View("Delete", customerDTO);
        }

        //POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }
    }
}