using Communication.Requests;
using Communication.Responses;

namespace Application.UseCases.Expenses.Register;

public interface IRegisterExpensesUseCase
{
    public Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
}
