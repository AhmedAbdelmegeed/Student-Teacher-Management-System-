namespace Application.DTO
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public string Major { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
