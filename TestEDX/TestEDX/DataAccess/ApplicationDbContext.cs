using Microsoft.EntityFrameworkCore;
using TestEDX.Models;

namespace TestEDX.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Personas> Personas { get; set; }
    }
}
