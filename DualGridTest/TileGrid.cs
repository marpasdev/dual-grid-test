using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualGridTest
{
    public class TileGrid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public TileType[,] Tiles { get; set; }
        public int TileSize { get; set; }

        public TileGrid(int width, int height)
        {
            Width = width;
            Height = height;

            Tiles = new TileType[width, height];
            TileSize = 16;
        }
        
    }

    public enum TileType
    {
        Dirt = 0,
        Grass = 1
    }
}
