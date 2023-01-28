using Invenroty.Models;
using Microsoft.EntityFrameworkCore;

namespace Invenroty.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
