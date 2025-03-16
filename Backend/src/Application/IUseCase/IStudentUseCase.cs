using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.UseCase
{
    public interface IStudentUseCase
    {
        Task<StudentDTO> GetStudentById(Guid studentId);
        Task<IEnumerable<StudentDTO>> GetAllStudents();
        Task<StudentDTO> AddStudent(StudentDTO studentDTO);
        Task<StudentDTO> UpdateStudent(Guid studentId, StudentDTO studentDTO);
        Task DeleteStudent(Guid studentId);
        Task<IEnumerable<TeacherDTO>> GetStudentTeachers(Guid studentId);
        Task<StudentDTO> AddCourseToStudent(Guid studentId, Guid courseId);
        Task RemoveCourseFromStudent(Guid studentId, Guid courseId);
        Task RemoveAllCoursesFromStudent(Guid studentId);
    }
}
