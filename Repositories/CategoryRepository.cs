using Demo.Core.Data;
using Demo.Data;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        protected readonly DemoContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CategoryRepository(DemoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public int Insert(Category apartment)
        {
            _context.Categories.Add(apartment);

            return apartment.Id;
        }

        public void Update(Category apartment)
        {
            _context.Categories.Update(apartment);
        }

        public void Delete(Category apartment)
        {
            _context.Categories.Remove(apartment);
        }

        public void Delete(int id)
        {
            //var apartment = _context.Categories.SingleOrDefaultAsync(s => s.Id == id);
            var apartment = _context.Categories.Find(id);

            if (apartment != null)
            {
                Delete(apartment);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Categories.AnyAsync(e => e.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
