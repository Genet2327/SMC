using AutoMapper;
using SMC_API.Dtos.Exam;
using SMC_Entities.Models;

namespace SMC_API.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamReadDto>();
            CreateMap<ExamCreateDto, Exam>();
            CreateMap<ExamUpdateDto, Exam>();
            CreateMap<Exam, ExamUpdateDto>();
        }
    }
}
