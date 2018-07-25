namespace MafiaGame.Models
{
    public class City
    {
        public string Name { get; }

        public Map Map { get; }

        public City(string name, Map map)
        {
            this.Name = name;
            this.Map = map;
        }
    }
}