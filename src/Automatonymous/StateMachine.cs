﻿namespace Automatonymous
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    /// <summary>
    /// A state machine definition
    /// </summary>
    public interface StateMachine :
        Visitable
    {
        /// <summary>
        /// The name of the state machine (defaults to the state machine type name)
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The events defined in the state machine
        /// </summary>
        IEnumerable<Event> Events { get; }

        /// <summary>
        /// The states defined in the state machine
        /// </summary>
        IEnumerable<State> States { get; }

        /// <summary>
        /// The instance type associated with the state machine
        /// </summary>
        Type InstanceType { get; }

        /// <summary>
        /// The initial state of a new state machine instance
        /// </summary>
        State Initial { get; }

        /// <summary>
        /// The final state of a state machine instance
        /// </summary>
        State Final { get; }

        /// <summary>
        /// Returns the event requested
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Event GetEvent(string name);

        /// <summary>
        /// Returns the state requested
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        State GetState(string name);

        /// <summary>
        /// The valid events that can be raised during the specified state
        /// </summary>
        /// <param name="state">The state to query</param>
        /// <returns>An enumeration of valid events</returns>
        IEnumerable<Event> NextEvents(State state);
    }


    /// <summary>
    /// A defined state machine that operations against the specified instance
    /// </summary>
    /// <typeparam name="TInstance"></typeparam>
    public interface StateMachine<TInstance> :
        StateMachine
        where TInstance : class
    {
        /// <summary>
        /// Exposes the current state on the given instance
        /// </summary>
        StateAccessor<TInstance> Accessor { get; }

        /// <summary>
        /// Returns the state requested bound to the instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        new State<TInstance> GetState(string name);

        /// <summary>
        /// Raise a simple event on the state machine instance asynchronously
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Task for the instance once completed</returns>
        Task RaiseEvent(EventContext<TInstance> context);

        /// <summary>
        /// Raise a data event on the state machine instance
        /// </summary>
        /// <param name="context"></param>
        Task RaiseEvent<T>(EventContext<TInstance, T> context);

        IDisposable ConnectEventObserver(EventObserver<TInstance> observer);
        IDisposable ConnectEventObserver(Event @event, EventObserver<TInstance> observer);
        IDisposable ConnectStateObserver(StateObserver<TInstance> observer);
    }
}
