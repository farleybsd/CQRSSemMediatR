using MediatorDDD.Cadastro.Commands;
using MediatorDDD.SharedKernel.Interfaces;

namespace MediatorDDD.Cadastro.Service;
public class ClienteService : IClienteService
{
    private readonly IMediator _mediator;

    public ClienteService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<string> CadastrarCliente(CadastrarClienteCommand cliente)
    {
        var resultado = await _mediator.Send(new CadastrarClienteCommand { Id = cliente.Id, Nome = cliente.Nome });
        return resultado;
    }

    public async Task<bool> ExcluirCliente(ExcluirClienteCommand cliente)
    {
        var resultado = await _mediator.Send(new ExcluirClienteCommand { Id = cliente.Id });
        return resultado;
    }
}
