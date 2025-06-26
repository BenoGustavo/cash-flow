using AutoMapper;
using Communication.Responses;
using Domain.Repositories;
using Domain.Repositories.Expenses;

namespace Application.UseCases.Expenses.GetAll;

public class GetAllExpensesUseCase : IGetAllExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public GetAllExpensesUseCase(
        IExpensesRepository repository,
        IMapper mapper
    )
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseExpensesJson> Execute()
    {
        var expenses = await this._repository.GetAll();
        if (expenses.Count == 0)
        {
            return new ResponseExpensesJson
            {
                Expenses = new List<ResponseShortExpenseJson>()
            };
        }

        return new ResponseExpensesJson
        {
            Expenses = this._mapper.Map<List<ResponseShortExpenseJson>>(expenses)
        };
    }
}
