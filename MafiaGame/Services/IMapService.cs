using MafiaGame.Models;

namespace MafiaGame.Services
{
    public interface IMapService
    {
        // TODO: don't expose this method, Use GetMapForCity() instead
        Map CreateMapFromSeed(int seed);
    }
}