using Demo.Core.Data;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly DemoContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(DemoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Products.AnyAsync(e => e.Id == id);
        }

        public int Insert(Product product)
        {
            _context.Products.Add(product);

            return product.Id;
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                Delete(product);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
