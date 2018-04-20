namespace BlazorState.Client
{
  using BlazorState.Behaviors.History;
  using MediatR;
  using Microsoft.AspNetCore.Blazor.Browser.Rendering;
  using Microsoft.AspNetCore.Blazor.Browser.Services;
  using Microsoft.Extensions.DependencyInjection;
  using System;
  using BlazorState.Behaviors.DevTools;
  using BlazorState.Store;
  using BlazorState.Behaviors.State;
  using BlazorState.Features.RouteInState;

  public class Program
  {
    static void Main(string[] args)
    {
      State initialState = new State();
      Store<State> store = new Store<State>(initialState);
      var serviceProvider = new BrowserServiceProvider(services =>
      {
        services.AddSingleton<IStore<State>>(store);
        services.AddSingleton(new History<State>());
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(HistoryBehavior<,>));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(DevToolsBehavior<,>));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(StateBehavior<,>));
        services.AddSingleton(typeof(RouteInState));
        services.AddMediatR();
      });

      new BrowserRenderer(serviceProvider).AddComponent<App>("app");
    }
  }
}
