using Mamba.DTOs.WorkerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Business.Services.Interfaces
{
    public interface IWorkerService
    {
        Task CreateAsync(WorkerCreateDto dto);
        Task Delete(int id);
        Task<WorkerGetDto> GetByIdAsync(int? id);
        Task<List<WorkerGetDto>> GetAllAsync();
        Task UpdateAsync(WorkerUpdateDto dto);
    }
}

