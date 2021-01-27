using NUnit.Framework;

namespace CheesePie.Utils.Tests {

	public class FiniteStateMachineTests {

		private enum State {
			A, B, C
		}

		[Test]
		public void TestIsRunning() {
			FiniteStateMachine<State> fsm = new FiniteStateMachine<State>();

			Assert.IsFalse(fsm.IsRunning);
			fsm.Start(State.A);
			Assert.IsTrue(fsm.IsRunning);
		}

		[Test]
		public void TestTransitions() {
			FiniteStateMachine<State> fsm = new FiniteStateMachine<State>();
			fsm.AddTransition(State.A, State.B, State.C);
			fsm.AddTransition(State.B, State.C);
			fsm.AddTransition(State.C, State.A);

			fsm.Start(State.A);
			Assert.IsTrue(fsm.CurrentState == State.A);

			fsm.TransitionTo(State.B);
			Assert.IsTrue(fsm.CurrentState == State.B);

			Assert.That(() => fsm.TransitionTo(State.A), Throws.ArgumentException);
			fsm.TransitionToIfExists(State.A);
			Assert.IsTrue(fsm.CurrentState == State.B);

			fsm.TransitionTo(State.C);
			Assert.IsTrue(fsm.CurrentState == State.C);

			fsm.TransitionTo(State.A);
			Assert.IsTrue(fsm.CurrentState == State.A);

			fsm.TransitionTo(State.C);
			Assert.IsTrue(fsm.CurrentState == State.C);

			Assert.That(() => fsm.TransitionTo(State.B), Throws.ArgumentException);
		}

		[Test]
		public void TestTransitionEvents() {
			int eventCount = 0;

			FiniteStateMachine<State> fsm = new FiniteStateMachine<State>();
			fsm.AddTransition(State.A, State.B);
			fsm.AddTransition(State.B, State.C);
			fsm.AddEventOnTransition(State.A, State.B, (from, to) => {
				Assert.IsTrue(from == State.A);
				Assert.IsTrue(to == State.B);
				eventCount++;
			});
			fsm.Start(State.A);

			Assert.IsTrue(eventCount == 0);
			fsm.TransitionTo(State.B);
			Assert.IsTrue(eventCount == 1);
			fsm.TransitionTo(State.C);
			Assert.IsTrue(eventCount == 1);
		}

		[Test]
		public void TestAnyTransitionEvents() {
			int event1Count = 0;
			State? event1From = null;
			State? event1To = null;

			FiniteStateMachine<State> fsm = new FiniteStateMachine<State>();
			fsm.AddTransition(State.A, State.B);
			fsm.AddTransition(State.B, State.C);
			fsm.AddEventOnAnyTransition((from, to) => {
				event1From = from;
				event1To = to;
				event1Count++;
			});
			fsm.Start(State.A);

			Assert.IsTrue(event1Count == 0);
			fsm.TransitionTo(State.B);
			Assert.IsTrue(event1Count == 1);
			Assert.IsTrue(event1From == State.A);
			Assert.IsTrue(event1To == State.B);

			fsm.TransitionTo(State.C);
			Assert.IsTrue(event1Count == 2);
			Assert.IsTrue(event1From == State.B);
			Assert.IsTrue(event1To == State.C);
		}

		[Test]
		public void TestEnterExitTransitionEvents() {
			int aEnterCount = 0;
			int aExitCount = 0;
			State? aExitToState = null;
			int bEnterCount = 0;
			State? bEnterFromState = null;

			FiniteStateMachine<State> fsm = new FiniteStateMachine<State>();
			fsm.AddTransition(State.A, State.B);
			fsm.AddTransition(State.B, State.C);
			fsm.AddEventOnEnter(State.A, (from, to) => {
				Assert.IsTrue(to == State.A);
				aEnterCount++;
			});
			fsm.AddEventOnExit(State.A, (from, to) => {
				Assert.IsTrue(from == State.A);
				aExitToState = to;
				aExitCount++;
			});
			fsm.AddEventOnEnter(State.B, (from, to) => {
				bEnterFromState = from;
				Assert.IsTrue(to == State.B);
				bEnterCount++;
			});

			// Start does not trigger enter event
			fsm.Start(State.A);
			Assert.IsTrue(aEnterCount == 0);
			Assert.IsTrue(aExitCount == 0);
			Assert.IsTrue(bEnterCount == 0);

			fsm.TransitionTo(State.B);
			Assert.IsTrue(aEnterCount == 0);
			Assert.IsTrue(aExitCount == 1);
			Assert.IsTrue(aExitToState == State.B);
			Assert.IsTrue(bEnterCount == 1);
			Assert.IsTrue(bEnterFromState == State.A);
		}

		[Test]
		public void TestTransitionExists() {
			FiniteStateMachine<State> fsm = new FiniteStateMachine<State>();
			fsm.AddTransition(State.A, State.B, State.C);
			fsm.AddTransition(State.B, State.C);
			fsm.AddTransition(State.C, State.A);

			Assert.IsTrue(fsm.TransitionExists(State.A, State.B));
			Assert.IsTrue(fsm.TransitionExists(State.A, State.C));
			Assert.IsFalse(fsm.TransitionExists(State.B, State.A));
			Assert.IsTrue(fsm.TransitionExists(State.B, State.C));
			Assert.IsTrue(fsm.TransitionExists(State.C, State.A));
			Assert.IsFalse(fsm.TransitionExists(State.C, State.B));
		}
	}
}
