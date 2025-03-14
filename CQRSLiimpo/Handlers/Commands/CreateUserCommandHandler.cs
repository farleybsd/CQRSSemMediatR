using CQRSLiimpo.Application.Request;
using CQRSLiimpo.Application.Response;
using CQRSLiimpo.Domain.Command;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Repositories;

namespace CQRSLiimpo.Handlers.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateUserCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest command, CancellationToken cancellation)
        {
            var result = await _clienteRepository.AddAsync(new User() { Email = command.Email, Nome = command.Nome });
            return new CreateUserResponse() { Id = result.Id, Email = result.Email, Nome = result.Nome };
        }
    }
}