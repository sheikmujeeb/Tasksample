using Tasksample.Models;

namespace Tasksample.ICustomer
{
    public interface ICustomerEF
    {
        IEnumerable<Customerdetails> Show();
        Task<object> Signup(Customerdetails customer);
    }
}
