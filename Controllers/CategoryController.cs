using Demo.Entities;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Demo.Controllers
{
    [ApiController]
    [Route("/categories")]
    public class CategoryController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var categories = new List<Category>();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Family",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                Id = 2,
                Name = "Work",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                Id = 3,
                Name = "Todos",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                Id = 4,
                Name = "Prior",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                Id = 5,
                Name = "Personal",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                Id = 6,
                Name = "Friends",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Show(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] CategoryViewModel categoryViewModel)
        {
            var id = new Random();

            var category = new Category
            {
                Id = id.Next(10, 100),
                Name = categoryViewModel.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return Ok(category);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            var category = new Category
            {
                Id = id,
                Name = categoryViewModel.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = new Dictionary<string, string>
            {
                { "message", "Category successfully deleted" }
            };

            return Ok(result);
        }
    }
}

