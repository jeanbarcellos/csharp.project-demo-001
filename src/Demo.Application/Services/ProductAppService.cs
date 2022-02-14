using AutoMapper;
using Demo.Application.Interfaces;
using Demo.Application.ViewModel;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductAppService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _productRepository.Exists(id);
        }

        public async Task<ProductViewModel> Add(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            _productRepository.Insert(product);

            await _productRepository.UnitOfWork.Commit();

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<ProductViewModel> Update(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            _productRepository.Update(product);

            await _productRepository.UnitOfWork.Commit();

            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
