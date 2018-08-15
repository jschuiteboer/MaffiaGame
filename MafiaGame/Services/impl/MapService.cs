using MafiaGame.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MafiaGame.Services.impl
{
    public class MapService : IMapService
    {
        private ITileService _tileService;

        public MapService(ITileService tileService)
        {
            this._tileService = tileService;
        }
        
        public Map CreateMapFromSeed(int seed)
        {
            const int minX = -50;
            const int maxX = 50;
            const int minY = -50;
            const int maxY = 50;

            Map map = new Map();
            Random random = new Random(seed);
            Dictionary<Tile.TileType, int> tileCounts = new Dictionary<Tile.TileType, int>
            {
                { Tile.TileType.Store,         random.Next(3, 10) },
                { Tile.TileType.Bank,          random.Next(1, 4) },
                { Tile.TileType.PoliceStation, 2 },
                { Tile.TileType.Airport,       1 },
            };

            // add tiles
            foreach(var tileCount in tileCounts)
            {
                Tile.TileType tileType = tileCount.Key;
                int numTiles = tileCount.Value;

                for (int i = 0; i < numTiles; ++i)
                {
                    Tile tile = this._tileService.BuildTile(
                        tileType,
                        new Point(random.Next(minX, maxX), random.Next(minY, maxY))
                    );

                    map.TileList.Add(tile);
                }
            }
            
            // add tile links
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

        public Tile GetAirPortTile(Map map)
        {
            foreach(Tile tile in map.TileList)
            {
                if(tile.Type.Equals(Tile.TileType.Airport))
                {
                    return tile;
                }
            }

            return null;
        }
    }
}