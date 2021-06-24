using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MsSqlToPostgress.EntityConfigurations.MS
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Status)
                .HasConversion<int>();

            builder.HasOne(e => e.Location)
                .WithMany(l => l.Orders)
                .HasForeignKey(e => e.LocationId);

            builder.HasOne(e => e.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(u => u.UserId);

            builder.HasMany(e => e.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);
        }
    }
}