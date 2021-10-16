using AutoMapper;
using Demo.Application.Interfaces;
using Demo.Application.ViewModel;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            return _mapper.Map<CategoryViewModel>(await _categoryRepository.GetById(id));
        }

        public async Task<bool> Exists(int id)
        {
            return await _categoryRepository.Exists(id);
        }

        public async Task<CategoryViewModel> Add(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);

            _categoryRepository.Insert(category);

            await _categoryRepository.UnitOfWork.Commit();

            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<CategoryViewModel> Update(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);

            _categoryRepository.Update(category);

            await _categoryRepository.UnitOfWork.Commit();

            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task Delete(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);

            _categoryRepository.Delete(category);

            await _categoryRepository.UnitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            _categoryRepository.Delete(id);

            await _categoryRepository.UnitOfWork.Commit();
        }
    }
}
