using MafiaGame.Models;

namespace MafiaGame.Services
{
    public interface IPlayerService
    {
        PlayerEntity GetCurrent();

        void TravelToCity(PlayerEntity player, City city);

        void InitPlayer(string name, string selectedStartingCity);
    }
}