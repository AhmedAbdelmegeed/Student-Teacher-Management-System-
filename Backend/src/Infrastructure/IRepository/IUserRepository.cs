using Domain.Entity;

namespace Infrastructure.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}
