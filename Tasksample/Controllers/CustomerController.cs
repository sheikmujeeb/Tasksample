using Microsoft.AspNetCore.Mvc;
using Tasksample.Models;
using Tasksample.Context;
using Tasksample.ICustomer;
using Tasksample.Customer;
using System.Data.SqlClient;
using PagedList.Mvc;
using PagedList;

namespace Tasksample.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerEF _Customer;
        int pagesize = 5;
        public CustomerController(ICustomerEF customer)
        {
            _Customer = customer;
        }
        // GET: CustomerController1
        public ActionResult Show(int pageno=1)
        {
            var result = _Customer.Show();
            var page = new PagedList<Customerdetails>(result, pageno,pagesize);
            return View("List", page);
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
                sign.CreatedOn= DateTime.Now;
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
               model.UpdatedOn = DateTime.Now;
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
        public ActionResult Deleted(long id)
        {
            try
            {
                
                _Customer.Delete(id);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }
      
    }
}
