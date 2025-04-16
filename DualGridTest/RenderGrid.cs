using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DualGridTest
{
    public class RenderGrid
    {
        public int Width;
        public int Height;
        public RenderTile[,] UpperLeft;
        public RenderTile[,] UpperRight;
        public RenderTile[,] LowerLeft;
        public RenderTile[,] LowerRight;
        public int Size;

        public RenderGrid(int width, int height, int size)
        {
            Width = width;
            Height = height;
            UpperLeft = new RenderTile[width, height];
            UpperRight = new RenderTile[width, height];
            LowerLeft = new RenderTile[width, height];
            LowerRight = new RenderTile[width, height];
            Size = size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Vector2 basePosition = new Vector2(x, y) * Size;
                    Vector2 origin = new Vector2(Size, Size) / 2;
                    Vector2 offset;

                    offset = new Vector2(-8, -8);
                    spriteBatch.Draw(UpperLeft[x, y].Texture, basePosition + offset + origin,
                        null, Color.White, UpperLeft[x, y].Rotation, origin, 1f, SpriteEffects.None, 0f);

                    offset = new Vector2(8, -8);
                    spriteBatch.Draw(UpperRight[x, y].Texture, basePosition + offset + origin,
                        null, Color.White, UpperRight[x, y].Rotation, origin, 1f, SpriteEffects.None, 0f);

                    offset = new Vector2(-8, 8);
                    spriteBatch.Draw(LowerLeft[x, y].Texture, basePosition + offset + origin,
                        null, Color.White, LowerLeft[x, y].Rotation, origin, 1f, SpriteEffects.None, 0f);
                
                    offset = new Vector2(8, 8);
                    spriteBatch.Draw(LowerRight[x, y].Texture, basePosition + offset + origin,
                        null, Color.White, LowerRight[x, y].Rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
        }
    }

 }
