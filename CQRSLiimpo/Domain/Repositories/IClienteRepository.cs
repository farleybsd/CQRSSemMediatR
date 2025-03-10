using CQRSLiimpo.Domain.Entities;

namespace CQRSLiimpo.Domain.Repositories
{
    public interface IClienteRepository
    {
        void Add(User cliente);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Update(User cliente);
        void Delete(int id);
    }
}
