using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace CheesePie.Utils.Tests {

	public class ExtensionsTests {

		#region List

		[Test]
		public void TestListLast() {
			List<int> list = new List<int> {1, 2, 3};
			Assert.AreEqual(3, list.Last());

			list = new List<int> {1};
			Assert.AreEqual(1, list.Last());
		}

		[Test]
		public void TestListRemoveRandom() {
			List<int> list = new List<int> {1, 2, 3};
			int removed = list.RemoveRandom();
			Assert.IsTrue(!list.Contains(removed));
		}

		#endregion

		#region IReadOnlyList

		[Test]
		public void TestIReadOnlyListIndexOf() {
			IReadOnlyList<int> list = new List<int> {1, 2, 3};
			int index = list.IndexOf(2);
			Assert.AreEqual(1, index);

			object obj1 = 1;
			object obj2 = 2;
			object obj3 = 3;
			IReadOnlyList<object> objList = new List<object> {obj1, obj2, obj3};
			index = objList.IndexOf(obj3);
			Assert.AreEqual(2, index);
		}

		#endregion


		#region Array

		[Test]
		public void TestArrayLast() {
			int[] array = new int[] {1, 2, 3};
			Assert.AreEqual(3, array.Last());

			array = new int[] {1};
			Assert.AreEqual(1, array.Last());
		}

		#endregion


		#region Dictionary

		[Test]
		public void RestDictionaryGetOrDefault() {
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			dictionary[1] = 10;
			dictionary[2] = 20;

			Assert.AreEqual(10, dictionary.GetOrDefault(1, 100));
			Assert.AreEqual(20, dictionary.GetOrDefault(2));
			Assert.AreEqual(300, dictionary.GetOrDefault(3, 300));
			Assert.AreEqual(default(int), dictionary.GetOrDefault(4));
		}

		#endregion


		#region Vector2

		[Test]
		public void TestVector2Divide() {
			Vector2 vec = new Vector2(7f, -4f).Divide(2f);
			Assert.IsTrue(TestUtils.Approx(new Vector2(3.5f, -2f), vec));
		}

		#endregion


		#region Vector3

		[Test]
		public void TestVector3Divide() {
			Vector3 vec = new Vector3(7f, -4f, 5f).Divide(2f);
			Assert.IsTrue(TestUtils.Approx(new Vector3(3.5f, -2f, 2.5f), vec));
		}

		[Test]
		public void TestVector3XYZ() {
			Vector3 vec = new Vector3(1f, 2f, 3f);
			Assert.IsTrue(TestUtils.Approx(new Vector2(1f, 2f), vec.XY()));
			Assert.IsTrue(TestUtils.Approx(new Vector2(1f, 3f), vec.XZ()));
			Assert.IsTrue(TestUtils.Approx(new Vector2(2f, 1f), vec.YX()));
			Assert.IsTrue(TestUtils.Approx(new Vector2(2f, 3f), vec.YZ()));
			Assert.IsTrue(TestUtils.Approx(new Vector2(3f, 1f), vec.ZX()));
			Assert.IsTrue(TestUtils.Approx(new Vector2(3f, 2f), vec.ZY()));
		}

		#endregion


		#region Vector3Int

		[Test]
		public void TestVector3IntXYZ() {
			Vector3Int vec = new Vector3Int(1, 2, 3);
			Assert.IsTrue(TestUtils.Approx(new Vector2Int(1, 2), vec.XY()));
			Assert.IsTrue(TestUtils.Approx(new Vector2Int(1, 3), vec.XZ()));
			Assert.IsTrue(TestUtils.Approx(new Vector2Int(2, 1), vec.YX()));
			Assert.IsTrue(TestUtils.Approx(new Vector2Int(2, 3), vec.YZ()));
			Assert.IsTrue(TestUtils.Approx(new Vector2Int(3, 1), vec.ZX()));
			Assert.IsTrue(TestUtils.Approx(new Vector2Int(3, 2), vec.ZY()));
		}

		#endregion


		#region Rect

		[Test]
		public void TestRectExtrude() {
			Rect rect = new Rect(5f, 3f, 10f, 10f).Extrude(2f);
			Assert.IsTrue(TestUtils.Approx(rect, new Rect(3f, 1f, 14f, 14f)));

			rect = new Rect(5f, 3f, 10f, 10f).Extrude(-2f);
			Assert.IsTrue(TestUtils.Approx(rect, new Rect(7f, 5f, 6f, 6f)));
		}

		#endregion


		#region Animation

		[Test]
		public void TestAnimationEndTime() {
			AnimationCurve curve = new AnimationCurve();
			curve.keys = new Keyframe[] {new Keyframe(0f, 3f),
					new Keyframe(0.5f, 2f), new Keyframe(2.3f, 6f)};

			Assert.IsTrue(TestUtils.Approx(curve.EndTime(), 2.3f));
		}

		#endregion
	}
}
