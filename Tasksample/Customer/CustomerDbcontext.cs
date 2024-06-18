using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Diagnostics.Contracts;
using Tasksample.Models;

namespace Tasksample.CustomerDbcontext
{

    public class CustomerDbContext : DbContext
    {
        
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customerdetails> Customers { get; set; }

    }
}
