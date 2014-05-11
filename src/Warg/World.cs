using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warg.Organisms;

namespace Warg
{
	public class World
	{
		private readonly List<Organism> _organisms;

		public World(List<Organism> organismses )
		{
			_organisms = organismses;
		}

		public void Update(GameTime gameTime)
		{
			foreach (var organism1 in _organisms)
			{
				organism1.Update(gameTime);

				foreach (var organism2 in _organisms)
				{
					if (organism1 != organism2 && organism1.IsCollidingWith(organism2))
					{
						organism1.CollideWithOrganism(organism2);
					}
				}
			}	
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			_organisms.ForEach(org => org.Draw(spriteBatch));
		}
	}
}