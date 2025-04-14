using MediatorDDD.SharedKernel.Interfaces;

namespace MediatorDDD.Cadastro.Commands;

public class ExcluirClienteCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
