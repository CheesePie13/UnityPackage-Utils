using System;
using UnityEngine;

namespace CheesePie.Utils {

	/// <summary>
	/// Functions related to projectile calculations.
	/// </summary>
	public static class ProjectileMath {

		/// <summary>
		/// Calculate the initial velocity of projectile given the magnitude of the initial velocity
		/// and an intersection point. Will always choose the velocity with the smaller y value.
		/// </summary>
		/// <param name="point">Delta from initial point</param>
		/// <param name="gravity">Vertical gravity (Downwards is negative)</param>
		/// <returns>The Initial velocity</returns>
		public static Vector2? CalculateInitialVelocity(float initialSpeed, Vector2 point, float gravity) {
			// Using these equations:
			//   initialVelocity.x = initialSpeed * cos(theta) * time
			//   initialVelocity.y = 0.5 * gravity * time^2 + initialSpeed * sin(theta) * time
			// And using the trig identity 1/cos^2(theta) = tan^2(theta) + 1
			// We can calculate the a, b and c values of a quadratic equation to solve for tan(theta)
			float a = 0.5f * gravity * point.x * point.x * (1f / (initialSpeed * initialSpeed));
			float b = point.x;
			float c = a - point.y;
			Tuple<float, float> roots = CPMath.SolveQuadratic(a, b, c);
			if (roots == null) {
				return null;
			}

			float angle1 = Mathf.Atan(roots.Item1);
			float angle2 = Mathf.Atan(roots.Item2);

			// Atan give angle between -90 and 90 degrees, need to add 180 if the point is to the left
			if (point.x < 0f) {
				angle1 += Mathf.PI;
				angle2 += Mathf.PI;
			}

			Vector2 velocity1 = new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1)) * initialSpeed;
			Vector2 velocity2 = new Vector2(Mathf.Cos(angle2), Mathf.Sin(angle2)) * initialSpeed;

			if (velocity1.y < velocity2.y) {
				return velocity1;
			} else {
				return velocity2;
			}
		}
	}
}
