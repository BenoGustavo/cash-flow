using Communication.Requests;

namespace Application.UseCases.Expenses.Update;

public interface IUpdateExpenseUseCase
{
	public Task Execute(long id, RequestExpenseJson request);
}
