using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Warg.Drawing;
using Warg.Input;
using Warg.Organisms;

namespace Warg
{
	public class GameMain : Game
	{
		GraphicsDeviceManager _graphics;
		SpriteBatch _spriteBatch;

		private OrganismGenerator _organismGenerator;
		private World _world;
		private Camera _camera;
		private InputManager _input;
		private Vector2 _worldSize;

		public GameMain()
			: base()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}
		protected override void Initialize()
		{
			_worldSize = new Vector2(800, 800);

			_camera = new Camera(_worldSize, 
				new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));

			_input = new InputManager(_camera);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			var circle = Content.Load<Texture2D>("Circle.png");
			_organismGenerator = new OrganismGenerator(circle);

			var organisms = new List<Organism>();

			for (var i = 0; i < 200; i++)
			{
				organisms.Add(_organismGenerator.CreateOrganism());
			}

			_world = new World(organisms);
		}

		protected override void UnloadContent()
		{
			Content.Unload();
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			_input.Update(gameTime, Keyboard.GetState());

			_world.Update(gameTime);

			_camera.Update(gameTime);


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend
				,SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone,
				null, _camera.Transform);

			_world.Draw(_spriteBatch);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
