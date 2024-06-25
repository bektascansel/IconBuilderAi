using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAllCommunity
{
    public class OrderGetAllCommunityQuery:IRequest<List<string>>
    {
        public OrderGetAllCommunityQuery() { }  
    }
}
