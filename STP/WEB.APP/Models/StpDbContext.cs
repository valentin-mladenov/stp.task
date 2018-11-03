namespace WEB.APP.Models
{
    using System.Data.Entity;

    public class StpDbContext : DbContext
    {
        public StpDbContext() : base("Name=StpDBConnectionString")
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}