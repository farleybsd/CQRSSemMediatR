namespace CQRSLiimpo.Domain.Dispatcher.Query
{
    /*
     * Esta interface é responsável por despachar consultas para seus respectivos manipuladores de consulta. 
     * Ela tem um método Dispatch genérico que pega um objeto de consulta e um token de cancelamento, e retorna
     * uma tarefarepresentando o resultado da consulta despachada.
     */
    public interface IQueryDispatcher
    {
        Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation);
    }
}
