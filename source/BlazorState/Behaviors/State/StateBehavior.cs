namespace BlazorState.Behaviors.State
{
  using BlazorState.Store;
  using MediatR;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  public class StateBehavior<TRequest, TState> : IPipelineBehavior<TRequest, TState>
    where TState: IState
  {
    private IStore<TState> Store { get; }
    public StateBehavior(IStore<TState> aStore)
    {
      Store = aStore;
    }

    public async Task<TState> Handle(
      TRequest request, 
      CancellationToken cancellationToken, 
      RequestHandlerDelegate<TState> next)
    {
      //TODO maybe a try catch here and return state to original
      var originalState = Store.State;
      Console.WriteLine("Clone State");
      TState newState = (TState) Store.State.Clone();
      Store.State = newState;
      Console.WriteLine("Call Handler");
      return await next(); 
    }
  }
}
