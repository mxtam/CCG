using Microsoft.EntityFrameworkCore;

namespace CCG_DB.Models
{
    public class ApplicationContext: DbContext
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
