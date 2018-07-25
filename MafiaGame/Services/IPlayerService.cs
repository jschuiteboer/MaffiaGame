using MafiaGame.Models;

namespace MafiaGame.Services
{
    public interface IPlayerService
    {
        PlayerEntity GetCurrent();
    }
}