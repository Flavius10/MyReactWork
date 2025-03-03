using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class RezultateDbContext : DbContext
    {
        public RezultateDbContext(DbContextOptions<RezultateDbContext> options) : base(options)
        {
            
        }

        public DbSet<Rezultate> Rezultat { get; set;}
    }
}
