using MextFullstackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MextFullstackSaas.Infrastructure.Persistence.Configurations
{
    public class UserBalanceConfiguration : IEntityTypeConfiguration<UserBalance>
    {
        public void Configure(EntityTypeBuilder<UserBalance> builder)
        {
            
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Credits)
                .IsRequired();

                //Common Properties

                // CreatedDate
                builder.Property(x => x.CreatedOn).IsRequired();

                // CreatedByUserId
                builder.Property(user => user.CreatedByUserId)
                    .HasMaxLength(100)
                    .IsRequired();

                // ModifiedDate
                builder.Property(user => user.ModifiedOn).IsRequired(false);

                // ModifiedByUserId
                builder.Property(user => user.ModifiedByUserId)
                    .HasMaxLength(100)
                    .IsRequired(false);

            /* builder.HasOne<User>(x => x.User)
                 .WithMany(x => x.Orders)
                 .HasForeignKey(x => x.UserId);*/

            builder.HasMany<UserBalanceHistory>(x => x.Histories)
                .WithOne(x => x.UserBalance)
                .HasForeignKey(x => x.UserBalanceId);

                builder.ToTable("UserBalances");
          
        }
    }
}
