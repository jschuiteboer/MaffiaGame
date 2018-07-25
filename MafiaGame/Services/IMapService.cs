using MafiaGame.Models;

namespace MafiaGame.Services
{
    public interface IMapService
    {
        Map CreateMapFromSeed(int seed);
    }
}