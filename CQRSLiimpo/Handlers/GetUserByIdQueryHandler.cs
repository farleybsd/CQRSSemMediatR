using CQRSLiimpo.Controllers;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Queries;

namespace CQRSLiimpo.Handlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        public GetUserByIdQueryHandler() { }

        public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            // Simula uma operação assíncrona até que o repositório seja implementado
            return await Task.FromResult(new User());
        }

    }
}
