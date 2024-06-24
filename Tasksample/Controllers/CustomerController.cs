using Microsoft.AspNetCore.Mvc;
using Tasksample.Models;
using Tasksample.Context;
using Tasksample.ICustomer;
using Tasksample.Customer;
using System.Data.SqlClient;
using PagedList;
using PagedList.Mvc;
using System.Configuration;


namespace Tasksample.Controllers
{
    public class CustomerController : Controller
    {
         ICustomerEF Customer;
        
        public CustomerController(ICustomerEF _customer)
        {
            Customer = _customer;
        }
        // GET: CustomerController1
        public async Task<IActionResult> Show(int PageNumber)
        {
            try
            {
                var value = Customer.Show();
                ViewBag.response = value.Count();


                if (PageNumber < 1)
                {
                    PageNumber = 1;
                }
                int PageSize = 5;
                IQueryable<Customerdetails> result = value!.AsQueryable<Customerdetails>();
                var showall = PageModel<Customerdetails>.CreateAsync(value, PageNumber, PageSize);
                return View("List", showall.Items);
            }
            catch
            {
                return View("List");
            }
        }


        // GET: CustomerController1/Details/5
        public ActionResult Details(int id)
        {

            var Result = Customer.Search(id);
            return View("Details", Result);
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
           // var result = value.Showall();
            //var entity = new Customerdetails();
            //entity.Optiontypes = result;
            return View("Create");
            
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customerdetails sign)
        {
            try
            {
                sign.CreatedOn= DateTime.Now;
                var result= Customer.Signup(sign);
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
            var find = Customer.Search(id);
            return View ("Edit",find);
           
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customerdetails model)
        {
            try
            {

                Customer.Updatecustomer(model);
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
            var result= Customer.Search(id);
            return View("Delete",result);
        }

        // POST: CustomerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deleted(long id)
        {
            try
            {

                Customer.Delete(id);
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }
       
    }
}
