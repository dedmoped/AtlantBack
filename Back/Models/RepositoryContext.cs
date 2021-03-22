using Microsoft.EntityFrameworkCore;

namespace Back.Models
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Details> Details { get; set; }
        public DbSet<StoreKeeper> Storekeeper { get; set; }
    }
}
