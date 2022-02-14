using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Application.Interfaces;
using Demo.Application.ViewModel;
using System;

namespace Demo.Api.Controllers
{
    [Route("/categories")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CategoryViewModel>> Index()
        {
            return await _categoryAppService.GetAll();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Show(Guid id)
        {
            var result = await _categoryAppService.GetById(id);

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

            categoryViewModel = await _categoryAppService.Add(categoryViewModel);

            return CreatedAtAction(nameof(Show), new { categoryViewModel.Id }, categoryViewModel);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            if (categoryViewModel == null || id == Guid.Empty || categoryViewModel.Id == null)
            {
                return NotFound();
            }

            var result = await _categoryAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            categoryViewModel = await _categoryAppService.Update(categoryViewModel);

            return Ok(categoryViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var result = await _categoryAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _categoryAppService.Delete(id);

            return Ok();
        }
    }
}

