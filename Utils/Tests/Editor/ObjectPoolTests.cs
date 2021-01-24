using NUnit.Framework;

namespace CheesePie.Utils.Tests {

	public class ObjectPoolTests {

		class TestObject {
			public bool initialized;
			public bool active;
		}

		[Test]
		public void GetAndReturn() {
			ObjectPool<TestObject> pool = new ObjectPool<TestObject>(
					createObject: () => new TestObject {active = true, initialized = true},
					activateObject: obj => obj.active = true,
					deactivateObject: obj => obj.active = false
			);

			Assert.IsTrue(pool.InactiveCount == 0);
			Assert.IsTrue(pool.ActiveCount == 0);
			Assert.IsTrue(pool.TotalCount == 0);

			TestObject obj1 = pool.Get();
			Assert.IsTrue(obj1.initialized == true);
			Assert.IsTrue(obj1.active == true);

			Assert.IsTrue(pool.InactiveCount == 0);
			Assert.IsTrue(pool.ActiveCount == 1);
			Assert.IsTrue(pool.TotalCount == 1);

			pool.Return(obj1);
			Assert.IsTrue(obj1.initialized == true);
			Assert.IsTrue(obj1.active == false);

			Assert.IsTrue(pool.InactiveCount == 1);
			Assert.IsTrue(pool.ActiveCount == 0);
			Assert.IsTrue(pool.TotalCount == 1);
		}
	}
}
