using MediatorDDD.SharedKernel.Interfaces;

namespace MediatorDDD.SharedKernel.Events;
public record ClienteCadastradoEvent(Guid ClienteId) : INotification;

