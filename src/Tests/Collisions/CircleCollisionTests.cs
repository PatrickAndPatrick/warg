using Should;
using Warg;

namespace Tests.Collisions
{
	public class CircleCollisionTests
	{
		public void ShouldCollideWhenOverlapping()
		{
			var circle1 = new TestCircle(10, 10, 5);
			var circle2 = new TestCircle(15, 15, 6);

			circle1.IsCollidingWith(circle2).ShouldBeTrue();
		}

		public void ShouldCollideWhenIdentical()
		{
			var circle = new TestCircle(10, 10, 5);

			circle.IsCollidingWith(circle).ShouldBeTrue();
		}

		public void ShouldNotCollideWhenNotOverlapping()
		{
			var circle1 = new TestCircle(10, 10, 5);
			var circle2 = new TestCircle(20, 20, 2);

			circle1.IsCollidingWith(circle2).ShouldBeFalse();
		}
	}
}
