# blazor-state
Manage Client side state in Blazor using MediatR pipeline.

Implement a client side pipeline using MediatR for Blazor.

MediatR pipeline supports Behaviors (Middleware).  Blazor-State implments the following Behaviors

#State Managment.  
  Maintains a global store and state for use on the client side.  Requests are created and sent via Mediator and Handled.

# Redux Dev Tools.
Allow to monitor State transitions using the Redux Dev tools.  Thanks to Tor Hovland @torhovland for this.

#  Support the addition of behviors and Notifications via MediatR.