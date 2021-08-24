using Demo.Core.Data;
using Demo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> Exists(int id);

        int Insert(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Delete(int id);
    }
}
