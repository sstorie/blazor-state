namespace BlazorState.Client.Features.WeatherForecast.Fetch
{
  using MediatR;
  public class Request : IRequest<State>
  {
    public int Amount { get; set; }
  }
}
