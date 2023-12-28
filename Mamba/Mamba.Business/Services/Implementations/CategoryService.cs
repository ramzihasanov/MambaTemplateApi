using AutoMapper;
using Mamba.Business.Services.Interfaces;
using Mamba.Core.Repositories.Interfaces;
using Mamba.DAL;
using Mamba.DTOs.CategoryDto;
using Mamba.Entites;

namespace Mamba.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbConrtext _appDb;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(AppDbConrtext appDb,IMapper mapper,ICategoryRepository categoryRepository)
        {
            this._appDb = appDb;
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }
        public  async Task CreateAsync(CategoryCreateDto dto)
        {
            if (dto == null) throw new Exception();

            Category category = _mapper.Map<Category>(dto);
            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.CommitAsync();

        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            if (category == null) throw new Exception();

            _categoryRepository.DeleteAsync(category);
            await _categoryRepository.CommitAsync();
        }

        public async Task<List<CategoryGetDto>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            if(category == null) throw new Exception();
            return _mapper.Map<List<CategoryGetDto>>(category);
        }

        public async Task<CategoryGetDto> GetByIdAsync(int? id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            if (category == null) throw new Exception();
            CategoryGetDto categorydto = _mapper.Map<CategoryGetDto>(category);
            return categorydto;
        }

        public async Task UpdateAsync( CategoryUpdateDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (category == null) throw new Exception();

            category = _mapper.Map(dto, category);
            await _categoryRepository.CommitAsync();
        }
    }
}
