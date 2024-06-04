using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator:AbstractValidator<OrderDeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderDeleteCommandValidator(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;


            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull()
               .WithMessage("Please select a valid order.");

            RuleFor(x => x.Id)
                .MustAsync(IsOrderExistsAsync)
                .WithMessage("The selected order does not exist in the database.");

            RuleFor(x => x.Id)
                .MustAsync(IsTheSameUserAsync)
                .WithMessage("You are not authorized to delete this order");

        }

        private Task<bool> IsOrderExistsAsync(Guid id,CancellationToken cancellationToken)
        {
            //if the order exitss we will return, otherwise we will return false
            // if we return true this will be a valid order

            return _dbContext.Orders.AnyAsync(x=>x.Id==id,cancellationToken);
        }

        private Task<bool> IsTheSameUserAsync(Guid id, CancellationToken cancellationToken)
        {
            //if the order exitss we will return, otherwise we will return false
            // if we return true this will be a valid order

            return _dbContext
                .Orders
                .Where(x => x.UserId == _currentUserService.UserId)
                .AnyAsync(x => x.Id == id, cancellationToken);
        }


    }
}
