namespace BlazorState.Features.RouteInState
{
  using BlazorState.Store;
  using MediatR;
  public class Request : IRequest<IState>
  {
    public string Route { get; set; }
  }
}
