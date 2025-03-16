using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Application.DTO;
using Application.Service;

namespace Application.UseCase
{
    public class TeacherUseCase : ITeacherUseCase
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public TeacherUseCase(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public async Task<TeacherDTO> GetTeacherByIdAsync(Guid teacherId)
        {
            var teacher = await teacherService.GetTeacherByIdAsync(teacherId);
            return mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<List<TeacherDTO>> GetAllTeachersAsync()
        {
            var teachers = await teacherService.GetAllTeachersAsync();
            return teachers.Select(t => mapper.Map<TeacherDTO>(t)).ToList();
        }

        public async Task<TeacherDTO> AddTeacherAsync(TeacherDTO teacherDTO)
        {
            var teacher = mapper.Map<Teacher>(teacherDTO);
            var addedTeacher = await teacherService.AddTeacherAsync(teacher);
            return mapper.Map<TeacherDTO>(addedTeacher);
        }

        public async Task<TeacherDTO> UpdateTeacherAsync(Guid teacherId, TeacherDTO teacherDTO)
        {
            var teacher = mapper.Map<Teacher>(teacherDTO);
            var updatedTeacher = await teacherService.UpdateTeacherAsync(teacherId, teacher);
            return mapper.Map<TeacherDTO>(updatedTeacher);
        }

        public async Task DeleteTeacherAsync(Guid teacherId)
        {
            await teacherService.DeleteTeacherAsync(teacherId);
        }

        public async Task<List<StudentDTO>> GetTeacherStudentsAsync(Guid teacherId)
        {
            var students = await teacherService.GetTeacherStudentsAsync(teacherId);
            return students.Select(s => mapper.Map<StudentDTO>(s)).ToList();
        }

        public async Task AddCourseToTeacherAsync(Guid teacherId, Guid courseId)
        {
            await teacherService.AddCourseToTeacherAsync(teacherId, courseId);
        }

        public async Task RemoveCourseFromTeacherAsync(Guid teacherId, Guid courseId)
        {
            await teacherService.RemoveCourseFromTeacherAsync(teacherId, courseId);
        }

        public async Task RemoveAllCoursesFromTeacherAsync(Guid teacherId)
        {
            await teacherService.RemoveAllCoursesFromTeacherAsync(teacherId);
        }
    }
}
