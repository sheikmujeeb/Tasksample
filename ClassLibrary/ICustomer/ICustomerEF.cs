using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasksample.Models;


namespace ClassLibrary.ICustomer
{
    
        public interface ICustomerEF
        {
            IEnumerable<Customerdetails> Show();
            Task<object> Signup(Customerdetails customer);
        }
    
}
