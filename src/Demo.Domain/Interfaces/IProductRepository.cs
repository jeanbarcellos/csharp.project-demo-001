using Demo.Core.Data;
using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Guid Insert(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Delete(Guid id);
    }
}
