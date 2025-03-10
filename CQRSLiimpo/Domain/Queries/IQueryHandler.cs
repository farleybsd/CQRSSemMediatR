namespace CQRSLiimpo.Domain.Queries
{
    /*  Esta interface é responsável por manipular operações de consulta.
     *  Ela tem um único método Handle que pega um objeto de consulta do
     *  tipo TQuery e um token de cancelamento, e retorna uma Taskrepresentando o resultado da operação de consulta.
     */

    public interface IQueryHandler <in Tquery, TQueryResult>
    {
        Task<TQueryResult> Handle(Tquery query,CancellationToken cancellation);
    }
}
