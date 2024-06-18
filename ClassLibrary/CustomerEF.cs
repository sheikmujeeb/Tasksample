using Tasksample.Models;
using Tasksample.CustomerDbcontext;
using ClassLibrary.ICustomer;
using Microsoft.EntityFrameworkCore;



namespace ClassLibrary.Repostry

{

    public class CustomerEF : ICustomerEF
    {

        private readonly CustomerDbContext _context;

        public CustomerEF(CustomerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customerdetails> Show()
        {
            try
            {
                IEnumerable<Customerdetails> Customers = _context.Customers.ToList();
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
                var result = await _context.Customers.AddAsync(customer);
                _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

    }

}
    