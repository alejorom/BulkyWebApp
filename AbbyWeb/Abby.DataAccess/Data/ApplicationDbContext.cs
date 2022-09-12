using AbbyWeb.Abby.Models;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Abby.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        } 

        public DbSet<Category> Category { get; set; }

    }
}
