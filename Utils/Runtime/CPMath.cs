using System;
using UnityEngine;

namespace CheesePie.Utils {

	/// <summary>
	/// General math functions.
	/// </summary>
	public static class CPMath {

		/// <summary>
		/// Circumference over diameter.
		/// </summary>
		public const float PI = 3.14159265f;

		/// <summary>
		/// Circumference over radius. (PI times 2)
		/// </summary>
		public const float TAU = PI * 2f;

		/// <summary>
		/// Get a unit Vector2 from the given angle in radians,
		/// Starts at (1,0) and goes counter-clockwise
		/// </summary>
		public static Vector2 Vector2FromAngle(float angle) {
			return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		}

		/// <summary>
		/// Get the angle of the given Vector2 in radians,
		/// Starts at (1,0) and goes counter-clockwise
		/// </summary>
		public static float AngleFromVector2(Vector2 vector2) {
			return Mathf.Atan2(vector2.y, vector2.x);
		}

		/// <summary>
		/// Get the difference between 2 angles in radians,
		/// will always be between -PI and PI
		/// </summary>
		public static float SubtractAngles(float a, float b) {
			float d = (a - b) % TAU;
			if (d > PI) {
				return d - TAU;
			} else if (d < -PI) {
				return d + TAU;
			} else {
				return d;
			}
		}

		/// <summary>
		/// Get the difference between 2 angles in degrees,
		/// will always be between -180 and 180
		/// </summary>
		public static float SubtractAnglesDeg(float a, float b) {
			float d = (a - b) % 360f;
			if (d > 180f) {
				return d - 360;
			} else if (d < -180f) {
				return d + 360;
			} else {
				return d;
			}
		}

		/// <summary>
		/// Get the 2 solution to a quadratic equation in the form 0 = a*x^2 + b*x + c
		/// </summary>
		/// <returns>The 2 solutions (may be the same) or null if no solutions</returns>
		public static Tuple<float, float> SolveQuadratic(float a, float b, float c) {
			float discriminant = (b * b) - (4f * a * c);
			if (discriminant < 0f) {
				return null;
			}

			float sqrt = Mathf.Sqrt(discriminant);

			return new Tuple<float, float>((-b - sqrt) / (2f * a), (-b + sqrt) / (2f * a));
		}
	}
}
