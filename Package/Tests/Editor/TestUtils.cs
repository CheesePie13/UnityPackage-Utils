using UnityEngine;

namespace CheesePie.Utils.Tests {

	public static class TestUtils {

		private const float larger_epsilon = 0.00001f;
		private const float quaternion_epsilon = 0.001f;


		public static bool Approx(Vector3 a, Vector3 b) {
			return Mathf.Abs(a.x - b.x) < larger_epsilon
					&& Mathf.Abs(a.y - b.y) < larger_epsilon
					&& Mathf.Abs(a.z - b.z) < larger_epsilon;
		}

		public static bool Approx(Vector2 a, Vector2 b) {
			return Mathf.Abs(a.x - b.x) < larger_epsilon
					&& Mathf.Abs(a.y - b.y) < larger_epsilon;
		}

		public static bool Approx(float a, float b) {
			return Mathf.Abs(a - b) < larger_epsilon;
		}

		public static bool Approx(Rect a, Rect b) {
			return Mathf.Abs(a.x - b.x) < larger_epsilon
					&& Mathf.Abs(a.y - b.y) < larger_epsilon
					&& Mathf.Abs(a.width - b.width) < larger_epsilon
					&& Mathf.Abs(a.height - b.height) < larger_epsilon;
		}

		public static bool Approx(Quaternion a, Quaternion b) {
			return Mathf.Abs(a.x - b.x) < quaternion_epsilon
					&& Mathf.Abs(a.y - b.y) < quaternion_epsilon
					&& Mathf.Abs(a.z - b.z) < quaternion_epsilon
					&& Mathf.Abs(a.w - b.w) < quaternion_epsilon;
		}
	}
}
