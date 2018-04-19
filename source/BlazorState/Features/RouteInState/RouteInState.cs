namespace BlazorState.Features.RouteInState
{
  using MediatR;
  using Microsoft.AspNetCore.Blazor.Services;
  using System;

  public class RouteInState
  {
    public RouteInState(IUriHelper aUriHelper, IMediator aMediator)
    {
      Console.WriteLine("RouteInState");
      UriHelper = aUriHelper;
      Mediator = aMediator;
      UriHelper.OnLocationChanged += OnLocationChanged;
    }

    private IUriHelper UriHelper { get; }
    public IMediator Mediator { get; }
    private string CurrentRoute { get; set; }
    private void OnLocationChanged(object sender, string aNewAbsoluteUri)
    {
      Console.WriteLine($"Route changed to {aNewAbsoluteUri}");
      // TODO think about concurrency.
      if (aNewAbsoluteUri == CurrentRoute) return; // Why does it fire if it didn't actually change?

      CurrentRoute = aNewAbsoluteUri;

      Mediator.Send(new Request { Route = aNewAbsoluteUri });
    }
  }
}
