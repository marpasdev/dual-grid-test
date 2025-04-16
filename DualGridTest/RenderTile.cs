using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace DualGridTest
{
    public struct RenderTile
    {
        public Texture2D Texture;
        public float Rotation;

        public RenderTile(Texture2D texture, float rotation)
        {
            Texture = texture;
            Rotation = rotation;
        }
    }
}
