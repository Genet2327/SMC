using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SMC_API.Models.Role;

namespace SMC_API.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleReadDto>();
            CreateMap<RoleCreateDto, IdentityRole>();
            CreateMap<RoleUpdateDto, IdentityRole>();
            CreateMap<IdentityRole, RoleUpdateDto>();
        }
    }
}
