using Application.DTO;
using AutoMapper;
using Domain.Entity;
using System.Linq;

namespace Application.Mapper
{
    public class TeacherMapperProfile : Profile
    {
        public TeacherMapperProfile()
        {
            CreateMap<Teacher, TeacherDTO>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses))
                .ReverseMap()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Courses, opt => opt.Ignore())
                .AfterMap((dto, teacher, ctx) =>
                {
                    teacher.Courses = dto.Courses?.Select(c => ctx.Mapper.Map<Course>(c)).ToList() ?? new List<Course>();
                });
        }
    }
}
