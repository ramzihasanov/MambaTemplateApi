
using Mamba.Business.Services.Interfaces;
using Mamba.DTOs.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public ICategoryService CategoryService { get; }

        public CategoriesController(ICategoryService categoryService )
        {
            CategoryService = categoryService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var categorydto = await CategoryService.GetAllAsync();

            return Ok(categorydto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categorydto = CategoryService.GetByIdAsync(id);

           
            return Ok(categorydto);

        }

        [HttpPost]
        public async Task< IActionResult> Create(CategoryCreateDto dto)
        {
             await CategoryService.CreateAsync(dto);
            
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            await CategoryService.UpdateAsync(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task< IActionResult> Delete(int id)
        {
            await CategoryService.Delete(id);
            return NoContent();
        }
    }
}
