using AutoMapper;
using SMC_API.Dtos.ClassRoom;
using SMC_API.Dtos.Student;
using SMC_Entities.Models;
using SMC_Entities.ViewModel;

namespace SMC_API.Profiles
{
    public class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<ClassRoom, ClassRoomReadDto>();
            CreateMap<StudentRedByClassRoomNumberVm, StudentRedByClassRoomNumberDto>();
            CreateMap<ClassRoomCreateDto, ClassRoom>();
            CreateMap<ClassRoomUpdateDto, ClassRoom>();
            CreateMap<ClassRoom, ClassRoomUpdateDto>();
        }
    }
}
