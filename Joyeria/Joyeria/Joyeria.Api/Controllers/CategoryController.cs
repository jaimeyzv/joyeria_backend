using AutoMapper;
using Joyeria.Application.UseCase.CategoryUC.Commands;
using Joyeria.Application.UseCase.CategoryUC.Queries;
using Joyeria.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Joyeria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryCommands _categoryCommands;
        private readonly ICategoryQueries _categoryQueries;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryCommands categoryCommands, 
            ICategoryQueries categoryQueries,
            IMapper mapper)
        {
            _categoryCommands = categoryCommands;
            _categoryQueries = categoryQueries;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                var categories = await _categoryQueries.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryVM category)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload categoria no es valida");


                var categoryToCreate = new CategoryModel()
                {
                    Name = category.Name
                };

                var categoryCreated = await _categoryCommands.CreateAsync(categoryToCreate);

                return Ok(categoryCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] CategoryVM category, [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload categoria no es valida");

                
                var categoryFound = await _categoryQueries.GetCategoryByIdAsync(id);

                if (categoryFound == null) return BadRequest($"Producto con id {id} no existe");

                categoryFound.Name = category.Name;

                var categoryUpdated = await _categoryCommands.UpdateAsync(categoryFound);

                return Ok(categoryUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
