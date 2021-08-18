using System.Threading.Tasks;

namespace Demo.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
