#region Using directives
using System.Collections.Generic;
using System.Text;
using FTOptix.NetLogic;
using OpcUa = UAManagedCore.OpcUa;
using UAManagedCore;
using FTOptix.Alarm;
using FTOptix.Recipe;
using FTOptix.CommunicationDriver;
using FTOptix.Modbus;
using FTOptix.AuditSigning;
using FTOptix.OPCUAServer;
#endregion

public class MethodsObserver : BaseNetLogic
{
    public override void Start()
    {
        var serverObject = LogicObject.Context.GetObject(OpcUa.Objects.Server);
        var eventHandler = new EventsHandler.EventsHandler();
        // eventRegistration = serverObject.RegisterUAEventObserver(eventHandler, UAManagedCore.OpcUa.ObjectTypes.AuditUpdateMethodEventType);
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        eventRegistration?.Dispose();
    }

    private IEventRegistration eventRegistration;
}

namespace EventsHandler
{
    public class EventsHandler : IUAEventObserver
    {
        public EventsHandler()
        {
            Log.Info("EventsHandler", "EventsHandler instance created");
        }

        public void OnEvent(IUAObject eventNotifier, IUAObjectType eventType, IReadOnlyList<object> eventData, ulong senderId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Event of type {eventType.BrowseName} triggered");
            var eventArguments = eventType.EventArguments;
            foreach (var eventField in eventArguments.GetFields())
            {
                var fieldValue = eventArguments.GetFieldValue(eventData, eventField);
                builder.Append($"\t{eventField} = {fieldValue?.ToString() ?? "null"}");
            }
            builder.Append("\n");
            Log.Info(builder.ToString());
        }
    }
}
