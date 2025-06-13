using Communication.Responses;
using Exception;
using Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CashFlowException)
            {
                this.HandleProjectException(context);
            }
            else
            {
                this.ThrowUnkownError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ErrorOnValidationException validationException:
                    var ex = (ErrorOnValidationException)context.Exception;

                    var validationResponse = new ResponseErrorJson(ex.GetErrors());
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Result = new BadRequestObjectResult(validationResponse);
                    break;
                default:
                    var errorResponse = new ResponseErrorJson(context.Exception.Message);

                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Result = new BadRequestObjectResult(errorResponse);
                    break;
            }
        }

        private void ThrowUnkownError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
