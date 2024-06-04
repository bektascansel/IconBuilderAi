using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Common
{
    public abstract class EntityBase<TKey> : IEntity<TKey>, ICreatedByEntity, IModifiedByEntity
    {
        public TKey Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get ; set ; }
    }
}


