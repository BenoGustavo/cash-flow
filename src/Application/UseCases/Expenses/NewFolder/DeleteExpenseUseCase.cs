using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception;
using Exception.ExceptionsBase;

namespace Application.UseCases.Expenses.NewFolder
{
	public class DeleteExpenseUseCase : IDeleteExpenseUseCase
	{
		private IExpensesWriteOnlyRepository _repository;
		private IUnitOfWork _unitOfWork;

		public DeleteExpenseUseCase(
			IExpensesWriteOnlyRepository repository,
			IUnitOfWork unitOfWork
		)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public async Task Execute(long id)
		{
			var result = await _repository.Delete(id);

			if (result == false) 
			{
				throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
			}

			await _unitOfWork.Commit();
		}
	}
}
