using Tasksample.Context;
using Tasksample.Models;
using Tasksample.ICustomer;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNetCore.Mvc;

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
                IEnumerable<Customerdetails> Customers = Dbcontext.CustomerEF.Where(p => !p.IsDeleted).ToList();
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
        public void Updatecustomer(Customerdetails model)
        {
            try
            {
                var existingCustomer = Dbcontext.CustomerEF.Find(model.Id);

                if (existingCustomer != null)
                {
                    existingCustomer.FullName = model.FullName;
                    existingCustomer.CustomerType = model.CustomerType;
                    existingCustomer.PhoneNumber = model.PhoneNumber;
                    existingCustomer.DateOfBirth = model.DateOfBirth;
                    existingCustomer.Email = model.Email;
                    existingCustomer.Gender = model.Gender;
                    existingCustomer.Country = model.Country;
                    existingCustomer.IsActive = model.IsActive;
                    existingCustomer.Remarks = model.Remarks;
                    existingCustomer.UpdatedOn = DateTime.Now;
                    Dbcontext.SaveChanges();
                }
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
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            throw new NotImplementedException();
        }
    }
}
