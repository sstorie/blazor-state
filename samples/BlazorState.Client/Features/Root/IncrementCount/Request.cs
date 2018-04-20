namespace BlazorState.Client.Features.Root.IncrementCount
{
  using MediatR;
  public class Request : IRequest<State>
  {
    public int Amount { get; set; }
  }
}
