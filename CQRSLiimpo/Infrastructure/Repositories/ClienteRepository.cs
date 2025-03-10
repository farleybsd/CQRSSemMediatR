using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Repositories;
using CQRSLiimpo.Infrastructure.Exceptions;

namespace CQRSLiimpo.Infrastructure.Repositories
{
    public class ClienteRepository
    {

        private readonly List<User> _clientes = new();

        public void Add(User cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
        }

        public void Delete(int id)
        {
            var cliente = GetById(id);

            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _clientes.ToList();
        }

        public User GetById(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                throw new ClienteNotFoundException(id);
            }

            return cliente;
        }

        public void Update(User cliente)
        {
            var existingCliente = GetById(cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.Nome = cliente.Nome;
                existingCliente.Email = cliente.Email;
            }
        }
    }
}
