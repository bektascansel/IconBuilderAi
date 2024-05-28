using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Identity;
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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.IconDescription)
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(x => x.ColourCode)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.Model)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.DesignType)
               .HasConversion<int>()
               .IsRequired();

            builder.Property(x => x.Size)
              .HasConversion<int>()
              .IsRequired();

            builder.Property(x => x.Shape)
              .HasConversion<int>()
              .IsRequired();

            builder.Property(x => x.Quantity)
              .IsRequired();

            
            builder.Property(e => e.Urls)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));


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

            builder.ToTable("Orders");
        }
    }
}
