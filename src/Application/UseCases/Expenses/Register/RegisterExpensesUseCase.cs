using Communication.Enums;
using Communication.Requests;
using Communication.Responses;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception.ExceptionsBase;

namespace Application.UseCases.Expenses.Register;

public class RegisterExpensesUseCase : IRegisterExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterExpensesUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request)
    {
        this.Validate(request);

        var expense = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentMethod = (Domain.Enums.PaymentMethodEnum)request.PaymentMethod,
        };

        await this._repository.Add(expense);

        await this._unitOfWork.Commit();

        return new ResponseRegisteredExpenseJson();
    }

    public void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        var errorMessages = result.Errors.Select(Error => Error.ErrorMessage).ToList();

        if (!result.IsValid)
        {
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
