using System;
using Communication.Responses;

namespace Application.UseCases.Expenses.GetAll;

public interface IGetAllExpensesUseCase
{
    public Task<ResponseExpensesJson> Execute();
}
