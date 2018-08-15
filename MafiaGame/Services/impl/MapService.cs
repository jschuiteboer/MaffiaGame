using MafiaGame.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MafiaGame.Services.impl
{
    public class MapService : IMapService
    {
        public const string TILE_TYPE_STORE = "Store";
        public const string TILE_TYPE_BANK = "Bank";
        public const string TILE_TYPE_POLICESTATION = "PoliceStation";
        public const string TILE_TYPE_AIRPORT = "Airport";

        private INameGenService _nameGenService;
        private int _tileId;

        public MapService(INameGenService nameGenService)
        {
            this._nameGenService = nameGenService;
        }

        //TODO: move tile creation somewhere else?
        public Map CreateMapFromSeed(int seed)
        {
            const int minX = -50;
            const int maxX = 50;
            const int minY = -50;
            const int maxY = 50;

            Map map = new Map();
            Random random = new Random(seed);
            Dictionary<string, int> tileCounts = new Dictionary<string, int>
            {
                { TILE_TYPE_STORE, random.Next(3, 10) },
                { TILE_TYPE_BANK, random.Next(1, 4) },
                { TILE_TYPE_POLICESTATION, 2 },
                { TILE_TYPE_AIRPORT, 1 },
            };

            foreach(var tileCount in tileCounts)
            {
                string tileType = tileCount.Key;
                int numTiles = tileCount.Value;

                for (int i = 0; i < numTiles; ++i)
                {
                    Tile tile = this.BuildTile(
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

        private Tile BuildTile(string type, Point position)
        {
            _tileId++;

            Tile tile = new Tile()
            {
                Type = type,
                Position = position,
            };

            switch(type)
            {
                case TILE_TYPE_STORE:
                    tile.Name = _nameGenService.GetNextNameForAStore();
                    tile.Activities = new Dictionary<string, string> {
                        { "rob", this.BuildTileUrl(TILE_TYPE_STORE, "rob", _tileId) },
                        { "buy something", this.BuildTileUrl(TILE_TYPE_STORE, "buy", _tileId) },
                    };

                    break;

                case TILE_TYPE_BANK:
                    tile.Name = _nameGenService.GetNextNameForABank();
                    tile.Activities = new Dictionary<string, string> {
                        { "rob", this.BuildTileUrl(TILE_TYPE_BANK, "rob", _tileId) },
                    };

                    break;

                case TILE_TYPE_AIRPORT:
                    tile.Name = _nameGenService.GetNextNameForAnAirport();
                    tile.Activities = new Dictionary<string, string> {
                        { "travel", this.BuildTileUrl(TILE_TYPE_AIRPORT, "travel", _tileId) },
                    };

                    break;

                case TILE_TYPE_POLICESTATION:
                    tile.Name = _nameGenService.GetNextNameForAPoliceStation();
                    tile.Activities = new Dictionary<string, string> {
                        { "bribe the cops", this.BuildTileUrl(TILE_TYPE_POLICESTATION, "bribe", _tileId) },
                    };

                    break;

                default:
                    throw new ArgumentException($"invalid argument type: '{type}'");
            }
            
            return tile;
        }

        private string BuildTileUrl(string tileType, string activity, int tileId)
        {
            if (string.IsNullOrWhiteSpace(tileType))
                throw new ArgumentException($"invalid argument tileType: '{tileType}'");

            if (string.IsNullOrWhiteSpace(activity))
                throw new ArgumentException($"invalid argument activity: '{activity}'");

            return $"{tileType}Activity/{activity}/{tileId}";
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