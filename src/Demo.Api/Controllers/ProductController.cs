using Demo.Domain.Entities;
using Demo.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Interfaces;
using AutoMapper;

namespace Demo.Api.Controllers
{
    [Route("/products")]
    public class ProductController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ProductViewModel>> Index()
        {
            var products = await _productRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Show(int id)
        {
            var result = await _productRepository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductViewModel>(result));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            var product = _mapper.Map<Product>(productViewModel);

            productViewModel.Id = _productRepository.Insert(product);

            await _productRepository.UnitOfWork.Commit();

            return CreatedAtAction(nameof(Show), new { id = product.Id }, product);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            if (productViewModel == null || id == 0 || productViewModel.Id == null)
            {
                return NotFound();
            }

            var result = await _productRepository.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            var product = _mapper.Map<Product>(productViewModel);

            _productRepository.Update(product);

            await _productRepository.UnitOfWork.Commit();

            return Ok(_mapper.Map<ProductViewModel>(product));
        }
    }
}

