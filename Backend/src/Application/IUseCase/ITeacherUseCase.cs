using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.UseCase
{
    public interface ITeacherUseCase
    {
        Task<TeacherDTO> GetTeacherByIdAsync(Guid teacherId);
        Task<List<TeacherDTO>> GetAllTeachersAsync();
        Task<TeacherDTO> AddTeacherAsync(TeacherDTO teacherDTO);
        Task<TeacherDTO> UpdateTeacherAsync(Guid teacherId, TeacherDTO teacherDTO);
        Task DeleteTeacherAsync(Guid teacherId);
        Task<List<StudentDTO>> GetTeacherStudentsAsync(Guid teacherId);
        Task AddCourseToTeacherAsync(Guid teacherId, Guid courseId);
        Task RemoveCourseFromTeacherAsync(Guid teacherId, Guid courseId);
        Task RemoveAllCoursesFromTeacherAsync(Guid teacherId);
    }
}
