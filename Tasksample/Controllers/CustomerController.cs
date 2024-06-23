using Microsoft.AspNetCore.Mvc;
using Tasksample.Models;
using Tasksample.Context;
using Tasksample.ICustomer;
using Tasksample.Customer;
using System.Data.SqlClient;
using PagedList;
using PagedList.Mvc;
using Tasksample.Repostry;


namespace Tasksample.Controllers
{
    public class CustomerController : Controller
    {
         ICustomerEF Customer;
         ICustomerTypeEF value;
        
        public CustomerController(ICustomerEF _customer,ICustomerTypeEF obj)
        {
            Customer = _customer;
            value = obj;
        }
        // GET: CustomerController1
        public ActionResult Show()
        {
            var value = Customer.Show();
            return View("List", value);
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
            var result = value.Showall();
            var entity = new Customerdetails();
            entity.Optiontypes = result;
            return View("Create", entity);
            
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
