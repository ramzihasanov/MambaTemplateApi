using Mamba.DTOs.PositionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Business.Services.Interfaces
{
    public interface IPositionService
    {
        Task CreateAsync(PositionCreateDto dto);
        Task Delete(int id);
        Task<PositionGetDto> GetByIdAsync(int? id);
        Task<List<PositionGetDto>> GetAllAsync();
        Task UpdateAsync(PositionUpdateDto dto);

    }
}
