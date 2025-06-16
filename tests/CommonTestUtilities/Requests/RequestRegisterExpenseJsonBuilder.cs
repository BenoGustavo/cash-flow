using Bogus;
using Communication.Requests;
using Communication.Enums;

namespace CommonTestUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        var faker =  new Faker("en");

        return new RequestRegisterExpenseJson
        {
            Title = faker.Commerce.ProductName(),
            Date = faker.Date.Past(),
            Description = faker.Lorem.Sentence(10),
            PaymentMethod = faker.PickRandom<PaymentMethodEnum>(),
            Amount = faker.Random.Decimal(min:1, max:1000),
        };
    }
}
