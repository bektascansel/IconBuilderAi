using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Entities
{
    public class UserBalance : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Credits { get; set; }
        public ICollection<UserBalanceHistory> Histories { get; set; }

    }
}
