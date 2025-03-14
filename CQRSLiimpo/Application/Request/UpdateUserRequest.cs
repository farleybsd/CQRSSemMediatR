namespace CQRSLiimpo.Application.Request
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}