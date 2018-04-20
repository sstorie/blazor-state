namespace BlazorState.Client.Features.WeatherForecast.Fetch
{
  using BlazorState.Behaviors.State;
  using BlazorState.Store;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Blazor;
  using System;
  using System.Linq;

  public class Handler : RequestHandler<Request, State>
  {
    public Handler(
      IStore<State> aStore,
      HttpClient aHttpClient
      ) : base(aStore) {
      HttpClient = aHttpClient;
    }

    private HttpClient HttpClient { get; }

    public override async Task<State> Handle(Request request, CancellationToken cancellationToken)
    {
      AjaxResponse ajaxResponse = await HttpClient.GetJsonAsync<AjaxResponse>("/api/weatherforecast");
      State.WeatherForecasts = ajaxResponse.WeatherForecasts;
      return State;
    }
  }}
