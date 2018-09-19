using System.Threading.Tasks;
using Appeaser;

namespace Veolia.Extranet.Api.Core.Appeaser
{
    public class ApiMediator : IMediator
    {
        private readonly Mediator _mediator;
        public ApiMediator(IMediatorHandlerFactory handlerFactory)
        {
            _mediator = new Mediator(handlerFactory);
        }

        public TResponse Request<TResponse>(IQuery<TResponse> query)
        {
            return _mediator.Request(query);
        }

        public async Task<TResponse> Request<TResponse>(IAsyncQuery<TResponse> query)
        {
            return await _mediator.Request(query);
        }

        public TResult Send<TResult>(ICommand<TResult> query)
        {
            return _mediator.Send(query);
        }

        public async Task<TResult> Send<TResult>(IAsyncCommand<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}
