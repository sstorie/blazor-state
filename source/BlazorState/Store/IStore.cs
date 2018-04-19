using System;

namespace BlazorState.Store
{
  public interface IStore<TState>
    where TState: IState
  {
    TState State { get; set; }
  }
}