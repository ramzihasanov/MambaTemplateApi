using Mamba.DTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto dto);
        Task Delete(int id);
        Task<CategoryGetDto> GetByIdAsync(int? id);
        Task<List<CategoryGetDto>> GetAllAsync();
        Task UpdateAsync(CategoryUpdateDto dto);
    }
}

