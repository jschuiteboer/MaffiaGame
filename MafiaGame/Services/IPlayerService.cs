using MafiaGame.Models;

namespace MafiaGame.Services
{
    public interface IPlayerService
    {
        PlayerEntity GetCurrent();

        void TravelToCity(City city);

        void InitPlayer(string name, string selectedStartingCity);
    }
}