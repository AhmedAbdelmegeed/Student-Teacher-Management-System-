using AutoMapper;
using Application.DTO;
using Domain.Entity;
using System.Linq;

namespace Application.Mapper
{
    public class CourseMapperProfile : Profile
    {
        public CourseMapperProfile()
        {
            CreateMap<Course, CourseDTO>()
                .ForMember(dest => dest.StudentIds, opt => opt.MapFrom(src => src.Students.Select(cs => cs.StudentId)))
                .ForMember(dest => dest.TeacherIds, opt => opt.MapFrom(src => src.Teachers.Select(ct => ct.TeacherId)))
                .ReverseMap();
        }
    }
}
