using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Repositories;
using CQRSLiimpo.Infrastructure.Exceptions;

namespace CQRSLiimpo.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private static List<User> _clientes = new();

        public async Task<User> AddAsync(User cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
            return await Task.FromResult(cliente); 
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await GetByIdAsync(id);

            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_clientes.ToList()); 
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                throw new ClienteNotFoundException(id);
            }

            return await Task.FromResult(cliente); 
        }

        public async Task UpdateAsync(User cliente)
        {
            var existingCliente = await GetByIdAsync(cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.Nome = cliente.Nome;
                existingCliente.Email = cliente.Email;
            }
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await Task.FromResult(_clientes.Any(c => c.Id == id));
        }
    }
}
