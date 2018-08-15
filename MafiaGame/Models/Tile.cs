using System;
using System.Collections.Generic;
using System.Windows;

namespace MafiaGame.Models
{
    public class Tile
    {
        public enum TileType
        {
            Store,
            Bank,
            PoliceStation,
            Airport,
        }

        public Guid Id { get; set; }

        public Point Position { get; set; }

        public string Name { get; set; }

        public TileType Type { get; set; }

        public Dictionary<string, string> Activities { get; set; }
    }
}