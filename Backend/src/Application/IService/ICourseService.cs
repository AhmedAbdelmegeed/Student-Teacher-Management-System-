using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Service
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(Guid courseId);
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> AddCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(Guid courseId, Course updatedCourse);
        Task<Course> AddTeacherToCourseAsync(Guid courseId, Guid teacherId);
        Task<Course> AddStudentToCourseAsync(Guid courseId, Guid studentId);
        Task<List<Student>> GetStudentsForCourseAsync(Guid courseId);
        Task<List<Teacher>> GetTeachersForCourseAsync(Guid courseId);
        Task<bool> DeleteCourseAsync(Guid courseId);
        Task RemoveTeacherFromCourseAsync(Guid courseId, Guid teacherId);
        Task RemoveAllTeachersFromCourseAsync(Guid courseId);
        Task RemoveStudentFromCourseAsync(Guid courseId, Guid studentId);
        Task RemoveAllStudentsFromCourseAsync(Guid courseId);
    }
}
