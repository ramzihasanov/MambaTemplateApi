using AutoMapper;
using Mamba.Business.Services.Interfaces;
using Mamba.Core.Repositories.Interfaces;
using Mamba.DAL;
using Mamba.Data.Repositories.Implementations;
using Mamba.DTOs.CategoryDto;
using Mamba.DTOs.PositionDto;
using Mamba.Entites;

namespace Mamba.Business.Services.Implementations
{
    public class PositionService : IPositionService
    {
        private readonly AppDbConrtext appDb;
        private readonly IMapper mapper;
        private readonly IPositionRepository positionRepository;

        public PositionService(AppDbConrtext appDb,IMapper mapper, IPositionRepository positionRepository)
        {
            this.appDb = appDb;
            this.mapper = mapper;
            this.positionRepository = positionRepository;
        }
        public async Task CreateAsync(PositionCreateDto dto)
        {
            if (dto == null) throw new Exception();

            Position pos = mapper.Map<Position>(dto);
            await positionRepository.CreateAsync(pos);
            await positionRepository.CommitAsync();

        }

        public async Task Delete(int id)
        {
            var pos = await positionRepository.GetByIdAsync(x => x.Id == id);
            if (pos == null) throw new Exception();

            positionRepository.DeleteAsync(pos);
            await positionRepository.CommitAsync();
        }

        public async Task<List<PositionGetDto>> GetAllAsync()
        {
            var pos = await positionRepository.GetAllAsync();
            if (pos == null) throw new Exception();
            return mapper.Map<List<PositionGetDto>>(pos);
        }

        public async Task<PositionGetDto> GetByIdAsync(int? id)
        {
            var pos = await positionRepository.GetByIdAsync(x => x.Id == id);
            if (pos == null) throw new Exception();
            PositionGetDto posdto = mapper.Map<PositionGetDto>(pos);
            return posdto;
        }

        public async Task UpdateAsync(PositionUpdateDto dto)
        {
            var pos = await positionRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (pos == null) throw new Exception();

            pos = mapper.Map(dto, pos);
            await positionRepository.CommitAsync();
        }
    }
}
