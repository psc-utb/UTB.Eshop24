using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database.Configuration;

namespace UTB.Eshop.Web.Models.Database.Configuration.MySQL
{
    internal class OrderConfiguration : OrderConfigurationBase
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            //configure default value for DateTimeCreated column which is calculated by MySQL database system
            builder.Property(nameof(Order.DateTimeCreated))
                .HasDefaultValueSql("NOW(6)");
        }
    }
}
