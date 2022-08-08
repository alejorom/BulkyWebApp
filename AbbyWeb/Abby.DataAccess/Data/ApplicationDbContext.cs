using AbbyWeb.Abby.Models;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Abby.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }

    }
}
