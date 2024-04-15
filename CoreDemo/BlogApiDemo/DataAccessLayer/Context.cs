using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-T3S2886\\SQLEXPRESS;database=CoreBlogApiDb; integrated security=true;TrustServercertificate=true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
