using System.Threading.Tasks;

namespace UserManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
        void CommitChanges();
    }
}
