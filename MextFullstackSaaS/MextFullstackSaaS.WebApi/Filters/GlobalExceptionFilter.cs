using FluentValidation;
using MextFullstackSaaS.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MextFullstackSaaS.WebApi.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            var response = new ResponseDto<string>(); 

            switch (context.Exception)
            {
                
                case ValidationException validationException:

                    var message = "One or more validation errors occurred";

                    List<ErrorDto> errors = new List<ErrorDto>();

                    var propertyNames = validationException
                        .Errors
                        .Select(x => x.PropertyName)
                        .Distinct();

                    foreach(var propertName in propertyNames)
                    {
                        var propertyFailures = validationException
                            .Errors
                            .Where(x => x.PropertyName == propertName)
                            .Select(x => x.ErrorMessage)
                            .ToList();

                        errors.Add(new ErrorDto(propertName,propertyFailures));
                    }

                    response.Message = message;
                    response.Errors = errors;
                    
                    context.Result=new BadRequestObjectResult(response);

                    break;


                default:


                    response.Message = "An unexpected error was occurred.";

                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = (int)StatusCodes.Status500InternalServerError
                    };

                    break;




            }
        }
    }
}
