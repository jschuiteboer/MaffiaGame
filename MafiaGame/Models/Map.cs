using System.Collections.Generic;

namespace MafiaGame.Models
{
    public class Map
    {
        public IList<Tile> TileList { get; set; }

        public Map()
        {
            this.TileList = new List<Tile>();
        }
    }
}