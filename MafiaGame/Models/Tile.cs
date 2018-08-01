using System.Collections.Generic;
using System.Windows;

namespace MafiaGame.Models
{
    public class Tile
    {
        public Point Position { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public Dictionary<string, string> Activities { get; set; }
    }
}