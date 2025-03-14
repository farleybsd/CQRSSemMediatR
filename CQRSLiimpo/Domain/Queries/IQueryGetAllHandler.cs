namespace CQRSLiimpo.Domain.Queries
{
    public interface IQueryGetAllHandler<TQueryResult>
    {
        Task<TQueryResult> Handle(CancellationToken cancellation);
    }
}
