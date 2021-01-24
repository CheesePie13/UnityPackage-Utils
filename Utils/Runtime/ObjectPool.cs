using System.Collections.Generic;
using System;

namespace CheesePie.Utils {

	/// <summary>
	/// A simple object pool that can be used for any type of object.
	/// </summary>
	public class ObjectPool<T> {

		public int TotalCount { get; private set; } = 0;
		public int ActiveCount => TotalCount - pool.Count;
		public int InactiveCount => pool.Count;

		private Func<T> createObject;
		private Action<T> activateObject;
		private Action<T> deactivateObject;

		private Stack<T> pool = new Stack<T>();

		/// <summary>
		/// Initializes a new <see cref="ObjectPool"/>
		/// </summary>
		/// <param name="createObject">Function called to create a new instance of the object (Should be in active when created).</param>
		/// <param name="activateObject">Function called on object when leaving the pool.</param>
		/// <param name="deactivateObject">Function called on object when returning to the pool.</param>
		/// <param name="startingCount">The initial amount of object to create for the pool.</param>
		public ObjectPool(Func<T> createObject, Action<T> activateObject, Action<T> deactivateObject,
				int startingCount = 0) {
			this.createObject = createObject;
			this.activateObject = activateObject;
			this.deactivateObject = deactivateObject;

			for (int i = 0; i < startingCount; i++) {
				T newObj = createObject();
				TotalCount++;
				deactivateObject(newObj);
				pool.Push(newObj);
			}
		}

		/// <summary>
		/// Get an object from the pool
		/// </summary>
		public T Get() {
			if (pool.Count > 0) {
				T obj = pool.Pop();
				activateObject(obj);
				return obj;
			}

			T newObj = createObject();
			TotalCount++;
			return newObj;
		}

		/// <summary>
		/// Return an object to the pool
		/// </summary>
		public void Return(T obj) {
			deactivateObject(obj);
			pool.Push(obj);
		}
	}
}
