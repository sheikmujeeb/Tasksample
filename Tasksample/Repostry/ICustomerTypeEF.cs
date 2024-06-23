using Tasksample.Models;

namespace Tasksample.Repostry
{
    public interface ICustomerTypeEF
    {
       public IEnumerable<CustomerType> Showall();
    }
}
