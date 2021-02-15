using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace CheesePie.Utils.Tests {
	public class ExtensionsPlayModeTest {

		private class TestComponent : MonoBehaviour {

		};

		private class Counter {
			public int count = 0;
		}

		private IEnumerator OneFrameCoroutine() {
			yield return null;
		}

		private IEnumerator IncreaseCountCoroutine(Counter counter) {
			yield return null;
			counter.count++;
		}

		#region MonoBehaviour

		[UnityTest]
		public IEnumerator TestStartCoroutine() {
			GameObject gameObject = new GameObject();
			TestComponent component = gameObject.AddComponent<TestComponent>();

			bool complete = false;
			component.StartCoroutine(OneFrameCoroutine(), () => complete = true);
			yield return null;
			yield return null;
			Assert.IsTrue(complete);
		}

		[UnityTest]
		public IEnumerator TestStartCoroutines() {
			GameObject gameObject = new GameObject();
			TestComponent component = gameObject.AddComponent<TestComponent>();

			Counter counter = new Counter();
			yield return component.StartCoroutines(IncreaseCountCoroutine(counter),
					IncreaseCountCoroutine(counter), IncreaseCountCoroutine(counter));
			Assert.AreEqual(3, counter.count);
		}

		[UnityTest]
		public IEnumerator TestStartCoroutineAction() {
			GameObject gameObject = new GameObject();
			TestComponent component = gameObject.AddComponent<TestComponent>();

			bool complete = false;
			component.StartCoroutineAction(0.1f, () => complete = true);
			yield return new WaitForSeconds(0.2f);
			Assert.IsTrue(complete);
		}

		#endregion

	}
}
