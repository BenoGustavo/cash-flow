using System.Net;

namespace Exception.ExceptionsBase
{
    public class ErrorOnValidationException : CashFlowException
    {
        private readonly List<string> _errors;

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages ?? throw new ArgumentNullException(nameof(errorMessages), "Error messages cannot be null.");
        }

        public override List<string> GetErrors()
        {
            return _errors;
        }
    }
}
