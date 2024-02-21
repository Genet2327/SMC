using AutoMapper;
using SMC_API.Dtos.Section;
using SMC_Entities.Models;

namespace SMC_API.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionReadDto>();
            CreateMap<SectionCreateDto, Section>();
            CreateMap<SectionUpdateDto, Section>();
            CreateMap<Section, SectionUpdateDto>();
        }
    }
}
