using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DualGridTest
{
    public class DualGridTestGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        TileGrid grid;

        TextureSet[] textures;

        public DualGridTestGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            grid = new TileGrid(30, 30);
            MapGenerator.GenerateMap(grid);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textures = new TextureSet[2];
            TextureSet dirt = new TextureSet(
                Content.Load<Texture2D>("dirt_full"),
                Content.Load<Texture2D>("dirt_half"),
                Content.Load<Texture2D>("dirt_joint"),
                Content.Load<Texture2D>("dirt_convex"),
                Content.Load<Texture2D>("dirt_concave")
                );

            TextureSet grass = new TextureSet(
                Content.Load<Texture2D>("grass_full"),
                Content.Load<Texture2D>("grass_half"),
                Content.Load<Texture2D>("grass_joint"),
                Content.Load<Texture2D>("grass_convex"),
                Content.Load<Texture2D>("grass_concave")
                );

            textures[0] = dirt;
            textures[1] = grass;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp,
                null, null, null, Matrix.CreateScale(2.0f));

            MapGenerator.Draw(spriteBatch, grid, textures);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}