using Communication.Enums;
using Communication.Requests;
using Communication.Responses;

namespace Application.UseCases.Expenses.Register
{
    public class RegisterExpensesUseCase
    {
        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            this.Validate(request);

            return new ResponseRegisteredExpenseJson();
        }

        public void Validate(RequestRegisterExpenseJson request)
        {
            var validator = new RegisterExpenseValidator();

            var result = validator.Validate(request);

            var errorMessages = result.Errors.Select(Error => Error.ErrorMessage).ToList();

            if (!result.IsValid)
            {
                throw new ArgumentException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
