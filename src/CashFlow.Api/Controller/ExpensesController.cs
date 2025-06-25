using Application.UseCases.Expenses.Register;
using Communication.Requests;
using Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseRegisteredExpenseJson))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseErrorJson))]
        public async Task<IActionResult> Register([FromBody] RequestRegisterExpenseJson request, [FromServices] IRegisterExpensesUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return CreatedAtAction(
                nameof(Register),
                new { id = response.Title },
                response
            );
        }
    }
}
