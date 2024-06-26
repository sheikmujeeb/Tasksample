﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tasksample.Customer;
using Tasksample.Models;

namespace Tasksample.Context
{

    public class CustomerDbContext : DbContext
    {
        
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customerdetails> CustomerEF { get; set; }
        public DbSet<CustomerType> CustomerTypeEF { get; set; }

    }
  
}
