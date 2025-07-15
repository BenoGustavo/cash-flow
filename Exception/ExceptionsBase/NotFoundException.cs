
using System.Net;

namespace Exception.ExceptionsBase
{
	public class NotFoundException : CashFlowException
	{
		public override int StatusCode => (int)HttpStatusCode.NotFound;

		public NotFoundException(string message) : base(message)
		{
			
		}

		public override List<string> GetErrors()
		{
			return new List<string> { base.Message };
		}
	}
}
