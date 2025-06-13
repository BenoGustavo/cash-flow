using Communication.Requests;
using FluentValidation;

namespace Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidator() 
        {
            RuleFor(Expenses => Expenses.Title).NotEmpty().WithMessage("Title cannot be empty or null.");
            RuleFor(Expenses => Expenses.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
            RuleFor(Expenses => Expenses.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Date cannot be in the future.");
            RuleFor(Expenses => Expenses.PaymentMethod).NotEmpty()
                .WithMessage("Payment method cannot be empty or null.")
                .IsInEnum()
                .WithMessage("Invalid payment method.");

        }
    }
}
