using Demo.Domain.Entities;
using Demo.Data.Repositories;
using Demo.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Api.Controllers
{
    [Route("/categories")]
    public class CategoryController : ApiController
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Category>> IndexAsync()
        {
            return await _categoryRepository.GetAll();
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

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            var category = new Category
            {
                Name = categoryViewModel.Name,
            };

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

            var category = await _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = categoryViewModel.Name;

            await _categoryRepository.UnitOfWork.Commit();

            return Ok(category);
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

