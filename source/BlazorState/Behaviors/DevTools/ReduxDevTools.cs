namespace BlazorState.Behaviors.DevTools
{
  using Microsoft.AspNetCore.Blazor.Components;
  using Microsoft.AspNetCore.Blazor.RenderTree;

  public class ReduxDevTools : BlazorComponent
  {
    // ReSharper disable once RedundantAssignment
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
      var seq = 0;

      builder.OpenElement(seq++, "script");
      builder.AddContent(seq++,
@"(function () {

const assemblyName = 'BlazorState';
const namespace = 'BlazorState.Behaviors.DevTools'
const typeName = 'DevToolsInterop';

function timeTravel(state) {   
    const methodName = 'TimeTravelFromJs';
    const timeTravel = Blazor.platform.findMethod(assemblyName, namespace, typeName, methodName);
    Blazor.platform.callMethod(timeTravel, null, [ Blazor.platform.toDotNetString(state) ]);
}

Blazor.registerFunction('log', (action, state) => {
    var json = JSON.parse(state);

    if (action === 'initial')
        window.devTools.init(json);
    else
        window.devTools.send(action, json);

    return true;
});

var config = { name: 'Blazor State' }; 
var extension = window.__REDUX_DEVTOOLS_EXTENSION__;

if (!extension) {
    console.log('Redux DevTools not installed.');
    return;
}

var devTools = extension.connect(config);

if (!devTools) {
    console.log('Unable to connect to Redux DevTools.');
    return;
}

devTools.subscribe((message) => {
    if (message.type === 'START') {
        console.log('Connected with Redux DevTools.');
        const methodName = 'DevToolsReady';
        const devToolsReady = Blazor.platform.findMethod(assemblyName, namespace, typeName, methodName);
        Blazor.platform.callMethod(devToolsReady, null, []);
    }
    else if (message.type === 'DISPATCH' && message.state) {
        // Time-traveling
        timeTravel(message.state);
    }
    else if (message.type === 'DISPATCH' && message.payload) {
        var payload = message.payload;

        if (payload.type === 'IMPORT_STATE') {
            // Hydration of state from a previous session
            var states = payload.nextLiftedState.computedStates;
            var index = payload.nextLiftedState.currentStateIndex;
            var state = states[index].state;
            timeTravel(state);
        }
        else if (payload.type === 'RESET') {
            // Reset state
            const methodName = 'DevToolsReset';
            const devToolsReset =Blazor.platform.findMethod(assemblyName, namespace, typeName, methodName);
            Blazor.platform.callMethod(devToolsReset, null, []);
        }
        else {
            console.log('Unhandled payload from Redux DevTools:');
            console.log(payload);
        }
    }
    else {
        console.log('Unhandled message from Redux DevTools:');
        console.log(message);
    }
});

window.devTools = devTools;
}());");

      builder.CloseElement();
    }
  }
}
