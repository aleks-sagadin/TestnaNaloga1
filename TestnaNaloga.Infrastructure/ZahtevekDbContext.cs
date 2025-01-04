using Microsoft.EntityFrameworkCore;
using TestnaNaloga.Domain;

namespace TestnaNaloga.Infrastructure
{
    public class ZahtevekDbContext : DbContext
    {
        public ZahtevekDbContext(DbContextOptions<ZahtevekDbContext> options) : base(options)
        {

        }

        public DbSet<Zahtevek> Zahteveks { get; set; }
    }
}
