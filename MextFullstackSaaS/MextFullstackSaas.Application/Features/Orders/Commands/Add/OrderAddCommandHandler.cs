using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.OpenAI;
using MextFullstackSaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IOpenAIService _openAService;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService, IOpenAIService openAService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _openAService = openAService;
        }


        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = OrderAddCommand.MapToOrder(request);

            order.UserId = _currentUserService.UserId;
            order.CreatedByUserId = _currentUserService.UserId.ToString();
            order.Urls = await _openAService.DallECreateIconAsync(DallECreateIconRequestDto.MapFromOrderAddCommand(request),cancellationToken);
            // TODO: make request to the gemini or dall-e3

            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Your order completed successfully");
        }
    }


}
