using Communication.Responses;
using Exception;
using Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

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
			if (context.Exception is ErrorOnValidationException validationException)
			{
				var validationResponse = new ResponseErrorJson(validationException.GetErrors());
				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				context.Result = new BadRequestObjectResult(validationResponse);
			}
			else if (context.Exception is NotFoundException notFoundException)
			{
				var notFoundResponse = new ResponseErrorJson(notFoundException.GetErrors());
				context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				context.Result = new BadRequestObjectResult(notFoundResponse);
			}
			else
			{
				var errorResponse = new ResponseErrorJson(context.Exception.Message);
				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				context.Result = new BadRequestObjectResult(errorResponse);
			}
		}

		private void ThrowUnkownError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

            if (_hostEnvironment.IsDevelopment())
            {
                this.ConsoleLogError(context);
            }

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ConsoleLogError(ExceptionContext context)
        {
            var exception = context.Exception;
            var request = context.HttpContext.Request;

            Console.WriteLine("==================== UNHANDLED EXCEPTION ====================");
            Console.WriteLine($"[TIMESTAMP]: {DateTime.UtcNow:o}");
            Console.WriteLine($"[REQUEST]:   {request.Method} {request.Path}");
            Console.WriteLine($"[TYPE]:      {exception.GetType().FullName}");
            Console.WriteLine($"[MESSAGE]:   {exception.Message}");
            Console.WriteLine("-------------------- STACK TRACE --------------------");
            Console.WriteLine(exception.StackTrace);

            var innerException = exception.InnerException;
            while (innerException is not null)
            {
                Console.WriteLine("\n-------------------- INNER EXCEPTION --------------------");
                Console.WriteLine($"[TYPE]:      {innerException.GetType().FullName}");
                Console.WriteLine($"[MESSAGE]:   {innerException.Message}");
                Console.WriteLine(innerException.StackTrace);
                innerException = innerException.InnerException;
            }
            Console.WriteLine("==========================================================");
        }
    }
}
