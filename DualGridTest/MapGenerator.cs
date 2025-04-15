using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DualGridTest
{
    public static class MapGenerator
    {
        
        public static void GenerateMap(TileGrid grid)
        {
            Random random = new Random();
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    grid.Tiles[x, y] = (TileType)random.Next(0, 2);
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch, TileGrid grid, TextureSet[] textures)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    #region vars
                    TileType type = grid.Tiles[x, y];
                    Vector2 position = new Vector2(x, y) * 16;
                    Texture2D texture = null;
                    float rotation = 0f;
                    #endregion

                    //if ((int)type == 1) continue;  // testing

                    #region neighbors
                    bool n = true;
                    bool s = true;
                    bool w = true;
                    bool e = true;
                    bool sw = true;
                    bool se = true;
                    bool nw = true;
                    bool ne = true;

                    if (x > 0)
                    {
                        if (grid.Tiles[x - 1, y] != type)
                        {
                            w = false;
                        }
                    }
                    if (y > 0)
                    {
                       if (grid.Tiles[x, y - 1] != type)
                        {
                            n = false;
                        }
                    }
                    if (x > 0 && y > 0)
                    {
                        if (grid.Tiles[x - 1, y - 1] != type)
                        {
                            nw = false;
                        }
                    }
                    if (y > 0 && x < grid.Width - 1)
                    {
                        if (grid.Tiles[x + 1, y - 1] != type)
                        {
                            ne = false;
                        }
                    }
                    if (y < grid.Height - 1)
                    {
                        if (grid.Tiles[x, y + 1] != type)
                        {
                            s = false;
                        }
                    }
                    if (x < grid.Width - 1)
                    {
                        if (grid.Tiles[x + 1, y] != type)
                        {
                            e = false;
                        }
                    }
                    if (y < grid.Height - 1 && x > 0)
                    {
                        if (grid.Tiles[x - 1, y + 1] != type)
                        {
                            sw = false;
                        }
                    }
                    if (y < grid.Height - 1 && x < grid.Width - 1)
                    {
                        if (grid.Tiles[x + 1, y + 1] != type)
                        {
                            se = false;
                        }
                    }
                    #endregion

                    #region upper_left
                    if (!n && !w && !nw)
                    {
                        texture = textures[(int)type].Convex;
                        rotation = MathHelper.Pi;
                    }
                    else if (n && !w && !nw)
                    {
                        texture = textures[(int)type].Half;
                        rotation = MathHelper.Pi;
                    }
                    else if (!n && w && !nw)
                    {
                        texture = textures[(int)type].Half;
                        rotation = MathHelper.Pi * 1.5f;
                    }
                    else if (!n && !w && nw)
                    {
                        texture = textures[(int)type].Joint;
                        rotation = MathHelper.Pi / 2;
                    }
                    else if (n && w && !nw)
                    {
                        texture = textures[(int)type].Concave;
                    }
                    else if (!n && w && nw)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.Pi / 2;
                    }
                    else if (n && !w && nw)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.Pi * 1.5f;
                    }
                    else if (n && w && nw)
                    {
                        texture = textures[(int)type].Full;
                    }

                    if (texture != null)
                         spriteBatch.Draw(texture, position + new Vector2(-8f, -8f) + 8 * Vector2.One, null, Color.White,
                        rotation, 8 * Vector2.One, 1f, SpriteEffects.None, 0f);
                    #endregion

                    #region upper_right
                    texture = null;
                    rotation = 0f;
                    if (!n && !ne && !e)
                    {
                        texture = textures[(int)type].Convex;
                        rotation = MathHelper.Pi * 1.5f;
                    }
                    else if (n && !ne && !e)
                    {
                        texture = textures[(int)type].Half;
                    }
                    else if (!n && ne && !e)
                    {
                        texture = textures[(int)type].Joint;
                    }
                    else if (!n && !ne && e)
                    {
                        texture = textures[(int)type].Half;
                        rotation = MathHelper.Pi * 1.5f;
                    }
                    else if (n && ne && !e)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.Pi;
                    }
                    else if (n && !ne && e)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.PiOver2;
                    }
                    else if (!n && ne && e)
                    {
                        texture = textures[(int)type].Concave;
                    } else if (n && ne && e)
                    {
                        texture = textures[(int)type].Full;
                    }

                    if (texture != null)
                         spriteBatch.Draw(texture, position + new Vector2(8, -8) + 8 * Vector2.One, null, Color.White,
                        rotation, 8 * Vector2.One, 1f, SpriteEffects.None, 0f);
                    #endregion

                    #region lower_left
                    texture = null;
                    rotation = 0f;

                    if (!w && !sw && !s)
                    {
                        texture = textures[(int)type].Convex;
                        rotation = MathHelper.PiOver2;
                    }
                    else if (w && !sw && !s)
                    {
                        texture = textures[(int)type].Half;
                        rotation = MathHelper.PiOver2;
                    }
                    else if (!w && sw && !s)
                    {
                        texture = textures[(int)type].Joint;
                    }
                    else if (!w && !sw && s)
                    {
                        texture = textures[(int)type].Half;
                        rotation = MathHelper.Pi;
                    }
                    else if (w && sw && !s)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.Pi;
                    }
                    else if (w && !sw && s)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.Pi * 1.5f;
                    }
                    else if (!w && sw && s)
                    {
                        texture = textures[(int)type].Concave;
                    }
                    else if (w && sw && s)
                    {
                        texture = textures[(int)type].Full;
                    }

                    if (texture != null)
                         spriteBatch.Draw(texture, position + new Vector2(-8, 8) + 8 * Vector2.One, null, Color.White,
                        rotation, 8 * Vector2.One, 1f, SpriteEffects.None, 0f);
                    #endregion

                    #region lower_right
                    texture = null;
                    rotation = 0f;

                    if (!s && !se && !e)
                    {
                        texture = textures[(int)type].Convex;
                    }
                    else if (s && !se && !e)
                    {
                        texture = textures[(int)type].Half;
                    }
                    else if (!s && se && !e)
                    {
                        texture = textures[(int)type].Joint;
                        rotation = MathHelper.PiOver2;
                    }
                    else if (!s && !se && e)
                    {
                        texture = textures[(int)type].Half;
                        rotation = MathHelper.PiOver2;
                    }
                    else if (s && se && !e)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.PiOver2;
                    }
                    else if (s && !se && e)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.Pi;
                    }
                    else if (!s && se && e)
                    {
                        texture = textures[(int)type].Concave;
                        rotation = MathHelper.Pi * 1.5f;
                    }
                    else if (s && se && e)
                    {
                        texture = textures[(int)type].Full;
                    }

                    if (texture != null)
                         spriteBatch.Draw(texture, position + new Vector2(8, 8) + 8 * Vector2.One, null, Color.White,
                         rotation, 8 * Vector2.One, 1f, SpriteEffects.None, 0f);
                    #endregion

                     //if (x >= 3 && y >= 3) return; // testing
                }
            }
        }
    }
}
