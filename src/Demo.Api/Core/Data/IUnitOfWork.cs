using System.Threading.Tasks;

namespace Demo.Api.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
