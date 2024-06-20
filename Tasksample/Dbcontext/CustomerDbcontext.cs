using Microsoft.EntityFrameworkCore;
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
      


        //public class CustomColumn : Customerdetails
        //{
        //    [Display(Name = "Created On")]
        //    public string CreatedOn { get; set; } = string.Empty;

        //    [Display(Name = "Updated On")]
        //    public string UpdatedOn { get; set; } = string.Empty;

        //    [Display(Name = "Is Deleted On")]
        //    public bool IsDeleted { get; set; }

        //}
    }
  
}
