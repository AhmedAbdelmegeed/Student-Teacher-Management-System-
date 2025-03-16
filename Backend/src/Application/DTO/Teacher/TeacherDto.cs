using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class TeacherDTO
    {
        public Guid TeacherId { get; set; }
        public UserDTO User { get; set; } 
        public DateTime HireDate { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
