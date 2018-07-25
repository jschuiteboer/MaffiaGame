using MafiaGame.Models;
using System.Web;

namespace MafiaGame.Services.impl
{
    public class PlayerService : IPlayerService
    {
        public PlayerEntity GetCurrent()
        {
            HttpSessionStateBase session = new HttpSessionStateWrapper(HttpContext.Current.Session);

            if (session["playerEntity"] == null)
            {
                session["playerEntity"] = new PlayerEntity();
            }

            return session["playerEntity"] as PlayerEntity;
        }
    }
}