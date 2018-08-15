using MafiaGame.Models;
using System;
using System.Windows;

namespace MafiaGame.Services
{
    public interface ITileService
    {
        Tile GetTileFromId(Guid tileId);

        Tile BuildTile(Tile.TileType type, Point position);
    }
}