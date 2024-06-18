using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasksample.Models;





namespace Tasksample.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerEF _customerEF;

        public CustomerController(CustomerEF customerEF)
        {
            _customerEF = customerEF;
        }
        // GET: CustomerController1
        public ActionResult Show()
        {
            var result = _customerEF.Show();
            return View("List",result);
        }

        // GET: CustomerController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customerdetails collection)
        {
            try
            {
                var response = _customerEF.Signup(collection);
                if (response != null)
                {

                }
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
