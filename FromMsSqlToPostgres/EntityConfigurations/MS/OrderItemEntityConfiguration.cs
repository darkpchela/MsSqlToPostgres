using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MsSqlToPostgress.EntityConfigurations.MS
{
    internal class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CupSize)
                .HasConversion<int>();

            builder.Property(e => e.Creamer)
                .HasConversion<int>();

            builder.Property(e => e.Temperature)
                .HasConversion<int>();

            builder.HasOne(e => e.MenuItem)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(e => e.MenuItemId);

            builder.HasOne(e => e.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId);
        }
    }
}