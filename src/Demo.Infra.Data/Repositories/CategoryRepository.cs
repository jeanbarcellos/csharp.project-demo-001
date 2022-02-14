using Demo.Core.Data;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
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

        public async Task<Category> GetById(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Categories.AnyAsync(e => e.Id == id);
        }

        public Guid Insert(Category category)
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

        public void Delete(Guid id)
        {
            //var category = _context.Categories.SingleOrDefaultAsync(s => s.Id == id);
            var category = _context.Categories.Find(id);

            if (category != null)
            {
                Delete(category);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
