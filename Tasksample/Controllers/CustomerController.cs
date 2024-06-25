using Microsoft.AspNetCore.Mvc;
using Tasksample.Models;
using Tasksample.Context;
using Tasksample.ICustomer;
using Tasksample.Customer;
using System.Data.SqlClient;
using PagedList;
using PagedList.Mvc;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Tasksample.Controllers
{
    public class CustomerController : Controller
    {
         ICustomerEF Customer;
        CustomerDbContext Type;
        public CustomerController(ICustomerEF _customer, CustomerDbContext type)
        {
            Customer = _customer;
            Type = type;
        }
        // GET: CustomerController1
        public IActionResult List(int? PageNumber)
        {
            try
            {
                int totalcount = Type.CustomerEF.Count();
                int PageNumbers= PageNumber??1;
                int pageSize = 5;
                var item= Type.CustomerEF.ToList().Skip((PageNumbers-1)*pageSize).Take(pageSize);
                var pageList = PageModel<Customerdetails>.Create(item.ToList(), PageNumbers, pageSize, totalcount);

                return View (pageList);
               
            }
            catch
            {
                return View();
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
            var result = Type.CustomerTypeEF.ToList();
            ViewBag.CustomerType = new SelectList(result, "CustomerTypeId", "CustomerTypeDescription");
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
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
       
    }
}
