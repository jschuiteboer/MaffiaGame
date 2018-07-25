using MafiaGame.Models;
using System;
using System.Windows;

namespace MafiaGame.Services.impl
{
    public class MapService : IMapService
    {
        public Map CreateMapFromSeed(int seed)
        {
            Map map = new Map();
            Random random = new Random(seed);

            int numTiles = random.Next(3, 10);
            for (int i = 0; i < numTiles; ++i)
            {
                map.TileList.Add(new Tile()
                {
                    Position = new Point(random.Next(0, 100), random.Next(0, 60))
                });
            }

            foreach (Tile tile in map.TileList)
            {
                Tile other = map.TileList[random.Next(0, map.TileList.Count)];

                if (tile != other)
                {
                    map.TileLinks.Add(tile, other);
                }
            }

            return map;
        }
    }
}