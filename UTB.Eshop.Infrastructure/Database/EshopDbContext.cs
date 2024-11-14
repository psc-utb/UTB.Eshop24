using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UTB.Eshop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using UTB.Eshop.Web.Models.Database.Configuration.MySQL;

namespace UTB.Eshop.Infrastructure.Database
{
    public class EshopDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

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


            //Identity - User and Role initialization
            //roles must be added first
            RolesInit rolesInit = new RolesInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAMC());

            //then, create users ..
            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User manager = userInit.GetManager();

            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, manager);

            //and finally, connect the users with the roles
            UserRolesInit userRolesInit = new UserRolesInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> managerUserRoles = userRolesInit.GetRolesForManager();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);



            //configure DateTimeCreated and User for Order entity using configuration class
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
            ////alternative for direct configuration of User entity using IUser interface property of Order entity (this configuration is included in OrderConfigurationBase class)
            //modelBuilder.Entity<Order>().HasOne<User>(e => e.User as User);
        }
    }
}
