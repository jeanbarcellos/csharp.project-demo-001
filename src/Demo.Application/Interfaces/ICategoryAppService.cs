using Demo.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Task<CategoryViewModel> Add(CategoryViewModel categoryViewModel);
        Task<CategoryViewModel> Update(CategoryViewModel categoryViewModel);
        Task Delete(CategoryViewModel categoryViewModel);
        Task Delete(Guid id);
    }
}
