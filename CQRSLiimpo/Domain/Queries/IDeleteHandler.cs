namespace CQRSLiimpo.Domain.Queries
{
    public interface IDeleteHandler<in Tquery, TQueryResult>
    {
        Task<TQueryResult> Handle(Tquery query, CancellationToken cancellation);
    }
}