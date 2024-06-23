using Tasksample.Context;
using Tasksample.Models;
using System.Data.SqlClient;
using Tasksample.Dbcontext;
namespace Tasksample.Repostry
{

    public class CustomerTypeEF:ICustomerTypeEF
    {
        private readonly CustomertypeDbcontext Dbcontext;

        public CustomerTypeEF(CustomertypeDbcontext context)
        {
            Dbcontext = context;
        }
        public IEnumerable<CustomerType> Showall()
        {
            try
            {
                IEnumerable<CustomerType> Customers = Dbcontext.CustomerTypeEF.Where(p => !p.IsDeleted);
                return Customers;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
