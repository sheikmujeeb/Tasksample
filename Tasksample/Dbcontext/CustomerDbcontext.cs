using Microsoft.EntityFrameworkCore;
using Tasksample.Models;

namespace Tasksample.Context
{

    public class CustomerDbContext : DbContext
    {
        
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customerdetails> CustomerEF { get; set; }

    }
}
