using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand,ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderDeleteCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      

        public async Task<ResponseDto<Guid>> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext
                 .Orders
                 .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Your order deleted successfully");
        }
    }
}
