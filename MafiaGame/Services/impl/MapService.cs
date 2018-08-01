using MafiaGame.Models;
using System;
using System.Windows;

namespace MafiaGame.Services.impl
{
    public class MapService : IMapService
    {
        private INameGenService _nameGenService;

        public MapService(INameGenService nameGenService)
        {
            this._nameGenService = nameGenService;
        }

        public Map CreateMapFromSeed(int seed)
        {
            const int minX = -50;
            const int maxX = 50;
            const int minY = -50;
            const int maxY = 50;

            Map map = new Map();
            Random random = new Random(seed);

            // add store tiles
            int numStores = random.Next(3, 10);
            for (int i = 0; i < numStores; ++i)
            {
                map.TileList.Add(new Tile()
                {
                    Type = "Store",
                    Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                    Name = _nameGenService.GetNextNameForAStore(),
                });
            }

            // add bank tiles
            int numBanks = random.Next(1, 4);
            for (int i = 0; i < numBanks; ++i)
            {
                map.TileList.Add(new Tile()
                {
                    Type = "Bank",
                    Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                    Name = _nameGenService.GetNextNameForABank(),
                });
            }

            // add police station tiles
            int numPoliceStations = 2;
            for (int i = 0; i < numPoliceStations; ++i)
            {
                map.TileList.Add(new Tile()
                {
                    Type = "PoliceStation",
                    Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                    Name = _nameGenService.GetNextNameForAPoliceStation(),
                });
            }

            // add airport tiles
            map.TileList.Add(new Tile()
            {
                Type = "Airport",
                Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                Name = _nameGenService.GetNextNameForAnAirport(),
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