using Domain.Entities;
using Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

	public async Task<bool> Delete(long id)
	{
        var expense = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

        if (expense is null) return false;

        _dbContext.Expenses.Remove(expense);

        return true;
	}

	public async Task<List<Expense>> GetAll()
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Expense?> GetById(long id)
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
