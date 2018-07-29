using System.Windows;

namespace MafiaGame.Models
{
    public abstract class Tile
    {
        public Point Position { get; set; }

        public string Name { get; set; }

        public string TypeName {
            get {
                return GetType().Name;
            }
        }
    }
}