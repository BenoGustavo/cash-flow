using Domain.Entities;

namespace Domain.Repositories.Expenses
{
	public interface IExpensesWriteOnlyRepository
	{
		Task Add(Expense expense);

		/// <summary>
		/// This function returns true if the deletion was sucessfully otherwise it returns false
		/// </summary>
		/// <param name="id"></param>
		Task<bool> Delete(long id);
	}
}
