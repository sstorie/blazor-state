﻿namespace BlazorState.Behaviors.History
{
  using BlazorState.Store;
  using MediatR;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  public class HistoryBehavior<TRequest, TState> : IPipelineBehavior<TRequest, TState>
    where TRequest: IRequest<TState>
    where TState : IState
  {
    private IStore<TState> Store { get; }
    private History<TState> History { get; }
    public HistoryBehavior(
      History<TState> aHistory,
      IStore<TState> aStore)
    {
      Console.WriteLine($"{this.GetType().Name} constructor");
      History = aHistory;
      Store = aStore;
    }

    public async Task<TState> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TState> next)
    {
      Console.WriteLine($"Adding Entry to History. Count: {History.Entries.Count}");
      History.Entries.Add(new History<TState>.Entry(Store.State, request));
      var response = await next();
      return response;
    }
  }
}
