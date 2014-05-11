using Microsoft.Xna.Framework;
using Warg;

namespace Tests.Collisions
{
	public class TestCircle : ICircleCollider
	{

		public TestCircle(float centerX, float centerY, int radius)
		{
			Center = new Vector2(centerX, centerY);
			Radius = radius;
		}

		public Vector2 Center { get; set; }
		public int Radius { get; set; }
	}
}