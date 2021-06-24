using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MsSqlToPostgress.EntityConfigurations.MS;

namespace MsSqlToPostgress
{
    public abstract class AppDbContext : DbContext
    {
        public DbSet<MenuCategoryEntity> MenuCategories { get; }

        public DbSet<MenuItemEntity> MenuItems { get; }

        public DbSet<OrderItemEntity> OrderItems { get; }

        public DbSet<OrderEntity> Orders { get; }

        public DbSet<UserEntity> Users { get; }

        public DbSet<LocationEntity> Locations { get; }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; }

        public DbSet<UserFavoriteEntity> UserFavorites { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new LocationEntityConfiguration())
                .ApplyConfiguration(new MenuCategoryEntityConfiguration())
                .ApplyConfiguration(new MenuItemEntityConfiguration())
                .ApplyConfiguration(new OrderEntityConfiguration())
                .ApplyConfiguration(new OrderItemEntityConfiguration())
                .ApplyConfiguration(new UserEntityConfiguration())
                .ApplyConfiguration(new RefreshTokenEntityConfiguration())
                .ApplyConfiguration(new UserFavoriteEntityConfiguration());
        }
    }
}