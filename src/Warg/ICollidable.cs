using Microsoft.Xna.Framework;

namespace Warg
{
	public interface ICollidable
	{
		Vector2 Center { get; }
	}

	public interface ICircleCollider : ICollidable
	{
		int Radius { get; }
	}

	public static class CollisionExtensions
	{
		public static bool IsCollidingWith(this ICircleCollider circle1, ICircleCollider circle2)
		{
			var diff = circle2.Center - circle1.Center;
			var radiiSq = (circle2.Radius + circle1.Radius) * (circle2.Radius + circle1.Radius);
			var distanceSq = diff.LengthSquared();

			return distanceSq < (radiiSq);
		}
	}
}