using UnityEngine;
using System.Collections.Generic;
using System;

namespace CheesePie.Utils {

	/// <summary>
	/// Uses an enum to represent the states of a finite state machine.
	///
	/// Usage:
	/// 1. Use the AddTransition() function to define the transitions
	///    between states that are allowed.
	/// 2. Use the functions that begin with "AddEvent" to add state
	///	   transition events.
	/// 3. Start the FiniteStateMachine by calling Start().
	/// 4. Call the TransitionTo() function whenever you want to
	///    transition to a new state.
	/// </summary>
	/// <typeparam name="T">
	/// Represents the states of the FiniteStateMachine.
	/// Must be an enum.
	/// </typeparam>
	public class FiniteStateMachine<T> {

		public bool IsRunning { get; private set; }
		public T CurrentState { get; private set; }
		public bool LogTransitions = false;

		// Transition Events
		private Dictionary<T, Dictionary<T, Action<T, T>>> transitionDictionary;
		private Dictionary<T, Action<T, T>> onEnterEvents;
		private Dictionary<T, Action<T, T>> onExitEvents;
		private Action<T, T> onAnyTransitionEvents;

		public FiniteStateMachine() {
			if (typeof(T).BaseType != typeof(Enum)) {
				throw new ArgumentException("T must be of type System.Enum");
			}

			IsRunning = false;

			transitionDictionary = new Dictionary<T, Dictionary<T, Action<T, T>>>();
			foreach (T state in Enum.GetValues(typeof(T))) {
				transitionDictionary.Add(state, new Dictionary<T, Action<T, T>>());
			}

			onEnterEvents = new Dictionary<T, Action<T, T>>();
			onExitEvents = new Dictionary<T, Action<T, T>>();

			AddEventOnAnyTransition(LogTransition);
		}

		/// <summary>
		/// Start the fsm on the given state.
		/// Note: No events are called until a transition happens.
		/// </summary>
		public void Start(T startingState) {
			if (IsRunning) {
				Debug.LogError("FSM already started");
				return;
			}

			CurrentState = startingState;
			IsRunning = true;
		}


		#region AddTransition

		/// <summary>
		/// Add the given transitions to the fsm
		/// </summary>
		public void AddTransition(T from, T to) {
			transitionDictionary[to].Add(from, null);
		}

		/// <summary>
		/// Add the given transitions to the fsm
		/// </summary>
		public void AddTransition(T from, params T[] toStates) {
			foreach (T to in toStates) {
				transitionDictionary[to].Add(from, null);
			}
		}

		#endregion


		#region AddEvents

		/// <summary>
		/// Add a call back to when any transition occurs
		/// </summary>
		public void AddEventOnAnyTransition(Action<T, T> onAnyTransition) {
			onAnyTransitionEvents += onAnyTransition;
		}

		/// <summary>
		/// Add a call back to when the transition between the given states occurs
		/// </summary>
		public void AddEventOnTransition(T from, T to, Action<T, T> onTransition) {
			transitionDictionary[to][from] += onTransition;
		}

		/// <summary>
		/// Add a call back to when the transition between the given states occurs
		/// </summary>
		public void AddEventOnTransition(T from, T to, Action onTransition) {
			AddEventOnTransition(from, to, (_, __) => onTransition());
		}

		/// <summary>
		/// Add a call back to when a transition to this state occurs
		/// </summary>
		public void AddEventOnEnter(T state, Action<T, T> onEnter) {
			if (onEnterEvents.ContainsKey(state)) {
				onEnterEvents[state] += onEnter;
			} else {
				onEnterEvents.Add(state, onEnter);
			}
		}

		/// <summary>
		/// Add a call back to when a transition to this state occurs
		/// </summary>
		public void AddEventOnEnter(T state, Action onEnter) {
			AddEventOnEnter(state, (_, __) => onEnter());
		}

		/// <summary>
		/// Add a call back to when a transition away from this state occurs
		/// </summary>
		public void AddEventOnExit(T state, Action<T, T> onExit) {
			if (onExitEvents.ContainsKey(state)) {
				onExitEvents[state] += onExit;
			} else {
				onExitEvents.Add(state, onExit);
			}
		}

		/// <summary>
		/// Add a call back to when a transition away from this state occurs
		/// </summary>
		public void AddEventOnExit(T state, Action onExit) {
			AddEventOnExit(state, (_, __) => onExit());
		}

		#endregion


		/// <summary>
		/// Return true if transition exists
		/// </summary>
		public bool TransitionExists(T from, T to) {
			return transitionDictionary[to].ContainsKey(from);
		}

		/// <summary>
		/// Transition to the given state
		/// </summary>
		public void TransitionTo(T state) {
			if (!TransitionExists(CurrentState, state)) {
				throw new ArgumentException(String.Format("FSM Transition ({0} -> {1}) does not exist!", CurrentState,
						state));
			}

			T oldState = CurrentState;

			// Exit Events
			if (onExitEvents.ContainsKey(oldState) && onExitEvents[oldState] != null) {
				onExitEvents[oldState](oldState, state);
			}

			// Change State
			CurrentState = state;

			// Transition Events
			if (transitionDictionary[state][oldState] != null) {
				transitionDictionary[state][oldState](oldState, state);
			}

			if (onAnyTransitionEvents != null) {
				onAnyTransitionEvents(oldState, state);
			}

			// Enter Events
			if (onEnterEvents.ContainsKey(state) && onEnterEvents[state] != null) {
				onEnterEvents[state](oldState, state);
			}

		}

		/// <summary>
		/// Transition to the given state,
		/// but only if the transition exists
		/// </summary>
		/// <returns>True if transition exists</returns>
		public bool TransitionToIfExists(T state) {
			if (!TransitionExists(CurrentState, state)) {
				return false;
			}

			TransitionTo(state);
			return true;
		}

		/// <summary>
		/// Log a state transition
		/// </summary>
		private void LogTransition(T from, T to) {
			if (LogTransitions) {
				Debug.Log(String.Format("FSM Transition: {0} -> {1}", from, to));
			}
		}
	}
}
