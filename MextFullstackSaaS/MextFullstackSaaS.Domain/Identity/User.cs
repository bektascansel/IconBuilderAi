using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Identity
{
    // AppUser / ApplicationUSer
    public class User : IdentityUser<Guid>, IEntity<Guid>, ICreatedByEntity, IModifiedByEntitiy
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserBalance Balance { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
