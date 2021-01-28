using System;
using NUnit.Framework;
using UnityEngine;

namespace CheesePie.Utils.Tests {

	public class ProjectileMathTests {

		private static Vector2 CalculateProjectilePosition(Vector2 initialVelocity, float yForce, float time) {
			return new Vector2(
					initialVelocity.x * time,
					0.5f * yForce * time * time + initialVelocity.y * time
			);
		}

		[Test]
		public void TestFindInitialVelocity1() {
			Vector2 initialVelocity = new Vector2(3, 2);
			float gravity = -9.8f;
			Vector2 point = CalculateProjectilePosition(initialVelocity, gravity, 3.4f);

			Tuple<Vector2, Vector2> solutions;
			solutions = ProjectileMath.FindInitialVelocity(initialVelocity.magnitude, point, gravity);

			Assert.IsNotNull(solutions);
			Assert.IsTrue(TestUtils.Approx(solutions.Item1, initialVelocity) || TestUtils.Approx(solutions.Item2, initialVelocity));
		}

		[Test]
		public void TestFindInitialVelocity2() {
			Vector2 initialVelocity = new Vector2(-3, 2);
			float gravity = 9.8f;
			Vector2 point = CalculateProjectilePosition(initialVelocity, gravity, 1.2f);

			Tuple<Vector2, Vector2> solutions;
			solutions = ProjectileMath.FindInitialVelocity(initialVelocity.magnitude, point, gravity);

			Assert.IsNotNull(solutions);
			Assert.IsTrue(TestUtils.Approx(solutions.Item1, initialVelocity) || TestUtils.Approx(solutions.Item2, initialVelocity));
		}

		[Test]
		public void TestFindInitialVelocity3() {
			Vector2 initialVelocity = new Vector2(1, 10);
			float gravity = -5f;
			Vector2 point = CalculateProjectilePosition(initialVelocity, gravity, 10f);

			Tuple<Vector2, Vector2> solutions;
			solutions = ProjectileMath.FindInitialVelocity(initialVelocity.magnitude, point, gravity);

			Assert.IsNotNull(solutions);
			Assert.IsTrue(TestUtils.Approx(solutions.Item1, initialVelocity) || TestUtils.Approx(solutions.Item2, initialVelocity));
		}

		[Test]
		public void TestFindInitialVelocity4() {
			Tuple<Vector2, Vector2> solutions;
			solutions = ProjectileMath.FindInitialVelocity(2f, new Vector2(10f, 10f), -9.8f);
			Assert.IsNull(solutions);
		}
	}
}
