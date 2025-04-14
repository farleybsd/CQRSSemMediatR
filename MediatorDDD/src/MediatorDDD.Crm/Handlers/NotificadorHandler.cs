using MediatorDDD.SharedKernel.Events;
using MediatorDDD.SharedKernel.Interfaces;

namespace MediatorDDD.Crm.Handlers;
public class NotificadorHandler :
    INotificationHandler<ClienteCadastradoEvent>,
    INotificationHandler<ClienteExcluidoEvent>
{
    public Task Handle(ClienteCadastradoEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[CRM] Enviando e-mail de boas-vindas ao cliente {notification.ClienteId}");
        return Task.CompletedTask;
    }

    public Task Handle(ClienteExcluidoEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[CRM] Enviando e-mail de despedidas ao cliente {notification.ClienteId}");
        return Task.CompletedTask;
    }
}
