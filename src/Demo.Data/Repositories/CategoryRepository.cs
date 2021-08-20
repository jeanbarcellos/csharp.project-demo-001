using Demo.Core.Data;
using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Data.Repositories
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

        public int Insert(Category category)
        {
            _context.Categories.Add(category);

            return category.Id;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public void Delete(int id)
        {
            //var category = _context.Categories.SingleOrDefaultAsync(s => s.Id == id);
            var category = _context.Categories.Find(id);

            if (category != null)
            {
                Delete(category);
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
