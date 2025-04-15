using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace DualGridTest
{
    public class TextureSet
    {
        public Texture2D Full { get; set; }
        public Texture2D Half { get; set; }
        public Texture2D Joint { get; set; }
        public Texture2D Convex { get; set; }
        public Texture2D Concave { get; set; }

        public TextureSet(Texture2D full, Texture2D half, Texture2D joint, Texture2D convex, Texture2D concave)
        {
            Full = full;
            Half = half;
            Joint = joint;
            Convex = convex;
            Concave = concave;
        }

    }
}
