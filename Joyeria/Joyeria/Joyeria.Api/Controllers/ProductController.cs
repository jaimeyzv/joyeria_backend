using AutoMapper;
using Joyeria.Application.UseCase.CategoryUC.Commands;
using Joyeria.Application.UseCase.CategoryUC.Queries;
using Joyeria.Application.UseCase.ProductUC.Commands;
using Joyeria.Application.UseCase.ProductUC.Queries;
using Joyeria.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Joyeria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductCommands _productCommands;
        private readonly IProductQueries _productQueries;
        private readonly ICategoryCommands _categoryCommands;
        private readonly ICategoryQueries _categoryQueries;
        private readonly IMapper _mapper;

        public ProductController(IProductCommands productCommands,
            IProductQueries productQueries,
            ICategoryCommands categoryCommands,
            ICategoryQueries categoryQueries,
            IMapper mapper)
        {
            
            _productCommands = productCommands;
            _productQueries = productQueries;
            _categoryCommands = categoryCommands;
            _categoryQueries = categoryQueries;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productQueries.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProductById([FromRoute]Guid id)
        {
            try
            {
                var product = await _productQueries.GetProductByIdAsync(id);
                if (product == null) return BadRequest($"Producto con id {id} no existe");

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                var product = await _productQueries.GetProductByIdAsync(id);
                if (product == null) return BadRequest($"Producto con id {id} no existe");
                await _productCommands.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductVM product)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest($"Payload producto no es valido");
                var category = await _categoryQueries.GetCategoryByIdAsync(product.CategoryId);
                if (category == null) return BadRequest($"Category con id {product.CategoryId} no existe");

                var model = _mapper.Map<ProductModel>(product);
                var productCreated = await _productCommands.CreateAsync(model);

                return Ok(productCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromBody] ProductVM product, [FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload producto no es valido");
                var category = await _categoryQueries.GetCategoryByIdAsync(product.CategoryId);
                if (category == null) return BadRequest($"Category con id {product.CategoryId} no existe");
                var productFound = await _productQueries.GetProductByIdAsync(id);
                if (productFound == null) return BadRequest($"Producto con id {id} no existe");     

                var model = _mapper.Map<ProductModel>(product);
                var productUpdated = await _productCommands.UpdateAsync(model);

                return Ok(productUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
   
    
    
    
    }
}
