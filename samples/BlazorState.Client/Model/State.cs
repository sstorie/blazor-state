namespace BlazorState.Client
{
  using System.Collections.Generic;
  using System.Linq;
  using BlazorState.Features.RouteInState;
  using BlazorState.Shared;

  public class State:IStateWithRoute
  {
    public string ApplicationName = "My Application";

    public int Count { get; set; }
    public List<WeatherForecast> Forecasts { get; set; }
    public string Route { get; set; }

    public State()
    {
      Forecasts = new List<WeatherForecast>();
    }

    protected State(State aState):this()
    {
      ApplicationName = aState.ApplicationName;
      Count = aState.Count;
      foreach (WeatherForecast forecast in aState.Forecasts)
      {
        Forecasts.Add(forecast.Clone() as WeatherForecast);
      }       
    }

    public object Clone()
    {
      return new State(this);
    }

    public override string ToString()
    {
      var forecasts = string.Join("\n", Forecasts.Select(f => f.ToString()));

      return $"Count: {Count}\n\nForecasts:\n\n{forecasts}";
    }
  }
}