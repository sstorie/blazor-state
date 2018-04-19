namespace BlazorState.Store
{
  public class Store<TState> : IStore<TState>
    where TState: IState
  {
    //TODO think about thread saftey with Clone and the pipeline and async actions.

    public Store(TState initialState = default(TState))
    {
      State = initialState;
    }

    public TState State { get; set; }
  }
}