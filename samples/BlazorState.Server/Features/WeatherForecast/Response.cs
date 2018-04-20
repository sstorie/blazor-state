namespace BlazorState.Server.Features.WeatherForecast
{
  using BlazorState.Server.Features.Base;
  using System.Collections.Generic;
  using BlazorState.Shared;
  using System;

  public class Response : BaseResponse
  {
    public Response(Guid aRequestId)
    {
      WeatherForecasts = new List<WeatherForecast>();
      RequestId = aRequestId;
    }
    public List<WeatherForecast> WeatherForecasts { get; set; }
  }
}