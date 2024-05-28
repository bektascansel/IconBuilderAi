using MextFullstackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Infrastructure.Persistence.Configurations
{
    public class UserBalanceHistoryConfiguration : IEntityTypeConfiguration<UserBalanceHistory>
    {
        public void Configure(EntityTypeBuilder<UserBalanceHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CurrentsCredits)
                .IsRequired();

            builder.Property(x => x.PreviousCredits)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasConversion<int>()
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

            builder.ToTable("UserBalanceHistories");
        }
    }
}
