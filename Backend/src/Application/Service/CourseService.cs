using Domain.Entity;
using Infrastructure.Repository;
using Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public CourseService(
            ICourseRepository courseRepository,
            ITeacherService teacherService,
            IStudentService studentService)
        {
            _courseRepository = courseRepository;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            return await _courseRepository
                .GetByIdAsync(courseId)
                ?? throw new InvalidOperationException("Course not found");
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return (await _courseRepository.GetAllAsync()).ToList();
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }

        public async Task<Course> UpdateCourseAsync(Guid courseId, Course updatedCourse)
        {
            var course = await GetCourseByIdAsync(courseId);

            if (updatedCourse.Name != null) course.Name = updatedCourse.Name;
            if (updatedCourse.Description != null) course.Description = updatedCourse.Description;
            if (updatedCourse.Credits > 0) course.Credits = updatedCourse.Credits;
            if (updatedCourse.CourseUrl != null) course.CourseUrl = updatedCourse.CourseUrl;
            if (updatedCourse.Duration > 0) course.Duration = updatedCourse.Duration;
            if (updatedCourse.Teachers != null && updatedCourse.Teachers.Any()) course.Teachers = updatedCourse.Teachers;
            if (updatedCourse.Students != null && updatedCourse.Students.Any()) course.Students = updatedCourse.Students;

            return await _courseRepository.AddAsync(course);
        }

        public async Task<Course> AddTeacherToCourseAsync(Guid courseId, Guid teacherId)
        {
            var course = await GetCourseByIdAsync(courseId);
            var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
            course.Teachers.Add(teacher);
            return await _courseRepository.AddAsync(course);
        }

        public async Task<Course> AddStudentToCourseAsync(Guid courseId, Guid studentId)
        {
            var course = await GetCourseByIdAsync(courseId);
            var student = await _studentService.GetStudentByIdAsync(studentId);
            course.Students.Add(student);
            return await _courseRepository.AddAsync(course);
        }

        public async Task<List<Student>> GetStudentsForCourseAsync(Guid courseId)
        {
            var course = await GetCourseByIdAsync(courseId);
            return course.Students.ToList();
        }

        public async Task<List<Teacher>> GetTeachersForCourseAsync(Guid courseId)
        {
            var course = await GetCourseByIdAsync(courseId);
            return course.Teachers.ToList();
        }

        public async Task<bool> DeleteCourseAsync(Guid courseId)
        {
            var course = await GetCourseByIdAsync(courseId);
            await _courseRepository.DeleteAsync(course);
            return true;
        }

        public async Task RemoveTeacherFromCourseAsync(Guid courseId, Guid teacherId)
        {
            var course = await GetCourseByIdAsync(courseId);
            var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
            course.Teachers.Remove(teacher);
            await _courseRepository.AddAsync(course);
        }

        public async Task RemoveAllTeachersFromCourseAsync(Guid courseId)
        {
            var course = await GetCourseByIdAsync(courseId);
            course.Teachers.Clear();
            await _courseRepository.AddAsync(course);
        }

        public async Task RemoveStudentFromCourseAsync(Guid courseId, Guid studentId)
        {
            var course = await GetCourseByIdAsync(courseId);
            var student = await _studentService.GetStudentByIdAsync(studentId);
            course.Students.Remove(student);
            await _courseRepository.AddAsync(course);
        }

        public async Task RemoveAllStudentsFromCourseAsync(Guid courseId)
        {
            var course = await GetCourseByIdAsync(courseId);
            course.Students.Clear();
            await _courseRepository.AddAsync(course);
        }
    }
}
