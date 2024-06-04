using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommand:IRequest<ResponseDto<Guid>>
    {
        public Guid Id { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public int Quantity { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }


        public static Order MapToOrder(OrderUpdateCommand orderUpdateCommand, Order oldOrder,Guid modifiedByUserId)
        {

            oldOrder.Size=orderUpdateCommand.Size;
            oldOrder.ColourCode=orderUpdateCommand.ColourCode;
            oldOrder.IconDescription=orderUpdateCommand.IconDescription;
            oldOrder.Model=orderUpdateCommand.Model;
            oldOrder.DesignType=orderUpdateCommand.DesignType;
            oldOrder.Shape=orderUpdateCommand.Shape;
            oldOrder.Quantity=orderUpdateCommand.Quantity;
            oldOrder.ModifiedByUserId = modifiedByUserId.ToString();
            oldOrder.ModifiedOn=DateTimeOffset.Now;

            return oldOrder;

       

        }




    }
}
