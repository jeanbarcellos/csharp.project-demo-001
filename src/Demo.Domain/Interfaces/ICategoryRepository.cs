using Demo.Core.Data;
using Demo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<bool> Exists(int id);

        int Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Delete(int id);
    }
}
