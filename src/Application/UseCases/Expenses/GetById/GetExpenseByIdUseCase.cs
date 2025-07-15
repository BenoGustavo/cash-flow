using AutoMapper;
using Communication.Responses;
using Domain.Repositories.Expenses;
using Exception.ExceptionsBase;

namespace Application.UseCases.Expenses.GetById;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    readonly IMapper _mapper;
    readonly IExpensesRepository _expensesRepository;

    public GetExpenseByIdUseCase(
        IExpensesRepository expensesRepository,
        IMapper mapper
    )
    {
        _expensesRepository = expensesRepository;
        _mapper = mapper;
    }
    public async Task<ResponseExpenseJson> Execute(long id)
    {
        this.Validate(id);

        var expense = await _expensesRepository.GetById(id);

        return _mapper.Map<ResponseExpenseJson>(expense);
    }

    private void Validate(long id)
    {
        var validator = new GetExpenseByIdValidator();
        var result = validator.Validate(id);

        var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

        if (!result.IsValid)
        {
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
