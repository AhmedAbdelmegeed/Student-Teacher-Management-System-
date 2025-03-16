using AutoMapper;
using Application.DTO;
using Domain.Entity;
using Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class CourseUseCase : ICourseUseCase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseUseCase(
            ICourseService courseService,
            IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public async Task<CourseDTO> GetCourseByIdAsync(Guid courseId)
        {
            var course = await _courseService.GetCourseByIdAsync(courseId);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<List<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return _mapper.Map<List<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> AddCourseAsync(CourseDTO courseDTO)
        {
            var courseEntity = _mapper.Map<Course>(courseDTO);
            var addedCourse = await _courseService.AddCourseAsync(courseEntity);
            return _mapper.Map<CourseDTO>(addedCourse);
        }

        public async Task<CourseDTO> UpdateCourseAsync(Guid courseId, CourseDTO updatedCourseDTO)
        {
            var courseEntity = _mapper.Map<Course>(updatedCourseDTO);
            var updatedCourse = await _courseService.UpdateCourseAsync(courseId, courseEntity);
            return _mapper.Map<CourseDTO>(updatedCourse);
        }

        public async Task<CourseDTO> AddTeacherToCourseAsync(Guid courseId, Guid teacherId)
        {
            var updatedCourse = await _courseService.AddTeacherToCourseAsync(courseId, teacherId);
            return _mapper.Map<CourseDTO>(updatedCourse);
        }

        public async Task<CourseDTO> AddStudentToCourseAsync(Guid courseId, Guid studentId)
        {
            var updatedCourse = await _courseService.AddStudentToCourseAsync(courseId, studentId);
            return _mapper.Map<CourseDTO>(updatedCourse);
        }

        public async Task<List<StudentDTO>> GetStudentsForCourseAsync(Guid courseId)
        {
            var students = await _courseService.GetStudentsForCourseAsync(courseId);
            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task<List<TeacherDTO>> GetTeachersForCourseAsync(Guid courseId)
        {
            var teachers = await _courseService.GetTeachersForCourseAsync(courseId);
            return _mapper.Map<List<TeacherDTO>>(teachers);
        }

        public async Task<bool> DeleteCourseAsync(Guid courseId)
        {
            return await _courseService.DeleteCourseAsync(courseId);
        }

        public async Task<CourseDTO> RemoveTeacherFromCourseAsync(Guid courseId, Guid teacherId)
        {
            await _courseService.RemoveTeacherFromCourseAsync(courseId, teacherId);
            var course = await _courseService.GetCourseByIdAsync(courseId);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> RemoveAllTeachersFromCourseAsync(Guid courseId)
        {
            await _courseService.RemoveAllTeachersFromCourseAsync(courseId);
            var course = await _courseService.GetCourseByIdAsync(courseId);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> RemoveStudentFromCourseAsync(Guid courseId, Guid studentId)
        {
            await _courseService.RemoveStudentFromCourseAsync(courseId, studentId);
            var course = await _courseService.GetCourseByIdAsync(courseId);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> RemoveAllStudentsFromCourseAsync(Guid courseId)
        {
            await _courseService.RemoveAllStudentsFromCourseAsync(courseId);
            var course = await _courseService.GetCourseByIdAsync(courseId);
            return _mapper.Map<CourseDTO>(course);
        }
    }
}
