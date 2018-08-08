using System.Collections.Generic;

namespace MafiaGame.Models
{
    public class Map
    {
        public List<Tile> TileList { get; set; }

        public Dictionary<Tile, Tile> TileLinks { get; set; }

        public Map()
        {
            this.TileList = new List<Tile>();
            this.TileLinks = new Dictionary<Tile, Tile>();
        }
    }
}