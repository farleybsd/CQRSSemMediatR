using CQRSLiimpo.Application.Request;
using CQRSLiimpo.Application.Response;
using CQRSLiimpo.Domain.Command;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Repositories;

namespace CQRSLiimpo.Handlers.Commands
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserRequest, CreateUserResponse>
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateUserCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<CreateUserResponse> Handle(UpdateUserRequest command, CancellationToken cancellation)
        {
             await _clienteRepository.UpdateAsync(new User() {Id= command.Id, Email = command.Email, Nome = command.Nome });
            return new CreateUserResponse() { Id = command.Id, Email = command.Email, Nome = command.Nome };
        }
    }
}
