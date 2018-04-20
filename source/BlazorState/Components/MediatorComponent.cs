namespace BlazorState.Components
{
  using Microsoft.AspNetCore.Blazor;
  using Microsoft.AspNetCore.Blazor.Components;
  using MediatR;
  using BlazorState.Behaviors.DevTools;
  using BlazorState.Store;

  public class MediatorComponent<TState> : BlazorComponent
    where TState : IState
  {
    [Inject] public IStore<TState> Store { get; set; }
    [Inject] public IMediator Mediator { get; set; }

    public TState State => Store.State;

    public RenderFragment ReduxDevTools;

    protected override void OnInit()
    {
      ReduxDevTools = renderTreeBuilder =>
      {
        renderTreeBuilder.OpenComponent<ReduxDevTools>(sequence: 0);
        renderTreeBuilder.CloseComponent();
      };
    }
  }
}