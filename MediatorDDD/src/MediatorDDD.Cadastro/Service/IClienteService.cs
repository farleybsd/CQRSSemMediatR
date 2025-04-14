using MediatorDDD.Cadastro.Commands;

namespace MediatorDDD.Cadastro.Service;
public interface IClienteService
{
    Task<string> CadastrarCliente(CadastrarClienteCommand cliente);
    Task<bool> ExcluirCliente(ExcluirClienteCommand cliente);
}

