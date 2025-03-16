using Domain.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
