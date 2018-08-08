using MafiaGame.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MafiaGame.Services.impl
{
    public class MapService : IMapService
    {
        public readonly string TILE_TYPE_STORE = "Store";
        public readonly string TILE_TYPE_BANK = "Bank";
        public readonly string TILE_TYPE_POLICESTATION = "PoliceStation";
        public readonly string TILE_TYPE_AIRPORT = "Airport";

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
                    Type = TILE_TYPE_STORE,
                    Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                    Name = _nameGenService.GetNextNameForAStore(),
                    Activities = new Dictionary<string, string> {
                        { "rob", "/store/rob" },
                        { "buy something", "/store/buy" },
                    }
                });
            }

            // add bank tiles
            int numBanks = random.Next(1, 4);
            for (int i = 0; i < numBanks; ++i)
            {
                map.TileList.Add(new Tile()
                {
                    Type = TILE_TYPE_BANK,
                    Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                    Name = _nameGenService.GetNextNameForABank(),
                    Activities = new Dictionary<string, string> {
                        { "rob", "/bank/rob" },
                    }
                });
            }

            // add police station tiles
            int numPoliceStations = 2;
            for (int i = 0; i < numPoliceStations; ++i)
            {
                map.TileList.Add(new Tile()
                {
                    Type = TILE_TYPE_POLICESTATION,
                    Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                    Name = _nameGenService.GetNextNameForAPoliceStation(),
                    Activities = new Dictionary<string, string> {
                        { "bribe the cops", "/policestation/bribe" },
                    }
                });
            }

            // add airport tiles
            map.TileList.Add(new Tile()
            {
                Type = TILE_TYPE_AIRPORT,
                Position = new Point(random.Next(minX, maxX), random.Next(minY, maxY)),
                Name = _nameGenService.GetNextNameForAnAirport(),
                Activities = new Dictionary<string, string> {
                    { "travel", "/airport/travel" },
                }
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

        public Tile GetAirPortTile(Map map)
        {
            foreach(Tile tile in map.TileList)
            {
                if(tile.Type.Equals(TILE_TYPE_AIRPORT))
                {
                    return tile;
                }
            }

            return null;
        }
    }
}