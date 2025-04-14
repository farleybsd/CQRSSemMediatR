using MediatorDDD.SharedKernel.Interfaces;

namespace MediatorDDD.Cadastro.Commands;

public class CadastrarClienteCommand : IRequest<string>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
}
