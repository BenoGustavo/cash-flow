using Application.UseCases.Expenses.Register;
using Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
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
