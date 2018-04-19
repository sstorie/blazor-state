namespace BlazorState.Behaviors.DevTools
{
  using BlazorState.Behaviors.History;
  using BlazorState.Store;
  using MediatR;
  using MediatR.Pipeline;
  using Microsoft.AspNetCore.Blazor;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  public class xBehavior<TState> : IRequestPreProcessor<IRequest<TState>>
  {
    public Task Process(IRequest<TState> request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }

  //TODO this should be a IRequestPreProcessor
  public class DevToolsBehavior<TRequest, TState> :IPipelineBehavior<TRequest, TState>
    where TRequest: IRequest<TState>
    where TState : IState
  {
    private IStore<TState> Store { get; }
    private History<TState> History { get; }
    public DevToolsBehavior(
      History<TState> aHistory,
      IStore<TState> aStore)
    {
      Console.WriteLine($"{this.GetType().Name} constructor");
      History = aHistory;
      Store = aStore;
      DevToolsInterop.Reset += OnDevToolsReset;
      DevToolsInterop.TimeTravel += OnDevToolsTimeTravel;
      DevToolsInterop.Log("initial", JsonUtil.Serialize(aStore.State));
    }

    public async Task<TState> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TState> next)
    {
      Console.WriteLine($"Logging Request to DevTools");
      var response = await next();
      DevToolsInterop.Log(request.ToString(), JsonUtil.Serialize(Store.State));
      return response;
    }

    private void OnDevToolsReset(object sender, EventArgs e)
    {
      //var state = _initialState;
      //TimeTravel(state);
    }

    private void OnDevToolsTimeTravel(object sender, StringEventArgs e)
    {
      //var state = JsonUtil.Deserialize<TState>(e.String);
      //TimeTravel(state);
    }

  }
}
