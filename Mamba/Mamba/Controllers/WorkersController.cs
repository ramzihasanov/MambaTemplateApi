using AutoMapper;
using Mamba.Business.Services.Interfaces;
using Mamba.DAL;
using Mamba.DTOs.WorkerDto;
using Mamba.Entites;
using Mamba.Helpers;
using Microsoft.AspNetCore.Mvc;
using static Humanizer.On;

namespace Mamba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService workerService;

        public WorkersController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< IActionResult> GetAll(string? search, int? categoryId, int? order)
        {
           
            var workersdto = await workerService.GetAllAsync();
            return Ok(workersdto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var workersdto = await workerService.GetByIdAsync(id);
           
            return Ok(workersdto);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< IActionResult> Create([FromForm]WorkerCreateDto dto)
        {
            await workerService.CreateAsync(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromForm]WorkerUpdateDto dto)
        {
            await workerService.UpdateAsync(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await workerService.Delete(id);
            return NoContent();
        }
    }
}