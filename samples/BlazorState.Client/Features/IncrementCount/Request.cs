namespace BlazorState.Client.Features.IncrementCount
{
  using MediatR;
  public class Request : IRequest<State>
  {
    public int Amount { get; set; }
  }
}
