using AutoMapper;
using Application.DTO;
using Domain.Entity;

namespace Application.Mapper
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
