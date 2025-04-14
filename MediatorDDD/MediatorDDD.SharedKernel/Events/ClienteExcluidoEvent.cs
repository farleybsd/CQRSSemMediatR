using MediatorDDD.SharedKernel.Interfaces;

namespace MediatorDDD.SharedKernel.Events;
public record ClienteExcluidoEvent(Guid ClienteId) : INotification;


