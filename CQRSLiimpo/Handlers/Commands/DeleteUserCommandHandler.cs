using CQRSLiimpo.Application.Request;
using CQRSLiimpo.Application.Response;
using CQRSLiimpo.Domain.Command;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Queries;
using CQRSLiimpo.Domain.Repositories;

namespace CQRSLiimpo.Handlers.Commands
{
    public class DeleteUserCommandHandler : IDeleteHandler<DeleteUserRequest, string>
    {
        private readonly IClienteRepository _clienteRepository;

        public DeleteUserCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<string> Handle(DeleteUserRequest command, CancellationToken cancellation)
        {
            var userExists = await _clienteRepository.ExistsAsync(command.UserId);

            return userExists
                ? await _clienteRepository.DeleteAsync(command.UserId).ContinueWith(_ => "Ok Removido Com Sucesso")
                : "Usuário não encontrado";
        }
    }
}
