using AutoMapper;
using SMC_API.Dtos.Quote;
using SMC_API.Dtos.Result;
using SMC_Entities.Models;

namespace SMC_API.Profiles
{
    public class QuoteProfile : Profile 
    {
        public QuoteProfile() {
            CreateMap<Quote, QuoteReadDto>();
            CreateMap<QuoteCreateDto, Quote>();
            CreateMap<QuoteUpdateDto, Quote>();
            CreateMap<Quote, QuoteUpdateDto>();
        }
    }
}
