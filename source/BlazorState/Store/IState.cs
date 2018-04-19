namespace BlazorState.Store
{
  using System;

  public interface IState : ICloneable
  {
    string Route { get; set; }
  }
}
