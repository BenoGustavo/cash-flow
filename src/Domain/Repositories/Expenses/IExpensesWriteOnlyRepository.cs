using Domain.Entities;

namespace Domain.Repositories.Expenses
{
	public interface IExpensesWriteOnlyRepository
	{
		Task Add(Expense expense);
	}
}
