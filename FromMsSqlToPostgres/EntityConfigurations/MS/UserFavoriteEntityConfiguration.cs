using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MsSqlToPostgress.EntityConfigurations.MS
{
    public class UserFavoriteEntityConfiguration : IEntityTypeConfiguration<UserFavoriteEntity>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(e => e.MenuItem)
                .WithMany(mi => mi.UserFavorites)
                .HasForeignKey(e => e.MenuItemId);

            builder
                .HasOne(e => e.User)
                .WithMany(u => u.UserFavorites)
                .HasForeignKey(e => e.UserId);
        }
    }
}
