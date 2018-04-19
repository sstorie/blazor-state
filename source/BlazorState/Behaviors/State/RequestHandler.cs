namespace BlazorState.Behaviors.State
{
  using BlazorState.Store;
  using MediatR;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  public abstract class RequestHandler<TRequest, TState> : IRequestHandler<TRequest, TState>
    where TRequest : IRequest<TState>
    where TState : IState
  {
    public RequestHandler(IStore<TState> aStore)
    {
      Store = aStore;
    }
    protected IStore<TState> Store { get; set; }

    protected TState State => Store.State;
    public abstract Task<TState> Handle(TRequest request, CancellationToken cancellationToken);

  }

}
