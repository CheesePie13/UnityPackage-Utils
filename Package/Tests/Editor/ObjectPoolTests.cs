using NUnit.Framework;

namespace CheesePie.Utils.Tests {

	public class ObjectPoolTests {

		class TestObject {
			public bool initialized;
			public bool active;
		}

		[Test]
		public void TestGetAndReturn() {
			ObjectPool<TestObject> pool = new ObjectPool<TestObject>(
					createObject: () => new TestObject {active = true, initialized = true},
					activateObject: obj => obj.active = true,
					deactivateObject: obj => obj.active = false
			);

			TestObject obj1 = pool.Get();
			Assert.IsNotNull(obj1);
			Assert.IsTrue(obj1.initialized == true);
			Assert.IsTrue(obj1.active == true);

			pool.Return(obj1);
			Assert.IsTrue(obj1.initialized == true);
			Assert.IsTrue(obj1.active == false);
		}

		[Test]
		public void TestCounts() {
			ObjectPool<TestObject> pool = new ObjectPool<TestObject>(
					createObject: () => new TestObject {active = true, initialized = true},
					activateObject: obj => obj.active = true,
					deactivateObject: obj => obj.active = false
			);

			Assert.IsTrue(pool.InactiveCount == 0);
			Assert.IsTrue(pool.ActiveCount == 0);
			Assert.IsTrue(pool.TotalCount == 0);

			TestObject obj1 = pool.Get();

			Assert.IsTrue(pool.InactiveCount == 0);
			Assert.IsTrue(pool.ActiveCount == 1);
			Assert.IsTrue(pool.TotalCount == 1);

			pool.Return(obj1);

			Assert.IsTrue(pool.InactiveCount == 1);
			Assert.IsTrue(pool.ActiveCount == 0);
			Assert.IsTrue(pool.TotalCount == 1);
		}

		[Test]
		public void TestStartingCount() {
			ObjectPool<TestObject> pool = new ObjectPool<TestObject>(
					createObject: () => new TestObject {active = true, initialized = true},
					activateObject: obj => obj.active = true,
					deactivateObject: obj => obj.active = false,
					3
			);

			Assert.IsTrue(pool.InactiveCount == 3);
			Assert.IsTrue(pool.ActiveCount == 0);
			Assert.IsTrue(pool.TotalCount == 3);

			TestObject obj1 = pool.Get();
			Assert.IsNotNull(obj1);
			TestObject obj2 = pool.Get();
			Assert.IsNotNull(obj2);
			TestObject obj3 = pool.Get();
			Assert.IsNotNull(obj3);

			Assert.IsTrue(pool.InactiveCount == 0);
			Assert.IsTrue(pool.ActiveCount == 3);
			Assert.IsTrue(pool.TotalCount == 3);

			TestObject obj4 = pool.Get();
			Assert.IsNotNull(obj4);

			Assert.IsTrue(pool.InactiveCount == 0);
			Assert.IsTrue(pool.ActiveCount == 4);
			Assert.IsTrue(pool.TotalCount == 4);
		}
	}
}
