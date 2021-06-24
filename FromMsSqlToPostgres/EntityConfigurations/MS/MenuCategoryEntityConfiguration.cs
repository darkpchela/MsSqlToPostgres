using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MsSqlToPostgress.EntityConfigurations.MS
{
    internal class MenuCategoryEntityConfiguration : IEntityTypeConfiguration<MenuCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<MenuCategoryEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.Property(e => e.Description)
                .HasMaxLength(512);

            builder.HasMany(e => e.MenuItems)
                .WithOne(i => i.MenuCategory)
                .HasForeignKey(i => i.MenuCategoryId);
        }
    }
}