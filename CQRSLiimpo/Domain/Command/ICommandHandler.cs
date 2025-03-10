namespace CQRSLiimpo.Domain.Command
{
    //Esta interface é responsável por manipular operações de comando.
    public interface ICommandHandler<in TCommand, TCommandResult>
    {
        Task<TCommandResult> Handle(TCommand command, CancellationToken cancellation);
    }
}
