using Domain.Entity;

namespace Infrastructure.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
            Task<Role> GetByNameAsync(string name);
    }
}
