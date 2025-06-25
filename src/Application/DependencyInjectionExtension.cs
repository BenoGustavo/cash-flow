using Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    { 
        services.AddScoped<IRegisterExpensesUseCase, RegisterExpensesUseCase>();
    }
}
