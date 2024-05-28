using FluentValidation;
using MextFullstackSaas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application.Features.Orders.Queries.GetById
{
    public  class OrderGetByIdQueryValidator:AbstractValidator<OrderGetByIdQuery>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderGetByIdQueryValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;


            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull()
               .WithMessage("Please select a valid order.");

            RuleFor(x => x.Id)
                .MustAsync(IsOrderExists)
                .WithMessage("The selected order does not exist in the database.");
        }

        public Task<bool> IsOrderExists(Guid id, CancellationToken cancellationToken)
        {
            //if the order exitss we will return, otherwise we will return false
            // if we return true this will be a valid order

            return _dbContext.Orders.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
