using AutoMapper;
using SMC_API.Dtos.Result;
using SMC_Entities.Models;

namespace SMC_API.Profiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultReadDto>();
            CreateMap<ResultCreateDto, Result>();
            CreateMap<ResultUpdateDto, Result>();
            CreateMap<Result, ResultUpdateDto>();
        }
    }
}
