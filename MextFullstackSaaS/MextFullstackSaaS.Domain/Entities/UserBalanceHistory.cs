using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Entities
{
    public class UserBalanceHistory : EntityBase<Guid>
    {
        public Guid UserBalanceId { get; set; }
        public UserBalance UserBalance { get; set; }

        public UserBalanceHistoryType Type { get; set; }
        public int Amount { get; set; }
        public int PreviousCredits { get; set; }
        public int CurrentsCredits { get; set; }
    }
}
