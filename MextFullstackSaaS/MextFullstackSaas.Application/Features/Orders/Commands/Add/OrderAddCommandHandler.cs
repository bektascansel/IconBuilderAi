using MediatR;
using MextFullstackSaaS.Application.Common.Helpers;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.OpenAI;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAll;
using MextFullstackSaaS.Domain.Common;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        private readonly IOrderHubService _orderHubService;


        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService, IOpenAIService openAService, IMemoryCache memoryCache, IOrderHubService orderHubService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _openAService = openAService;
            _memoryCache = memoryCache;
            _orderHubService = orderHubService;
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

            if(_memoryCache.TryGetValue(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),out List<OrderGetAllDto> orders))
            {
                orders.Add(OrderGetAllDto.FromOrder(order));
                _memoryCache.Set(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),orders,MemoryCacheHelper.GetMemoryCacheEntryOptions());
            }

            _orderHubService.NewOrderAddedAsync(order.Urls, cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Your order completed successfully");
        }
    }


}
