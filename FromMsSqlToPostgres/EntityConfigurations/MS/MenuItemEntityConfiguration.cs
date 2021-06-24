using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MsSqlToPostgress.EntityConfigurations.MS
{
    internal class MenuItemEntityConfiguration : IEntityTypeConfiguration<MenuItemEntity>
    {
        public void Configure(EntityTypeBuilder<MenuItemEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(512);

            builder.Property(e => e.Price)
                .HasColumnType(DatabaseTypes.Money);

            builder.HasOne(e => e.MenuCategory)
                .WithMany(m => m.MenuItems)
                .HasForeignKey(e => e.MenuCategoryId);

            builder.HasMany(e => e.OrderItems)
                .WithOne(o => o.MenuItem)
                .HasForeignKey(o => o.MenuItemId);

            builder.HasMany(e => e.UserFavorites)
                .WithOne(uf => uf.MenuItem)
                .HasForeignKey(uf => uf.MenuItemId);
        }
    }
}