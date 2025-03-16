namespace Application.DTO
{
    public class CourseDTO
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public string CourseUrl { get; set; }
        public int Duration { get; set; }

        public List<Guid> StudentIds { get; set; } = new List<Guid>();
        public List<Guid> TeacherIds { get; set; } = new List<Guid>();
    }
}
