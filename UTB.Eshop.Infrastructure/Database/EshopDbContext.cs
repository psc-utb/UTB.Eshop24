using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database.Seeding;

namespace UTB.Eshop.Infrastructure.Database
{
    public class EshopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Carousel> Carousels { get; set; }

        public EshopDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
