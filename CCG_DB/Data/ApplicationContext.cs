using CCG_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace CCG_DB.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Ghoul> Ghouls { get; set; } = null!;
        public DbSet<Investigators> Investigator { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
