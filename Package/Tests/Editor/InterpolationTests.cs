using NUnit.Framework;
using UnityEngine;

namespace CheesePie.Utils.Tests {

	public class InterpolationTests {

		[Test]
		public void TestExpMotionFloat() {
			float currentValue = 0f;
			currentValue = Interpolation.ExpMotion(currentValue, 1f, 0.1f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, 0.1f));

			currentValue = 1f;
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, 0.9f));

			currentValue = 1f;
			currentValue = Interpolation.ExpMotion(currentValue, -1f, 0.3f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, 0.4f));

			currentValue = 1f;
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.25f);
			Assert.IsTrue(TestUtils.Approx(currentValue, 0.9f));

			currentValue = 1f;
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.1f);
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.4f);
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.2f);
			currentValue = Interpolation.ExpMotion(currentValue, 0f, 0.1f, 0.3f);
			Assert.IsTrue(TestUtils.Approx(currentValue, 0.9f));
		}

		[Test]
		public void TestExpMotionVector2() {
			Vector2 currentValue = Vector2.zero;
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.one, 0.1f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector2.one * 0.1f));

			currentValue = Vector2.one;
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector2.one * 0.9f));

			currentValue = Vector2.one;
			currentValue = Interpolation.ExpMotion(currentValue, -Vector2.one, 0.3f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector2.one * 0.4f));

			currentValue = Vector2.one;
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.25f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector2.one * 0.9f));

			currentValue = Vector2.one;
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.1f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.4f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.2f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector2.zero, 0.1f, 0.3f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector2.one * 0.9f));
		}

		[Test]
		public void TestExpMotionVector3() {
			Vector3 currentValue = Vector3.zero;
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.one, 0.1f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector3.one * 0.1f));

			currentValue = Vector3.one;
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector3.one * 0.9f));

			currentValue = Vector3.one;
			currentValue = Interpolation.ExpMotion(currentValue, -Vector3.one, 0.3f, 1f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector3.one * 0.4f));

			currentValue = Vector3.one;
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.25f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.25f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector3.one * 0.9f));

			currentValue = Vector3.one;
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.1f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.4f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.2f);
			currentValue = Interpolation.ExpMotion(currentValue, Vector3.zero, 0.1f, 0.3f);
			Assert.IsTrue(TestUtils.Approx(currentValue, Vector3.one * 0.9f));
		}
	}
}
