using FluentValidation;
using MextFullstackSaaS.Application.Common.Translations;
using MextFullstackSaaS.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;

namespace MextFullstackSaaS.WebApi.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IStringLocalizer<CommonTranslations> _localizer;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IStringLocalizer<CommonTranslations> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            var response = new ResponseDto<string>(); 

            switch (context.Exception)
            {
                
                case ValidationException validationException:

                    var message = _localizer[CommonTranslationKeys.GeneralValidationExceptionMessage];

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


                    response.Message = _localizer[CommonTranslationKeys.GeneralServerExceptionMessage];

                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = (int)StatusCodes.Status500InternalServerError
                    };

                    break;




            }
        }
    }
}
