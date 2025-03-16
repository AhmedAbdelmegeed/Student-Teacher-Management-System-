using Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public interface ICourseUseCase
    {
        Task<CourseDTO> GetCourseByIdAsync(Guid courseId);
        Task<List<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO> AddCourseAsync(CourseDTO courseDTO);
        Task<CourseDTO> UpdateCourseAsync(Guid courseId, CourseDTO updatedCourseDTO);
        Task<CourseDTO> AddTeacherToCourseAsync(Guid courseId, Guid teacherId);
        Task<CourseDTO> AddStudentToCourseAsync(Guid courseId, Guid studentId);
        Task<List<StudentDTO>> GetStudentsForCourseAsync(Guid courseId);
        Task<List<TeacherDTO>> GetTeachersForCourseAsync(Guid courseId);
        Task<bool> DeleteCourseAsync(Guid courseId);
        Task<CourseDTO> RemoveTeacherFromCourseAsync(Guid courseId, Guid teacherId);
        Task<CourseDTO> RemoveAllTeachersFromCourseAsync(Guid courseId);
        Task<CourseDTO> RemoveStudentFromCourseAsync(Guid courseId, Guid studentId);
        Task<CourseDTO> RemoveAllStudentsFromCourseAsync(Guid courseId);
    }
}
