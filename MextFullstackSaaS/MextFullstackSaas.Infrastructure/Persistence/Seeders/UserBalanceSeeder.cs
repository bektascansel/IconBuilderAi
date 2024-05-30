using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Infrastructure.Persistence.Seeders
{
    public class UserBalanceSeeder : IEntityTypeConfiguration<UserBalance>
    {
        public void Configure(EntityTypeBuilder<UserBalance> builder)
        {
            var mextUsersBalance = new UserBalance()
            {
                Id = new Guid("8fccfc1c-baff-41f8-afc4-2b5b08bb8cf6"),
                UserId = new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                Credits = 20,
                CreatedOn = Convert.ToDateTime("2024-05-22T10:16:31+00:00"),
                CreatedByUserId = "35c16d2a-f25b-4701-9a74-ea1fb7ed6d93",
            };
            builder.HasData(mextUsersBalance);
        }
    }
}
