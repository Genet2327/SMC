using AutoMapper;
using SMC_API.Dtos.Attendance;
using SMC_Entities.Models;

namespace SMC_API.Profiles
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Attendance, AttendanceReadDto>();
            CreateMap<AttendanceCreateDto, Attendance>();
            CreateMap<AttendanceUpdateDto, Attendance>();
            CreateMap<Attendance, AttendanceUpdateDto>();
        }
    }
}
