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
            Tile tile = this._cityService.GetAirportTile(city);

            var player = new PlayerEntity
            {
                Name = playerName,
                City = city,
                CurrentTile = tile,
            };

            HttpSessionStateBase session = new HttpSessionStateWrapper(HttpContext.Current.Session);
            session["playerEntity"] = player;
        }

        public void TravelToCity(City city)
        {
            throw new System.NotImplementedException();
        }
    }
}