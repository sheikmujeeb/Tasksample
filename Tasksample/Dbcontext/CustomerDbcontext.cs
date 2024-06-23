using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tasksample.Customer;
using Tasksample.Models;

namespace Tasksample.Context
{

    public class CustomerDbContext : DbContext
    {
        
        public CustomerDbContext(DbContextOptions <CustomerDbContext> options) : base(options)
        {
        }
        public DbSet<Customerdetails> CustomerEF { get; set; }
      
    }
  
}
