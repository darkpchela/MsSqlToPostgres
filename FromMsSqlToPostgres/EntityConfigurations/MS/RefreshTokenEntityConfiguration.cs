using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MsSqlToPostgress.EntityConfigurations.MS
{
    public class RefreshTokenEntityConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EncodedValue)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(o => o.RefreshTokens)
                .HasForeignKey(e => e.UserId);
        }
    }
}
