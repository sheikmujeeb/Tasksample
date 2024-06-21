using Tasksample.Models;

namespace Tasksample.ICustomer
{
    public interface ICustomerEF
    {
        IEnumerable<Customerdetails> Show();
        Task<Object> Signup(Customerdetails customer);
        Task<Customerdetails> Updatecustomer(Customerdetails customer);
        Customerdetails Search(long id);
        public void Delete(long id);
    }
}
