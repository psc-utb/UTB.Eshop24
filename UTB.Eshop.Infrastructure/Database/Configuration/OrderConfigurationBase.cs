using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity;

namespace UTB.Eshop.Infrastructure.Database.Configuration
{
    internal class OrderConfigurationBase :  IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //configuration of User entity using IUser interface property inside Order entity
            builder.HasOne<User>(e => e.User as User);
        }
    }
}
