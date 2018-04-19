namespace BlazorState.Behaviors.DevTools
{
  using System;
  public class StringEventArgs : EventArgs
  {
    public StringEventArgs(string aString)
    {
      String = aString;
    }

    public string String { get; }
  }

  public delegate void StringEventHandler(object sender, StringEventArgs args);
}