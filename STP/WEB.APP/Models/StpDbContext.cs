namespace WEB.APP.Models
{
    using System.Data.Entity;

    public class StpDbContext : DbContext
    {
        public StpDbContext() : base("Name=StpDBConnectionString")
        {

        }

        public virtual IDbSet<Company> Companies { get; set; }
        public virtual IDbSet<Employee> Employees { get; set; }
    }
}