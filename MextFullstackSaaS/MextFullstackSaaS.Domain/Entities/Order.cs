using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Entities
{
    public class Order: EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public int Quantity { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
        public string? Description { get; set; }

    }
}
