using System;
using System.Collections.Generic;
using System.Windows;
using MafiaGame.Models;

namespace MafiaGame.Services.impl
{
    public class TileService : ITileService
    {
        private INameGenService _nameGenService;

        private Dictionary<Guid, Tile> _tileRegistry = new Dictionary<Guid, Tile>();

        public TileService(INameGenService nameGenService)
        {
            this._nameGenService = nameGenService;
        }

        public Tile GetTileFromId(Guid tileId)
        {
            return this._tileRegistry[tileId];
        }

        // TODO: the id is diferent every request. We need to persist the tile
        public Tile BuildTile(Tile.TileType type, Point position)
        {
            Tile tile = new Tile()
            {
                Id = Guid.NewGuid(),
                Type = type,
                Position = position,
            };

            switch (type)
            {
                case Tile.TileType.Store:
                    tile.Name = _nameGenService.GetNextNameForAStore();
                    tile.Activities = new Dictionary<string, string> {
                        { "rob", this.BuildTileUrl(tile, "rob") },
                        { "buy something", this.BuildTileUrl(tile, "buy") },
                    };

                    break;

                case Tile.TileType.Bank:
                    tile.Name = _nameGenService.GetNextNameForABank();
                    tile.Activities = new Dictionary<string, string> {
                        { "rob", this.BuildTileUrl(tile, "rob") },
                    };

                    break;

                case Tile.TileType.Airport:
                    tile.Name = _nameGenService.GetNextNameForAnAirport();
                    tile.Activities = new Dictionary<string, string> {
                        { "travel", this.BuildTileUrl(tile, "travel") },
                    };

                    break;

                case Tile.TileType.PoliceStation:
                    tile.Name = _nameGenService.GetNextNameForAPoliceStation();
                    tile.Activities = new Dictionary<string, string> {
                        { "bribe the cops", this.BuildTileUrl(tile, "bribe") },
                    };

                    break;

                default:
                    throw new ArgumentException($"invalid argument type: '{type}'");
            }

            this._tileRegistry.Add(tile.Id, tile);

            return tile;
        }

        private string BuildTileUrl(Tile tile, String action)
        {
            if (tile == null)
                throw new ArgumentException($"invalid argument tile: '{tile}'");

            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException($"invalid argument action: '{action}'");

            return $"{tile.Type}Activity/{action}/{tile.Id}";
        }
    }
}