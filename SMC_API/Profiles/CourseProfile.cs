using AutoMapper;
using SMC_API.Dtos.Course;
using SMC_Entities.Models;

namespace SMC_API.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseReadDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseUpdateDto>();
        }
    }
}
