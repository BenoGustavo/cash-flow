using System.Threading.Tasks;
using Domain.Repositories;

namespace Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CashFlowDbContext _dbContext;
        public UnitOfWork(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await this._dbContext.SaveChangesAsync();
    }
}
