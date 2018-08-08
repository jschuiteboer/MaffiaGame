using MafiaGame.Models;
using System.Web;

namespace MafiaGame.Services.impl
{
    public class PlayerService : IPlayerService
    {
        private ICityService _cityService;

        public PlayerService(ICityService cityService)
        {
            this._cityService = cityService;
        }

        public PlayerEntity GetCurrent()
        {
            HttpSessionStateBase session = new HttpSessionStateWrapper(HttpContext.Current.Session);

            return session["playerEntity"] as PlayerEntity;
        }

        public void InitPlayer(string playerName, string startingCity)
        {
            City city = this._cityService.GetCityFromName(startingCity);

            var player = new PlayerEntity
            {
                Name = playerName,
            };

            this.TravelToCity(player, city);

            HttpSessionStateBase session = new HttpSessionStateWrapper(HttpContext.Current.Session);
            session["playerEntity"] = player;
        }

        public void TravelToCity(PlayerEntity player, City city)
        {
            player.City = city;
            player.CurrentTile = this._cityService.GetAirportTile(city);
        }
    }
}