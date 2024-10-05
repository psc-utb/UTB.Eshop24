using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UTB.Eshop.Infrastructure.Identity;

namespace UTB.Eshop.Infrastructure.Database
{
    public class EshopDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Carousel> Carousels { get; set; }

        public EshopDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ProductInit productInit = new ProductInit();
            modelBuilder.Entity<Product>().HasData(productInit.GetProductsFood3());
            CarouselInit carouselInit = new CarouselInit();
            modelBuilder.Entity<Carousel>().HasData(carouselInit.GetCarouselsIT3());
        }
    }
}
