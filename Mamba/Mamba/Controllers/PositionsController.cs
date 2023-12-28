using AutoMapper;
using Mamba.Business.Services.Interfaces;
using Mamba.DAL;
using Mamba.DTOs.PositionDto;
using Mamba.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PositionsController : ControllerBase
    {
    
        private readonly IPositionService positionService;

        public PositionsController(IPositionService positionService)
        {
            this.positionService = positionService;
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAll()
        {
            var positionsdto = await positionService.GetAllAsync();
            
            return Ok(positionsdto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var positionsdto = await positionService.GetByIdAsync(id);
            return Ok(positionsdto);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(PositionCreateDto dto)
        {
            await positionService.CreateAsync(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(PositionUpdateDto dto)
        {
            await positionService.UpdateAsync(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
           await positionService.Delete(id);
            return NoContent();
        }
    }
}