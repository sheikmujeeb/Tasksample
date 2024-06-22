﻿using Microsoft.AspNetCore.Mvc;
using Tasksample.Models;
using PagedList;
using PagedList.Mvc;

namespace Tasksample.ICustomer
{
    public interface ICustomerEF
    {
        IEnumerable<Customerdetails> Show();
        Task<Object> Signup(Customerdetails customer);
        public void Updatecustomer(Customerdetails customer);
        Customerdetails Search(long id);
        public void Delete(long id);
        
    }
}
