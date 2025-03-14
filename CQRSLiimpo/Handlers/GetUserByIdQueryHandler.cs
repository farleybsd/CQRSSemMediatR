using CQRSLiimpo.Controllers;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Queries;
using CQRSLiimpo.Domain.Repositories;

namespace CQRSLiimpo.Handlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetUserByIdQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            // Simula uma operação assíncrona até que o repositório seja implementado
            return await _clienteRepository.GetByIdAsync(query.UserId) ?? new User();
        }
    }
}