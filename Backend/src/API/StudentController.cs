using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCase;

namespace Application.Controller
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentUseCase _studentUseCase;

        // Constructor injection of StudentUseCase
        public StudentController(IStudentUseCase studentUseCase)
        {
            _studentUseCase = studentUseCase;
        }

        // Get student by ID
        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(Guid studentId)
        {
            var student = await _studentUseCase.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // Get all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            var students = await _studentUseCase.GetAllStudents();
            return Ok(students);
        }

        // Add a new student
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> AddStudent([FromBody] StudentDTO studentDTO)
        {
            var createdStudent = await _studentUseCase.AddStudent(studentDTO);
            return CreatedAtAction(nameof(GetStudent), new { studentId = createdStudent.Id }, createdStudent);
        }

        // Update student
        [HttpPut("{studentId}")]
        public async Task<ActionResult<StudentDTO>> UpdateStudent(Guid studentId, [FromBody] StudentDTO studentDTO)
        {
            var updatedStudent = await _studentUseCase.UpdateStudent(studentId, studentDTO);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(updatedStudent);
        }

        // Delete student
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            await _studentUseCase.DeleteStudent(studentId);
            return Ok();
        }

        // Add course to student
        [HttpPost("{studentId}/courses/{courseId}")]
        public async Task<ActionResult<StudentDTO>> AddCourseToStudent(Guid studentId, Guid courseId)
        {
            var updatedStudent = await _studentUseCase.AddCourseToStudent(studentId, courseId);
            return Ok(updatedStudent);
        }

        // Remove course from student
        [HttpDelete("{studentId}/courses/{courseId}")]
        public async Task<IActionResult> RemoveCourseFromStudent(Guid studentId, Guid courseId)
        {
            await _studentUseCase.RemoveCourseFromStudent(studentId, courseId);
            return NoContent();
        }

        // Remove all courses from student
        [HttpDelete("{studentId}/courses")]
        public async Task<IActionResult> RemoveAllCoursesFromStudent(Guid studentId)
        {
            await _studentUseCase.RemoveAllCoursesFromStudent(studentId);
            return NoContent();
        }
    }
}
