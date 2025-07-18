namespace Application.UseCases.Expenses.NewFolder
{
	public interface IDeleteExpenseUseCase
	{
		public Task Execute(long id);
	}
}
