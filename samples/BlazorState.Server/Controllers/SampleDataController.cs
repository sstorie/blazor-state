using BlazorState.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorState.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
    public List<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
      var weatherForecasts = new List<WeatherForecast>();
      Enumerable.Range(1, 5).ToList().ForEach(index => weatherForecasts.Add(
        new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
        }));
      return weatherForecasts;
        }
    }
}
