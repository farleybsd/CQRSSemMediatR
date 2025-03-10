namespace CQRSLiimpo.Infrastructure.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException(int id) : base($"Cliente com ID {id} não encontrado.") { }
    }
}
