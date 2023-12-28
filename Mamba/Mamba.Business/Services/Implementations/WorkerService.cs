
using AutoMapper.Execution;
using AutoMapper;
using Mamba.Business.Services.Interfaces;
using Mamba.DTOs.WorkerDto;
using Microsoft.AspNetCore.Mvc;
using Mamba.DAL;
using Mamba.Core.Repositories.Interfaces;
using Mamba.Entites;
using Mamba.Helpers;
using Microsoft.AspNetCore.Hosting;
using static Humanizer.On;
using Mamba.DTOs.PositionDto;

namespace Mamba.Business.Services.Implementations
{
    public class WorkerService : IWorkerService
    {
        private readonly AppDbConrtext _appDb;
        private readonly IMapper _mapper;
        private readonly IWorkerRepository _workerRepository;
        private readonly IWebHostEnvironment env;

        public WorkerService(AppDbConrtext appDb, IMapper mapper, IWorkerRepository workerRepository,IWebHostEnvironment env)
        {

            _appDb = appDb;

            _mapper = mapper;

            _workerRepository = workerRepository;
            this.env = env;
        }
        public async Task CreateAsync([FromForm] WorkerCreateDto dto)
        {
            Worker worker = _mapper.Map<Worker>(dto);
            var check=false;
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
               throw new Exception();
            }
            else
            {
                if (dto.PositionIds is not null)
                {
                    foreach (var item in dto.PositionIds)
                    {

                        WorkerPosition workerPosition = new WorkerPosition()
                        {
                            worker = worker,
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
                string fileNmae = Helperr.GetFileName(env.WebRootPath, "upload", dto.formFile);
                worker.ImgUrl = fileNmae;
            }
            else throw new Exception();
            await _workerRepository.CreateAsync(worker);
            await _workerRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var worker = await _workerRepository.GetByIdAsync(x => x.Id == id);
            if (worker == null) throw new Exception();

            _workerRepository.DeleteAsync(worker);
            await _workerRepository.CommitAsync();
        }

        public async Task<List<WorkerGetDto>> GetAllAsync(string? search, int? categoryId, int? order)
        {
            var workers = _appDb.Workers.AsQueryable();
            if (search != null)
            {
                workers = workers.Where(x => x.FullName.ToLower().Contains(search.Trim().ToLower()));
            }
            if (categoryId != null)
            {
                workers = workers.Where(x => x.categoryId == categoryId);
            }
            if (order != null)
            {
                switch (order)
                {
                    case 0:
                        workers = workers.OrderByDescending(x => x.CreateDate);
                        break;
                    case 1:
                        workers = workers.OrderByDescending(x => x.FullName);
                        break;
                    default:
                        break;
                }
            }

            return workers.Select(workers => _mapper.Map<WorkerGetDto>(workers)).ToList();
        }

        public async Task<List<WorkerGetDto>> GetAllAsync()
        {
            var workers = await _workerRepository.GetAllAsync();
            if(workers== null) throw new Exception();
            return _mapper.Map<List<WorkerGetDto>>(workers);
        }

        public async Task<WorkerGetDto> GetByIdAsync(int? id)
        {
            var worker = await _workerRepository.GetByIdAsync(x => x.Id == id);
            if (worker == null) throw new Exception();
            WorkerGetDto workerdto = _mapper.Map<WorkerGetDto>(worker);
            return workerdto;
        }

        public async Task UpdateAsync(WorkerUpdateDto dto)
        {
            var worker = await _workerRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (worker == null) throw new Exception();

            worker = _mapper.Map(dto, worker);


            var check = false;
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
                throw new Exception();
            }
            else
            {
                if (dto.PositionIds is not null)
                {
                    foreach (var item in dto.PositionIds)
                    {

                        WorkerPosition workerPosition = new WorkerPosition()
                        {
                            worker = worker,
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
                string fileNmae = Helperr.GetFileName(env.WebRootPath, "upload", dto.formFile);
                worker.ImgUrl = fileNmae;
            }
            else throw new Exception();
            await _workerRepository.CommitAsync();
        }
    }
}
