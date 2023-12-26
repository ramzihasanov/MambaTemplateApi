using AutoMapper;
using Mamba.DAL;
using Mamba.DTOs.PositionDto;
using Mamba.DTOs.WorkerDto;
using Mamba.Entites;
using Mamba.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly AppDbConrtext _appDb;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public WorkersController(AppDbConrtext appDb, IMapper mapper,IWebHostEnvironment env)
        {
            _appDb = appDb;
            _mapper = mapper;
            this._env = env;
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var workers = _appDb.Workers.ToList();
            var workersdto = workers.Select(worker => _mapper.Map<WorkerGetDto>(worker));// new PositionCreateDto()
            return Ok(workersdto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var workers = _appDb.Workers.FirstOrDefault(x => x.Id == id);
            if(workers == null) return NotFound();

            WorkerGetDto workerGetDto = _mapper.Map<WorkerGetDto>(workers);
            return Ok(workerGetDto);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Create([FromForm]WorkerCreateDto dto)
        {
            var worker = _mapper.Map<Worker>(dto);
            worker.CreateDate = DateTime.UtcNow.AddHours(4);
            worker.UpdateDate = DateTime.UtcNow.AddHours(4);
            bool check = false;

            if (dto.PositionIds != null)
            {
                foreach (var item in dto.PositionIds)
                {
                    if (!_appDb.Positions.Any(t => t.Id == item))
                    {
                        check = true;
                        break;
                    }

                }
            }

            if (check)
            {
               return BadRequest();
            }
            else
            {
                if (dto.PositionIds is not null)
                {
                    foreach (var item in dto.PositionIds)
                    {

                        WorkerPosition workerPosition = new WorkerPosition()
                        {
                            worker=worker,
                            positionId = item

                        };
                    }
                }
                _appDb.Workers.Add(worker);
            }
            if (dto.formFile != null && dto.formFile.Length < 1048576 &&
                !(dto.formFile.ContentType != "image/png" &&
                dto.formFile.ContentType != "image/jpeg"))
            {
                string fileNmae = Helperr.GetFileName(_env.WebRootPath, "upload", dto.formFile);

                string path = Path.Combine(_env.WebRootPath, "upload", worker.ImgUrl);
                worker.ImgUrl = fileNmae;
            }
            else return BadRequest();

            _appDb.Workers.Add(worker);
            _appDb.SaveChanges();
            return Ok(worker);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update([FromForm]WorkerUpdateDto dto)
        {
            var worker = _appDb.Workers.Find(dto.Id);
            if (worker == null) return NotFound();
            worker = _mapper.Map(dto, worker);
            worker.UpdateDate = DateTime.UtcNow.AddHours(4);
            bool check = false;

            if (dto.PositionIds != null)
            {
                foreach (var item in dto.PositionIds)
                {
                    if (!_appDb.Positions.Any(t => t.Id == item))
                    {
                        check = true;
                        break;
                    }

                }
            }

            if (check)
            {
                return BadRequest();
            }
            else
            {
                if (dto.PositionIds is not null)
                {
                    foreach (var item in dto.PositionIds)
                    {

                        WorkerPosition workerPosition = new WorkerPosition()
                        {
                            positionId = item

                        };
                    }
                }
                _appDb.Workers.Add(worker);
            }
            if (dto.formFile != null && dto.formFile.Length < 1048576 &&
                !(dto.formFile.ContentType != "image/png" &&
                dto.formFile.ContentType != "image/jpeg"))
            {
                string fileNmae = Helperr.GetFileName(_env.WebRootPath, "upload", dto.formFile);
                string path = Path.Combine(_env.WebRootPath, "upload", worker.ImgUrl);
                worker.ImgUrl = fileNmae;
            }
            else return BadRequest();
            _appDb.SaveChanges();
            return Ok(worker);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var worker = _appDb.Workers.Find(id);
            if (worker == null) return NotFound();
            worker.Isdeleted = !worker.Isdeleted;
            _appDb.SaveChanges();
            return NoContent();
        }
    }
}