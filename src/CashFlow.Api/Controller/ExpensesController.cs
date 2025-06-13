using Application.UseCases.Expenses.Register;
using Communication.Requests;
using Communication.Responses;
using Exception.ExceptionsBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {
            var response = new RegisterExpensesUseCase().Execute(request);

            return CreatedAtAction(
                nameof(Register),
                new { id = response.Title },
                response
            );
        }
    }
}
