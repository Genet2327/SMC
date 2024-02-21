using AutoMapper;
using SMC_API.Dtos.Student;
using SMC_Entities;

namespace SMC_API.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
        }
    }
}
