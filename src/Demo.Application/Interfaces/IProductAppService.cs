using Demo.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Task<ProductViewModel> Add(ProductViewModel productViewModel);
        Task<ProductViewModel> Update(ProductViewModel productViewModel);
    }
}
