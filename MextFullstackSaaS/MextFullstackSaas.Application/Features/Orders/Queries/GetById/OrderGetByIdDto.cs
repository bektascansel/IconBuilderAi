using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public int Quantity { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
        public DateTimeOffset CreatedOn{ get; set; }


        public static OrderGetByIdDto MapFromOrder(Order order)
        {
            return new OrderGetByIdDto
            {
                Id = order.Id,
                UserId = order.UserId,
                IconDescription = order.IconDescription,
                ColourCode = order.ColourCode,
                Model = order.Model,
                DesignType = order.DesignType,
                Size = order.Size,
                Shape = order.Shape,
                Quantity = order.Quantity,
                Urls = order.Urls,
                CreatedOn = order.CreatedOn
            };
        }
    }
}
