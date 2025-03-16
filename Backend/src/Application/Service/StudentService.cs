using Domain.Entity;
using Application.Service;
using Infrastructure.Repository;

public class StudentService : IStudentService
{
    private readonly IStudentRepository studentRepository;
    private readonly ICourseRepository courseRepository;

    public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
    {
        this.studentRepository = studentRepository;
        this.courseRepository = courseRepository;
    }

    public async Task<Student> GetStudentByIdAsync(Guid studentId)
    {
        var student = await studentRepository.GetByIdAsync(studentId);
        if (student == null)
        {
            throw new Exception("Student not found");
        }
        return student;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return (await studentRepository.GetAllAsync()).ToList();
    }

    public async Task<Student> AddStudentAsync(Student student)
    {
        return await studentRepository.AddAsync(student);
    }

    public async Task<Student> UpdateStudentAsync(Guid studentId, Student student)
    {
        var existingStudent = await GetStudentByIdAsync(studentId);

        if (student.Major != null)
        {
            existingStudent.Major = student.Major;
        }

        if (student.User != null)
        {
            existingStudent.User = student.User;
        }

        return await studentRepository.AddAsync(existingStudent);
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var student = await studentRepository.GetByIdAsync(studentId);
        await studentRepository.DeleteAsync(student);
    }

    public async Task<List<Course>> GetStudentCoursesAsync(Guid studentId)
    {
        var student = await GetStudentByIdAsync(studentId);
        return student.Courses.ToList();
    }

    public async Task<List<Teacher>> GetStudentTeachersAsync(Guid studentId)
    {
        var studentCourses = await GetStudentCoursesAsync(studentId);
        var studentTeachers = new List<Teacher>();
        var teacherIds = new HashSet<Guid>();

        foreach (var course in studentCourses)
        {
            foreach (var teacher in course.Teachers)
            {
                if (!teacherIds.Contains(teacher.TeacherId))
                {
                    teacherIds.Add(teacher.TeacherId);
                    studentTeachers.Add(teacher);
                }
            }
        }

        return studentTeachers;
    }

    public async Task<Student> AddCourseToStudentAsync(Guid studentId, Guid courseId)
    {
        var student = await GetStudentByIdAsync(studentId);
        var course = await courseRepository.GetByIdAsync(courseId);

        if (course == null)
        {
            throw new Exception("Course not found");
        }

        student.Courses.Add(course);
        return await studentRepository.AddAsync(student);
    }

    public async Task RemoveCourseFromStudentAsync(Guid studentId, Guid courseId)
    {
        var student = await GetStudentByIdAsync(studentId);
        var course = await courseRepository.GetByIdAsync(courseId);

        if (course == null)
        {
            throw new Exception("Course not found");
        }

        student.Courses.Remove(course);
        await studentRepository.AddAsync(student);
    }

    public async Task RemoveAllCoursesFromStudentAsync(Guid studentId)
    {
        var student = await GetStudentByIdAsync(studentId);
        student.Courses.Clear();
        await studentRepository.AddAsync(student);
    }
}
