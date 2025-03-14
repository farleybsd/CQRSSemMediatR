using CQRSLiimpo.Domain.Entities;

namespace CQRSLiimpo.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<User> AddAsync(User cliente);
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User cliente);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
