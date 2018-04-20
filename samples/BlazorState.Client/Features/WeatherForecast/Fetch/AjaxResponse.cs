namespace BlazorState.Client.Features.WeatherForecast.Fetch
{
  using BlazorState.Shared;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class AjaxResponse
  {
    public List<WeatherForecast> WeatherForecasts { get; set; }
  }
}
