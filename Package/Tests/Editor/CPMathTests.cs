using System;
using NUnit.Framework;
using UnityEngine;

namespace CheesePie.Utils.Tests {

	public class CPMathTests {

		[Test]
		public void TestPiAccuracy() {
			Assert.IsTrue(CPMath.PI == 3.1415926535897932384626833832795f);
		}

		[Test]
		public void TestTauAccuracy() {
			Assert.IsTrue(CPMath.TAU == 6.2831853071795864769252867665590f);
		}

		[Test]
		public void TestAngleToVector2() {
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(0f), Vector2.right));
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(CPMath.PI * 0.5f), Vector2.up));
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(CPMath.PI), Vector2.left));
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(CPMath.PI * 1.5f), Vector2.down));
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(CPMath.PI * 2f), Vector2.right));

			Vector2 vec1 = new Vector2(3f, 9f);
			float angle1 = CPMath.AngleFromVector2(vec1);
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(angle1), vec1.normalized));

			Vector2 vec2 = new Vector2(-2.34f, 9.8f);
			float angle2 = CPMath.AngleFromVector2(vec2) - CPMath.TAU;
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(angle2), vec2.normalized));

			Vector2 vec3 = new Vector2(-2f, -100f);
			float angle3 = CPMath.AngleFromVector2(vec3) + 2f * CPMath.TAU;
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(angle3), vec3.normalized));

			Vector2 vec4 = new Vector2(3.45f, -9f);
			float angle4 = CPMath.AngleFromVector2(vec4) - 3f * CPMath.TAU;
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleToVector2(angle4), vec4.normalized));
		}

		[Test]
		public void TestAngleFromVector2() {
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(Vector2.right), 0f));
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(Vector2.up), CPMath.PI * 0.5f));
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(Vector2.left), CPMath.PI));
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(Vector2.down), - CPMath.PI * 0.5f));

			float angle1 = 0.132f;
			Vector2 vec1 = CPMath.AngleToVector2(angle1);
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(vec1), angle1));

			float angle2 = 2.834f;
			Vector2 vec2 = CPMath.AngleToVector2(angle2);
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(vec2), angle2));

			float angle3 = 4.324f;
			Vector2 vec3 = CPMath.AngleToVector2(angle3);
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(vec3), angle3 - CPMath.TAU));

			float angle4 = 6.123f;
			Vector2 vec4 = CPMath.AngleToVector2(angle4);
			Assert.IsTrue(TestUtils.Approx(CPMath.AngleFromVector2(vec4), angle4 - CPMath.TAU));
		}

		[Test]
		public void TestSubtractAngles() {
			Assert.IsTrue(TestUtils.Approx(CPMath.SubtractAngles(1f, 1f), 0f));
			Assert.IsTrue(TestUtils.Approx(CPMath.SubtractAngles(12.3f, 2.4f), 12.3f - 2.4f - CPMath.TAU * 2f));
			Assert.IsTrue(TestUtils.Approx(CPMath.SubtractAngles(2.3f, 8.4f), 2.3f - 8.4f + CPMath.TAU));
			Assert.IsTrue(TestUtils.Approx(CPMath.SubtractAngles(-5.3f, 18.7f), -5.3f - 18.7f + CPMath.TAU * 4f));
		}

		[Test]
		public void TestSolveQuadratic() {
			Tuple<float, float> roots;

			roots = CPMath.SolveQuadratic(1f, 0f, 0f);
			Assert.IsTrue(TestUtils.Approx(roots.Item1, 0f));
			Assert.IsTrue(TestUtils.Approx(roots.Item2, 0f));

			roots = CPMath.SolveQuadratic(1f, -2f, -3f);
			Assert.IsTrue(TestUtils.Approx(roots.Item1, -1f));
			Assert.IsTrue(TestUtils.Approx(roots.Item2, 3f));

			roots = CPMath.SolveQuadratic(-1f, -2f, 3f);
			Assert.IsTrue(TestUtils.Approx(roots.Item1, -3f));
			Assert.IsTrue(TestUtils.Approx(roots.Item2, 1f));

			roots = CPMath.SolveQuadratic(1f, 2f, 3f);
			Assert.IsNull(roots);

			roots = CPMath.SolveQuadratic(-1f, -2f, -3f);
			Assert.IsNull(roots);
		}
	}
}
