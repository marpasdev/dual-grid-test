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
        public float Priority;

        public RenderTile(Texture2D texture, float rotation, float priority = 0)
        {
            Texture = texture;
            Rotation = rotation;
            Priority = priority;
        }
    }
}
