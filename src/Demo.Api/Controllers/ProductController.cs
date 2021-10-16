using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Application.Interfaces;
using Demo.Application.ViewModel;

namespace Demo.Api.Controllers
{
    [Route("/products")]
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ProductViewModel>> Index()
        {
            return await _productAppService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Show(int id)
        {
            var result = await _productAppService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            productViewModel = await _productAppService.Add(productViewModel);

            return CreatedAtAction(nameof(Show), new { productViewModel.Id }, productViewModel);
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

            var result = await _productAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            productViewModel = await _productAppService.Update(productViewModel);

            return Ok(productViewModel);
        }
    }
}

