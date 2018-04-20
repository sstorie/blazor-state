namespace BlazorState.Client.Features.Root.IncrementCount
{
  using BlazorState.Behaviors.State;
  using BlazorState.Store;
  using System.Threading;
  using System.Threading.Tasks;

  public class Handler : RequestHandler<Request, State>
  {
    public Handler(IStore<State> aStore) : base(aStore) { }

    public override Task<State> Handle(Request request, CancellationToken cancellationToken)
    {
      State.Count += request.Amount;

      return Task.FromResult(State);
    }
  }
}
