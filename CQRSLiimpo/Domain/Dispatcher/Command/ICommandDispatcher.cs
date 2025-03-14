namespace CQRSLiimpo.Domain.Dispatcher.Command
{
    /*Esta interface é responsável por despachar comandos para seus respectivos manipuladores de comando. */

    public interface ICommandDispatcher
    {
        Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation);
    }
}