using Application.DTO;
using AutoMapper;
using Domain.Entity;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.Major))
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses)); // Handle Many-to-Many

        CreateMap<StudentDTO, Student>()
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.Major))
            .ForMember(dest => dest.Courses, opt => opt.Ignore()) // Ignore direct mapping
            .AfterMap((dto, student, ctx) =>
            {
                student.Courses = dto.Courses?.Select(c => ctx.Mapper.Map<Course>(c)).ToList() ?? new List<Course>();
            });

        CreateMap<Course, CourseDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
    }
}
