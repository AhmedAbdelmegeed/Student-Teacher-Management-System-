using AutoMapper;
using Application.DTO;
using Domain.Entity;
using Application.Service;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class StudentUseCase : IStudentUseCase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        // Constructor injection of required services and AutoMapper
        public StudentUseCase(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // Get student by ID
        public async Task<StudentDTO> GetStudentById(Guid studentId)
        {
            var student = await _studentService.GetStudentByIdAsync(studentId);
            return _mapper.Map<StudentDTO>(student);
        }

        // Get all students
        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return students.Select(student => _mapper.Map<StudentDTO>(student)).ToList();
        }

        // Add a new student
        public async Task<StudentDTO> AddStudent(StudentDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            var addedStudent = await _studentService.AddStudentAsync(student);
            return _mapper.Map<StudentDTO>(addedStudent);
        }

        // Update student
        public async Task<StudentDTO> UpdateStudent(Guid studentId, StudentDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            var updatedStudent = await _studentService.UpdateStudentAsync(studentId, student);
            return _mapper.Map<StudentDTO>(updatedStudent);
        }

        // Delete student
        public async Task DeleteStudent(Guid studentId)
        {
            await _studentService.DeleteStudentAsync(studentId);
        }

        // Get student's teachers
        public async Task<IEnumerable<TeacherDTO>> GetStudentTeachers(Guid studentId)
        {
            var teachers = await _studentService.GetStudentTeachersAsync(studentId);
            return teachers.Select(teacher => _mapper.Map<TeacherDTO>(teacher)).ToList();
        }

        // Add a course to student
        public async Task<StudentDTO> AddCourseToStudent(Guid studentId, Guid courseId)
        {
            var student = await _studentService.AddCourseToStudentAsync(studentId, courseId);
            return _mapper.Map<StudentDTO>(student);
        }

        // Remove a course from student
        public async Task RemoveCourseFromStudent(Guid studentId, Guid courseId)
        {
            await _studentService.RemoveCourseFromStudentAsync(studentId, courseId);
        }

        // Remove all courses from student
        public async Task RemoveAllCoursesFromStudent(Guid studentId)
        {
            await _studentService.RemoveAllCoursesFromStudentAsync(studentId);
        }
    }
}
