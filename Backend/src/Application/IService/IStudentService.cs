using Domain.Entity;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(Guid studentId);
    Task<List<Student>> GetAllStudentsAsync();
    Task<Student> AddStudentAsync(Student student);
    Task<Student> UpdateStudentAsync(Guid studentId, Student student);
    Task DeleteStudentAsync(Guid studentId);
    Task<List<Course>> GetStudentCoursesAsync(Guid studentId);
    Task<List<Teacher>> GetStudentTeachersAsync(Guid studentId);
    Task<Student> AddCourseToStudentAsync(Guid studentId, Guid courseId);
    Task RemoveCourseFromStudentAsync(Guid studentId, Guid courseId);
    Task RemoveAllCoursesFromStudentAsync(Guid studentId);
}
