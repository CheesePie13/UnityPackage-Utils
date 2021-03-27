using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using Random = UnityEngine.Random;

namespace CheesePie.Utils {

	public static class Extensions {

		#region List

		/// <summary>
		/// Get the last element in the <see cref="List{T}"/>
		/// </summary>
		public static T Last<T>(this List<T> list) {
			return list[list.Count - 1];
		}

		/// <summary>
		/// Get a random item from the <see cref="List{T}"/>
		/// </summary>
		public static T GetRandom<T>(this List<T> list) {
			return list[Random.Range(0, list.Count)];
		}

		/// <summary>
		/// Remove and return a random item from the <see cref="List{T}"/>
		/// </summary>
		public static T RemoveRandom<T>(this List<T> list) {
			int index = Random.Range(0, list.Count);
			T item = list[index];
			list.RemoveAt(index);
			return item;
		}

		#endregion


		#region IReadOnlyList

		/// <summary>
		/// Finds the index of the first occurrence of the given object within the list.
		/// </summary>
		/// <returns>The index of the first occurrence or -1 if not found.</returns>>
		public static int IndexOf<T>(this IReadOnlyList<T> list, T item) {
			for (int i = 0; i < list.Count; i++) {
				if (EqualityComparer<T>.Default.Equals(list[i], item)) {
					return i;
				}
			}
			return -1;
		}

		#endregion


		#region Array

		/// <summary>
		/// Get the last element in the array
		/// </summary>
		public static T Last<T>(this T[] array) {
			return array[array.Length - 1];
		}

		#endregion


		#region Dictionary

		/// <summary>
		/// If the dictionary contains the key return the value
		/// else return the default value
		/// </summary>
		public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key,
				TValue defaultValue = default) {
			return dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
		}

		#endregion


		#region MonoBehaviour

		/// <summary>
		/// Start a coroutine and call a callback once it completes.
		/// </summary>
		public static Coroutine StartCoroutine(this MonoBehaviour monoBehaviour, IEnumerator routine, Action callback) {
			return monoBehaviour.StartCoroutine(__StartCoroutineCallBack(monoBehaviour, routine, callback));
		}

		private static IEnumerator __StartCoroutineCallBack(MonoBehaviour monoBehaviour, IEnumerator routine, Action callback) {
			yield return monoBehaviour.StartCoroutine(routine);
			callback?.Invoke();
		}


		/// <summary>
		/// Start multiple coroutines and return a coroutine that completes once they are all complete.
		/// </summary>
		public static Coroutine StartCoroutines(this MonoBehaviour monoBehaviour, params IEnumerator[] routines) {
			return monoBehaviour.StartCoroutine(__StartCoroutines(monoBehaviour, routines));
		}

		private static IEnumerator __StartCoroutines(MonoBehaviour monoBehaviour, IEnumerator[] routines) {
			List<Coroutine> coroutines = new List<Coroutine>();
			foreach (IEnumerator routine in routines) {
				coroutines.Add(monoBehaviour.StartCoroutine(routine));
			}

			foreach (Coroutine coroutine in coroutines) {
				yield return coroutine;
			}
		}

		/// <summary>
		/// Use a coroutine to invoke a callback after a given time.
		/// </summary>
		/// <param name="time">Delay in seconds.</param>
		public static Coroutine StartCoroutineAction(this MonoBehaviour monoBehaviour, float time, Action callback) {
			return monoBehaviour.StartCoroutine(__StartCoroutineAction(time, callback));
		}

		private static IEnumerator __StartCoroutineAction(float time, Action callback) {
			yield return new WaitForSeconds(time);
			callback?.Invoke();
		}

		#endregion


		#region Vector2

		/// <summary>
		/// Divide the x and y values by the divisor.
		/// </summary>
		public static Vector2 Divide(this Vector2 vec, float divisor) {
			return new Vector2(vec.x / divisor, vec.y / divisor);
		}

		#endregion


		#region Vector3

		/// <summary>
		/// Divide the x, y and z values by the divisor.
		/// </summary>
		public static Vector3 Divide(this Vector3 vec, float divisor) {
			return new Vector3(vec.x / divisor, vec.y / divisor, vec.z / divisor);
		}

		/// <summary>
		/// Get the X and Y components.
		/// </summary>
		public static Vector2 XY(this Vector3 vector3) {
			return new Vector2(vector3.x, vector3.y);
		}

		/// <summary>
		/// Get the X and Z components.
		/// </summary>
		public static Vector2 XZ(this Vector3 vector3) {
			return new Vector2(vector3.x, vector3.z);
		}

		/// <summary>
		/// Get the Y and X components.
		/// </summary>
		public static Vector2 YX(this Vector3 vector3) {
			return new Vector2(vector3.y, vector3.x);
		}

		/// <summary>
		/// Get the Y and Z components.
		/// </summary>
		public static Vector2 YZ(this Vector3 vector3) {
			return new Vector2(vector3.y, vector3.z);
		}

		/// <summary>
		/// Get the Z and X components.
		/// </summary>
		public static Vector2 ZX(this Vector3 vector3) {
			return new Vector2(vector3.z, vector3.x);
		}

		/// <summary>
		/// Get the Z and Y components.
		/// </summary>
		public static Vector2 ZY(this Vector3 vector3) {
			return new Vector2(vector3.z, vector3.y);
		}

		#endregion


		#region Vector3Int

		/// <summary>
		/// Get the X and Y components.
		/// </summary>
		public static Vector2Int XY(this Vector3Int vector3Int) {
			return new Vector2Int(vector3Int.x, vector3Int.y);
		}

		/// <summary>
		/// Get the X and Z components.
		/// </summary>
		public static Vector2Int XZ(this Vector3Int vector3Int) {
			return new Vector2Int(vector3Int.x, vector3Int.z);
		}

		/// <summary>
		/// Get the Y and X components.
		/// </summary>
		public static Vector2Int YX(this Vector3Int vector3Int) {
			return new Vector2Int(vector3Int.y, vector3Int.x);
		}

		/// <summary>
		/// Get the Y and Z components.
		/// </summary>
		public static Vector2Int YZ(this Vector3Int vector3Int) {
			return new Vector2Int(vector3Int.y, vector3Int.z);
		}

		/// <summary>
		/// Get the Z and X components.
		/// </summary>
		public static Vector2Int ZX(this Vector3Int vector3Int) {
			return new Vector2Int(vector3Int.z, vector3Int.x);
		}

		/// <summary>
		/// Get the Z and Y components.
		/// </summary>
		public static Vector2Int ZY(this Vector3Int vector3Int) {
			return new Vector2Int(vector3Int.z, vector3Int.y);
		}

		#endregion


		#region Rect

		/// <summary>
		/// Calculate a new rect with an added border with the given size.
		/// </summary>
		public static Rect Extrude(this Rect rect, float size) {
			return new Rect(rect.x - size, rect.y - size, rect.width + size * 2f, rect.height + size * 2f);
		}

		#endregion


		#region AnimationCurve

		/// <summary>
		/// Get the time of the last keyframe in the AnimationCurve.
		/// </summary>
		public static float EndTime(this AnimationCurve animationCurve) {
			return animationCurve.keys.Last().time;
		}

		#endregion
	}
}
