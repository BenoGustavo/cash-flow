using Exception;
using FluentValidation;

namespace Application.UseCases.Expenses.GetById;

public class GetExpenseByIdValidator : AbstractValidator<long>
{
    public GetExpenseByIdValidator()
    {
        RuleFor(id => id)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.ID_MUST_BE_GREATER_THAN_ZERO);
    }
}
