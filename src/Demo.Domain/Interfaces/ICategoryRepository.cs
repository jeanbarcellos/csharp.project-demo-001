using Demo.Core.Data;
using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Guid Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Delete(Guid id);
    }
}
