using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MsSqlToPostgress.EntityConfigurations.MS
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(128);

            builder.Property(e => e.LastName)
                .HasMaxLength(128);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(64);

            builder.Property(e => e.Username)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .IsRequired();

            builder.HasMany(e => e.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.HasMany(e => e.RefreshTokens)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.HasMany(e => e.UserFavorites)
                .WithOne(uf => uf.User)
                .HasForeignKey(uf => uf.UserId);
        }
    }
}