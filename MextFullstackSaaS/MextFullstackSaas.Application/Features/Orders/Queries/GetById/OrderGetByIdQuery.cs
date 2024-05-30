using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdQuery:IRequest<OrderGetByIdDto>
    {
        public Guid Id { get; set; }

        public OrderGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
