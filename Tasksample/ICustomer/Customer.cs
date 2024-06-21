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
                IEnumerable<Customerdetails> Customers = Dbcontext.CustomerEF.Where(p => !p.IsDeleted);
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
        public async Task<Customerdetails> Updatecustomer(Customerdetails model)
        {
            try
            {
                model.UpdatedOn = DateTime.Now;
                Dbcontext.CustomerEF.Update(model);
                Dbcontext.SaveChanges();
                var result = await Dbcontext.CustomerEF.FindAsync(model.Id);
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
                var Customers = Dbcontext.CustomerEF.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
                return Customers;

      
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public void Delete(long id)    
        {
            try
            {
                
                //Dbcontext.CustomerEF.Remove(customer);-----------Soft Delete
              
                var result =  Dbcontext.CustomerEF.Find(id);
                if(result !=null)
                {
                    result.IsDeleted = true;
                    Dbcontext.SaveChanges();
                }
               
           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
