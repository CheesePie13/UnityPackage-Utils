using UnityEngine;

public static class Interpolation {

	/// <summary>
	/// Interpolate between the current value and a target value exponentially.
	/// Call each frame to move the current value towards the end value at
	/// the given percentage per second.
	///
	/// Use to create motion that starts fast but end slow. Farther motions will take longer
	/// but logarithmically as the distance increases.
	/// </summary>
	/// <param name="percentPerSec">The percentage of the way to move from the current and target value each second</param>
	/// <param name="deltaTime">The change in time</param>
	/// <returns>The new current value</returns>
	public static float ExpMotion(float current, float target, float percentPerSec, float deltaTime) {
		return (current - target) * Mathf.Pow((1 - percentPerSec), deltaTime) + target;
	}

	/// <summary>
	/// Interpolate between the current value and a target value exponentially.
	/// Call each frame to move the current value towards the end value at
	/// the given percentage per second.
	///
	/// Use to create motion that starts fast but end slow. Farther motions will take longer
	/// but logarithmically as the distance increases.
	/// </summary>
	/// <param name="percentPerSec">The percentage of the way to move from the current and target value each second</param>
	/// <param name="deltaTime">The change in time</param>
	/// <returns>The new current value</returns>
	public static Vector2 ExpMotion(Vector2 current, Vector2 target, float percentPerSec, float deltaTime) {
		return (current - target) * Mathf.Pow((1 - percentPerSec), deltaTime) + target;
	}

	/// <summary>
	/// Interpolate between the current value and a target value exponentially.
	/// Call each frame to move the current value towards the end value at
	/// the given percentage per second.
	///
	/// Use to create motion that starts fast but end slow. Farther motions will take longer
	/// but logarithmically as the distance increases.
	/// </summary>
	/// <param name="percentPerSec">The percentage of the way to move from the current and target value each second</param>
	/// <param name="deltaTime">The change in time</param>
	/// <returns>The new current value</returns>
	public static Vector3 ExpMotion(Vector3 current, Vector3 target, float percentPerSec, float deltaTime) {
		return (current - target) * Mathf.Pow((1 - percentPerSec), deltaTime) + target;
	}
}
