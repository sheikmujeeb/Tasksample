using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using Tasksample.Models;
using PagedList;
using PagedList.Mvc;

namespace Tasksample.ICustomer
{
    public interface ICustomerEF
    {
        IEnumerable<Customerdetails> Show();
        Task<Object> Signup(Customerdetails customer);
        public void Updatecustomer(Customerdetails customer);
        Customerdetails Search(long id);
        public void Delete(long id);
        public IActionResult Index(int page = 1, int pageSize = 10);

    }
}
