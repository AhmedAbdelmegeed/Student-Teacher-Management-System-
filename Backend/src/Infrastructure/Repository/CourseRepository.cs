using Domain.Entity;
using Infrastructure.Data;
namespace Infrastructure.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
