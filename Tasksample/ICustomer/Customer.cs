using Tasksample.CustomerDbContext;
using Tasksample.Models;
using Tasksample.ICustomer;
using Microsoft.EntityFrameworkCore;

namespace Tasksample.ICustomer
{
        public class CustomerEF : ICustomerEF
        {

            private readonly CustomerDbContext _context;

            public CustomerEF(CustomerDbContext customercontext)
            {
                _context = customercontext;
            }

            public IEnumerable<Customerdetails> Show()
            {
                try
                {
                    IEnumerable<Customerdetails> Customers = _context.CustomerEF.ToList();
                    return Customers;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }

            }

            public async Task<object> Signup(Customerdetails customer)
            {
                try
                {
                    var result = await _context.CustomerEF.AddAsync(customer);
                    _context.SaveChanges();
                    return (result);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }

            }

        }

}
