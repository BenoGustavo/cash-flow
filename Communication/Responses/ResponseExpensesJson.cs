namespace Communication.Responses;

public class ResponseExpensesJson
{
    public List<ResponseShortExpenseJson> Expenses { get; set; } = new List<ResponseShortExpenseJson>();
}
