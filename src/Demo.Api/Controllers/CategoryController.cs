using Demo.Domain.Entities;
using Demo.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Interfaces;
using AutoMapper;

namespace Demo.Api.Controllers
{
    [Route("/categories")]
    public class CategoryController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CategoryViewModel>> Index()
        {
            var categories = await _categoryRepository.GetAll();

            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Show(int id)
        {
            var result = await _categoryRepository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryViewModel>(result));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            var category = _mapper.Map<Category>(categoryViewModel);

            categoryViewModel.Id = _categoryRepository.Insert(category);

            await _categoryRepository.UnitOfWork.Commit();

            return CreatedAtAction(nameof(Show), new { id = category.Id }, category);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            if (categoryViewModel == null || id == 0 || categoryViewModel.Id == null)
            {
                return NotFound();
            }

            var result = await _categoryRepository.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            var category = _mapper.Map<Category>(categoryViewModel);

            _categoryRepository.Update(category);

            await _categoryRepository.UnitOfWork.Commit();

            return Ok(_mapper.Map<CategoryViewModel>(category));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var result = await _categoryRepository.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            _categoryRepository.Delete(id);

            await _categoryRepository.UnitOfWork.Commit();

            var resultViewModel = new ResultViewModel
            {
                Message = "Categoria excluída com sucesso",
                Data = new { Id = id }
            };

            return Ok(resultViewModel);
        }
    }
}

