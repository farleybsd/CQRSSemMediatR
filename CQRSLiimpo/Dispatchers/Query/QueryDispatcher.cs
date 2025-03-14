using CQRSLiimpo.Application.Response;
using CQRSLiimpo.Domain.Dispatcher.Query;
using CQRSLiimpo.Domain.Queries;

namespace CQRSLiimpo.Dispatchers.Query
{
    public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
            return handler.Handle(query, cancellation);
        }

        public async Task<IEnumerable<CreateUserResponse>> DispatchAll(CancellationToken cancellation)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryGetAllHandler<IEnumerable<CreateUserResponse>>>();
            return await handler.Handle(cancellation);
        }

        public async Task<TQueryResult> DispatchDelete<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation)
        {
            var handler = _serviceProvider.GetRequiredService<IDeleteHandler<TQuery, TQueryResult>>();
            return await handler.Handle(query, cancellation);
        }
    }
}