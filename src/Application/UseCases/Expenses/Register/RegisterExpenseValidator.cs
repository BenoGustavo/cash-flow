using Communication.Requests;
using Exception;
using FluentValidation;

namespace Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidator() 
        {
            RuleFor(Expenses => Expenses.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
            RuleFor(Expenses => Expenses.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
            RuleFor(Expenses => Expenses.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE);
            RuleFor(Expenses => Expenses.PaymentMethod).NotEmpty()
                .WithMessage(ResourceErrorMessages.PAYMENT_METHOD_CANNOT_BE_NULL)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.INVALID_PAYMENT_METHOD);

        }
    }
}
