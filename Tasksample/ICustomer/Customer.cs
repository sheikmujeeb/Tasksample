using Tasksample.Context;
using Tasksample.Models;
using Tasksample.ICustomer;
using Microsoft.EntityFrameworkCore;

namespace Tasksample.Customer
{
    public class CustomerEF : ICustomerEF
    {

        private readonly CustomerDbContext Dbcontext;

        public CustomerEF(CustomerDbContext context)
        {
            Dbcontext = context;
        }

        public IEnumerable<Customerdetails> Show()
        {
            try
            {
                IEnumerable<Customerdetails> Customers = Dbcontext.CustomerEF.ToList();
                return Customers;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<Object> Signup(Customerdetails customer)
        {
            try
            {
                var result = await Dbcontext.CustomerEF.AddAsync(customer);
                Dbcontext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public async Task<Customerdetails> Updatecustomer(Customerdetails customer)
        {
            try
            {
                Dbcontext.CustomerEF.Update(customer);
                Dbcontext.SaveChanges();
                var result = await Dbcontext.CustomerEF.FindAsync(customer.Id);
                return result!;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Customerdetails Search(long id)
        {
            try
            {
                Customerdetails Customers = Dbcontext.CustomerEF.FirstOrDefault(x => x.Id == id);
                return Customers;

      
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public async Task<Customerdetails>Delete(Customerdetails customer)    
        {
            try
            {
                
                Dbcontext.CustomerEF.Remove(customer);
                Dbcontext.SaveChanges();
                var result = await Dbcontext.CustomerEF.FindAsync(customer.Id);
                return result;
           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
