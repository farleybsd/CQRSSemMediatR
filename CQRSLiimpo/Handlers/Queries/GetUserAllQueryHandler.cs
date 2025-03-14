using CQRSLiimpo.Application.Response;
using CQRSLiimpo.Domain.Queries;
using CQRSLiimpo.Domain.Repositories;

namespace CQRSLiimpo.Handlers.Queries
{
    public class GetUserAllQueryHandler : IQueryGetAllHandler<IEnumerable<CreateUserResponse>>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetUserAllQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<CreateUserResponse>> Handle(CancellationToken cancellation)
        {
            var result = await _clienteRepository.GetAllAsync();

            return result?.Select(r => new CreateUserResponse
            {
                Id = r.Id,
                Email = r.Email,
                Nome = r.Nome
            }) ?? Enumerable.Empty<CreateUserResponse>();
        }
    }
}
