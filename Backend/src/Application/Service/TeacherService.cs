using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Infrastructure.Repository;

namespace Application.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly ICourseRepository courseRepository;

        public TeacherService(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<Teacher> GetTeacherByIdAsync(Guid teacherId)
        {
            var teacher = await teacherRepository.GetByIdAsync(teacherId);
            if (teacher == null)
                throw new Exception("Teacher not found");
            return teacher;
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return (await teacherRepository.GetAllAsync()).ToList();
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            return await teacherRepository.AddAsync(teacher);
        }

        public async Task<Teacher> UpdateTeacherAsync(Guid teacherId, Teacher teacher)
        {
            var existingTeacher = await GetTeacherByIdAsync(teacherId);

            if (teacher.User != null)
                existingTeacher.User = teacher.User;

            if (teacher.HireDate != null)
                existingTeacher.HireDate = teacher.HireDate;

            return await teacherRepository.UpdateAsync(existingTeacher);
        }

        public async Task DeleteTeacherAsync(Guid teacherId)
        {
            var teacher = await teacherRepository.GetByIdAsync(teacherId);
            await teacherRepository.DeleteAsync(teacher);
        }

        public async Task<List<Student>> GetTeacherStudentsAsync(Guid teacherId)
        {
            var teacherCourses = await GetTeacherCoursesAsync(teacherId);
            var teacherStudents = new HashSet<Student>();

            foreach (var course in teacherCourses)
            {
                var courseStudents = course.Students;
                foreach (var student in courseStudents)
                {
                    teacherStudents.Add(student);
                }
            }

            return teacherStudents.ToList();
        }

        public async Task AddCourseToTeacherAsync(Guid teacherId, Guid courseId)
        {
            var teacher = await GetTeacherByIdAsync(teacherId);
            var course = await courseRepository.GetByIdAsync(courseId);

            if (course == null)
                throw new Exception("Course not found");

            teacher.Courses.Add(course);
            await teacherRepository.UpdateAsync(teacher);
        }

        public async Task RemoveCourseFromTeacherAsync(Guid teacherId, Guid courseId)
        {
            var teacher = await GetTeacherByIdAsync(teacherId);
            var course = await courseRepository.GetByIdAsync(courseId);

            if (course == null)
                throw new Exception("Course not found");

            teacher.Courses.Remove(course);
            await teacherRepository.UpdateAsync(teacher);
        }

        public async Task RemoveAllCoursesFromTeacherAsync(Guid teacherId)
        {
            var teacher = await GetTeacherByIdAsync(teacherId);
            teacher.Courses.Clear();
            await teacherRepository.UpdateAsync(teacher);
        }

        private async Task<List<Course>> GetTeacherCoursesAsync(Guid teacherId)
        {
            var teacher = await GetTeacherByIdAsync(teacherId);
            return teacher.Courses.ToList();
        }
    }
}
