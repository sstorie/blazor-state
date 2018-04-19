namespace BlazorState.Behaviors.History
{
  using MediatR;
  using System;
  using System.Collections.Generic;

  public class History<TState>
  {
    public List<Entry> Entries { get; }
    public History()
    {
      Entries = new List<Entry>();
    }

    public class Entry
    {
      public Entry(TState state, IRequest<TState> request = default(IRequest<TState>))
      {
        State = state;
        Request = request;
        Time = DateTime.UtcNow;
      }

      public TState State { get; }
      public IRequest<TState> Request { get; }
      public DateTime Time { get; }
    }
  }
}
