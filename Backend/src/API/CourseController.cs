using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.UseCase;

namespace Application.Controller
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseUseCase _courseUseCase;

        public CourseController(ICourseUseCase courseUseCase)
        {
            _courseUseCase = courseUseCase;
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseDTO>> GetCourseByIdAsync(Guid courseId)
        {
            var course = await _courseUseCase.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> GetAllCoursesAsync()
        {
            var courses = await _courseUseCase.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDTO>> AddCourseAsync([FromBody] CourseDTO courseDTO)
        {
            var course = await _courseUseCase.AddCourseAsync(courseDTO);
            return CreatedAtAction(nameof(GetCourseByIdAsync), new { courseId = course.CourseId }, course);
        }

        [HttpPut("{courseId}")]
        public async Task<ActionResult<CourseDTO>> UpdateCourseAsync(Guid courseId, [FromBody] CourseDTO updatedCourseDTO)
        {
            var updatedCourse = await _courseUseCase.UpdateCourseAsync(courseId, updatedCourseDTO);
            if (updatedCourse == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(updatedCourse);
        }

        [HttpPost("{courseId}/teachers/{teacherId}")]
        public async Task<ActionResult<CourseDTO>> AddTeacherToCourseAsync(Guid courseId, Guid teacherId)
        {
            var course = await _courseUseCase.AddTeacherToCourseAsync(courseId, teacherId);
            if (course == null)
            {
                return NotFound("Course or Teacher not found.");
            }
            return Ok(course);
        }

        [HttpPost("{courseId}/student/{studentId}")]
        public async Task<ActionResult<CourseDTO>> AddStudentToCourseAsync(Guid courseId, Guid studentId)
        {
            var course = await _courseUseCase.AddStudentToCourseAsync(courseId, studentId);
            if (course == null)
            {
                return NotFound("Course or Student not found.");
            }
            return Ok(course);
        }

        [HttpGet("{courseId}/student")]
        public async Task<ActionResult<List<StudentDTO>>> GetStudentsForCourseAsync(Guid courseId)
        {
            var students = await _courseUseCase.GetStudentsForCourseAsync(courseId);
            return Ok(students);
        }

        [HttpGet("{courseId}/teacher")]
        public async Task<ActionResult<List<TeacherDTO>>> GetTeachersForCourseAsync(Guid courseId)
        {
            var teachers = await _courseUseCase.GetTeachersForCourseAsync(courseId);
            return Ok(teachers);
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourseAsync(Guid courseId)
        {
            var result = await _courseUseCase.DeleteCourseAsync(courseId);
            if (!result)
            {
                return NotFound("Course not found.");
            }
            return NoContent();
        }

        [HttpDelete("{courseId}/teacher/{teacherId}")]
        public async Task<ActionResult<CourseDTO>> RemoveTeacherFromCourseAsync(Guid courseId, Guid teacherId)
        {
            var course = await _courseUseCase.RemoveTeacherFromCourseAsync(courseId, teacherId);
            if (course == null)
            {
                return NotFound("Course or Teacher not found.");
            }
            return Ok(course);
        }

        [HttpDelete("{courseId}/teacher")]
        public async Task<ActionResult<CourseDTO>> RemoveAllTeachersFromCourseAsync(Guid courseId)
        {
            var course = await _courseUseCase.RemoveAllTeachersFromCourseAsync(courseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(course);
        }

        [HttpDelete("{courseId}/student/{studentId}")]
        public async Task<ActionResult<CourseDTO>> RemoveStudentFromCourseAsync(Guid courseId, Guid studentId)
        {
            var course = await _courseUseCase.RemoveStudentFromCourseAsync(courseId, studentId);
            if (course == null)
            {
                return NotFound("Course or Student not found.");
            }
            return Ok(course);
        }

        [HttpDelete("{courseId}/student")]
        public async Task<ActionResult<CourseDTO>> RemoveAllStudentsFromCourseAsync(Guid courseId)
        {
            var course = await _courseUseCase.RemoveAllStudentsFromCourseAsync(courseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(course);
        }
    }
}
