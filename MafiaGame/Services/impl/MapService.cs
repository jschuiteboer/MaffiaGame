using MafiaGame.Models;
using MafiaGame.Models.Tiles;
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

            // add stores tiles
            int numStores = random.Next(3, 10);
            for (int i = 0; i < numStores; ++i)
            {
                map.TileList.Add(new Store()
                {
                    // TODO: remove magic numbers (map size)
                    Position = new Point(random.Next(0, 100), random.Next(0, 60)),
                    Name = "Some randomly generated store name",
                });
            }

            // add stores tiles
            int numBanks = random.Next(1, 4);
            for (int i = 0; i < numBanks; ++i)
            {
                map.TileList.Add(new Bank()
                {
                    // TODO: remove magic numbers (map size)
                    Position = new Point(random.Next(0, 100), random.Next(0, 60)),
                    Name = "Some randomly generated bank name",
                });
            }

            // add police stations tiles
            int numPoliceStations = 2;
            for (int i = 0; i < numPoliceStations; ++i)
            {
                map.TileList.Add(new PoliceStation()
                {
                    // TODO: remove magic numbers (map size)
                    Position = new Point(random.Next(0, 100), random.Next(0, 60)),
                    Name = "Some randomly generated police station name",
                });
            }

            // add airport tiles
            map.TileList.Add(new Airport()
            {
                // TODO: remove magic numbers (map size)
                Position = new Point(random.Next(0, 100), random.Next(0, 60)),
                Name = "Some randomly generated airport name",
            });

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
    }
}