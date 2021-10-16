using Demo.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        Task<bool> Exists(int id);

        Task<ProductViewModel> Add(ProductViewModel productViewModel);
        Task<ProductViewModel> Update(ProductViewModel productViewModel);
    }
}
