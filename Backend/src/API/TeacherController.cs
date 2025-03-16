using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCase;

namespace Application.Controller
{
    [ApiController]
    [Route("api/teacher")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherUseCase teacherUseCase;

        public TeacherController(ITeacherUseCase teacherUseCase)
        {
            this.teacherUseCase = teacherUseCase;
        }

        [HttpGet("{teacherId}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacherById(Guid teacherId)
        {
            var teacher = await teacherUseCase.GetTeacherByIdAsync(teacherId);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherDTO>>> GetAllTeachers()
        {
            var teachers = await teacherUseCase.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> AddTeacher([FromBody] TeacherDTO teacherDTO)
        {
            var addedTeacher = await teacherUseCase.AddTeacherAsync(teacherDTO);
            return CreatedAtAction(nameof(GetTeacherById), new { teacherId = addedTeacher.TeacherId }, addedTeacher);
        }

        [HttpPut("{teacherId}")]
        public async Task<ActionResult<TeacherDTO>> UpdateTeacher(Guid teacherId, [FromBody] TeacherDTO teacherDTO)
        {
            var updatedTeacher = await teacherUseCase.UpdateTeacherAsync(teacherId, teacherDTO);
            if (updatedTeacher == null)
            {
                return NotFound();
            }
            return Ok(updatedTeacher);
        }

        [HttpDelete("{teacherId}")]
        public async Task<ActionResult> DeleteTeacher(Guid teacherId)
        {
            await teacherUseCase.DeleteTeacherAsync(teacherId);
            return Ok();
        }

        [HttpGet("{teacherId}/students")]
        public async Task<ActionResult<List<StudentDTO>>> GetTeacherStudents(Guid teacherId)
        {
            var students = await teacherUseCase.GetTeacherStudentsAsync(teacherId);
            return Ok(students);
        }

        [HttpPost("{teacherId}/courses/{courseId}")]
        public async Task<ActionResult> AddCourseToTeacher(Guid teacherId, Guid courseId)
        {
            await teacherUseCase.AddCourseToTeacherAsync(teacherId, courseId);
            return NoContent();
        }

        [HttpDelete("{teacherId}/courses/{courseId}")]
        public async Task<ActionResult> RemoveCourseFromTeacher(Guid teacherId, Guid courseId)
        {
            await teacherUseCase.RemoveCourseFromTeacherAsync(teacherId, courseId);
            return NoContent();
        }

        [HttpDelete("{teacherId}/courses")]
        public async Task<ActionResult> RemoveAllCoursesFromTeacher(Guid teacherId)
        {
            await teacherUseCase.RemoveAllCoursesFromTeacherAsync(teacherId);
            return NoContent();
        }
    }
}
