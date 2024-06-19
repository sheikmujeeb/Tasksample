using Microsoft.AspNetCore.Mvc;
using Tasksample.Models;
using Tasksample.Context;
using Tasksample.ICustomer;
using Tasksample.Customer;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Tasksample.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerEF _Customer;

        public CustomerController(ICustomerEF customer)
        {
            _Customer = customer;
        }
        // GET: CustomerController1
        public ActionResult Show()
        {
            var result = _Customer.Show();
            return View("List",result);
        }

        // GET: CustomerController1/Details/5
        public ActionResult Details(int id)
        {

            var Result = _Customer.Search(id);
            return View("Details", Result);
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customerdetails sign)
        {
            try
            {
                var result= _Customer.Signup(sign);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }   

        // GET: CustomerController1/Edit/5
        public ActionResult Update(long id)
        {
            var find = _Customer.Search(id);
            return View ("Edit",find);
           
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customerdetails model)
        {
            try
            {
                var response = _Customer.Updatecustomer(model);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Delete/5
        public ActionResult Delete(long id)
        {
            var result=_Customer.Search(id);
            return View("Delete",result);
        }

        // POST: CustomerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, Customerdetails record)
        {
            try
            {
                var response = _Customer.Delete(record);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }
    }
}
