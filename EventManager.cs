using System;
using System.Collections.Generic;

/// <summary>
/// Manages generic events.
/// </summary>
public static class EventManager
{
    /// <summary>
    /// Event type. You should modify the EventType enum directly to have your own events.
    /// </summary>
    public enum EventType {
        FOO_A,
        FOO_B,
        FOO_C,
        ETC
    };
    
    private static Dictionary<EventType, Action> events = new Dictionary<EventType, Action>();

    /// <summary>
    /// Broadcasts an event to all listeners of an eventType.
    /// </summary>
    /// <param name="eventType">The event type.</param>
    public static void DispatchEvent(EventType eventType)
    {
        if (events.ContainsKey(eventType))
            events[eventType]();
    }

    /// <summary>
    /// Adds an event listener to listen to a specific type of event.
    /// </summary>
    /// <param name="listenerToAdd">The listener to add.</param>
    /// <param name="eventType">The event type that <paramref name="listenerToAdd"/> will be added to. </param>
    public static void AddEventListener(Action listenerToAdd, EventType eventType)
    {
        if (!events.ContainsKey(eventType))
            events.Add(eventType, null);

        events[eventType] += listenerToAdd;
    }

    /// <summary>
    /// Removes the event listeners that match the param, in all event types.
    /// </summary>
    /// <param name="listenerToRemove">The listener to remove.</param>
    public static void RemoveEventListener(Action listenerToRemove)
    {
        List<EventType> types = new List<EventType>(events.Keys);

        foreach(EventType et2 in types)
            events[et2] -= listenerToRemove;
    }

    /// <summary>
    /// Removes the event listener that match the param in the specified type.
    /// </summary>
    /// <param name="listenerToRemove">The listener to remove.</param>
    /// <param name="type">The event type from which the <paramref name="listenerToRemov"/> should be removed.</param>
    public static void RemoveEventListener(Action listenerToRemove, EventType type)
    {
        events[type] -= listenerToRemove;
    }

}
