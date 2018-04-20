namespace BlazorState.Features.RouteInState
{
  using BlazorState.Behaviors.State;
  using BlazorState.Store;
  using System.Threading;
  using System.Threading.Tasks;

  public class Handler : RequestHandler<Request, IState>
  {
    public Handler(IStore<IStateWithRoute> aStore) : base((IStore<IState>)aStore) { }

    public override Task<IState> Handle(Request request, CancellationToken cancellationToken)
    {
      State.Route = request.Route;

      return Task.FromResult(State);
    }
  }
}
