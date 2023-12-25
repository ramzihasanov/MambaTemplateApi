using AutoMapper;
using Mamba.DTOs.PositionDto;
using Mamba.DTOs.WorkerDto;
using Mamba.Entites;

namespace Mamba.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<WorkerGetDto, Worker>().ReverseMap();
            CreateMap<WorkerCreateDto, Worker>().ReverseMap();
            CreateMap<WorkerUpdateDto, Worker>().ReverseMap();

            CreateMap<PositionCreateDto, Position>().ReverseMap();
            CreateMap<PositionGetDto, Position>().ReverseMap();
            CreateMap<PositionUpdateDto, Position>().ReverseMap();

        }
    }
}
