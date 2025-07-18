using Application.AutoMapper;
using Application.UseCases.Expenses.GetAll;
using Application.UseCases.Expenses.GetById;
using Application.UseCases.Expenses.NewFolder;
using Application.UseCases.Expenses.Register;
using Application.UseCases.Expenses.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMappers(services);
        AddUseCases(services);
    }

    private static void AddAutoMappers(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpensesUseCase, RegisterExpensesUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
	}
}
