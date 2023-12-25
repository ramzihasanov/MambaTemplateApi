using AutoMapper;
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
        private readonly AppDbConrtext _appDb;
        private readonly IMapper _mapper;

        public PositionsController(AppDbConrtext appDb, IMapper mapper)
        {
            _appDb = appDb;
            _mapper = mapper;
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public IActionResult GetAll()
        {
            var positions = _appDb.Positions.ToList();
            var positionsdto = positions.Select(positions => _mapper.Map<PositionGetDto>(positions));// new PositionCreateDto()
            
            return Ok(positionsdto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var positions = _appDb.Positions.FirstOrDefault(x => x.Id == id);
            if(positions == null) return NotFound();
            PositionGetDto positionsdto = _mapper.Map<PositionGetDto>(positions);
            return Ok(positionsdto);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Create(PositionCreateDto dto)
        {
            var position = _mapper.Map<Position>(dto);
            position.CreateDate = DateTime.UtcNow.AddHours(4);
            position.UpdateDate = DateTime.UtcNow.AddHours(4);          
            _appDb.Positions.Add(position);
            _appDb.SaveChanges();
            return Ok(position);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(PositionUpdateDto dto)
        {
            var position = _appDb.Positions.Find(dto.Id);
            if (position == null) return NotFound();
            position = _mapper.Map(dto, position);
            position.UpdateDate = DateTime.UtcNow.AddHours(4);
            _appDb.SaveChanges();
            return Ok(position);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var position = _appDb.Positions.Find(id);
            if(position == null) return NotFound();
            position.Isdeleted = !position.Isdeleted;
            _appDb.SaveChanges();
            return NoContent();
        }
    }
}