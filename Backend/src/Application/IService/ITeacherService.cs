using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Service
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherByIdAsync(Guid teacherId);
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher> AddTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(Guid teacherId, Teacher teacher);
        Task DeleteTeacherAsync(Guid teacherId);
        Task<List<Student>> GetTeacherStudentsAsync(Guid teacherId);
        Task AddCourseToTeacherAsync(Guid teacherId, Guid courseId);
        Task RemoveCourseFromTeacherAsync(Guid teacherId, Guid courseId);
        Task RemoveAllCoursesFromTeacherAsync(Guid teacherId);
    }
}
