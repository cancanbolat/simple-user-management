using System.Threading.Tasks;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CommitChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
