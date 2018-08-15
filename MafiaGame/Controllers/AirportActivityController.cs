using MafiaGame.Models;
using MafiaGame.Services;
using MafiaGame.Util;
using MafiaGame.ViewModels;
using System.Web.Mvc;

namespace MafiaGame.Controllers.Activities
{
    [Activity]
    public class AirportActivityController : Controller
    {
        private IPlayerService _playerService;
        private ICityService _cityService;

        public AirportActivityController(IPlayerService playerService, ICityService cityService)
        {
            this._playerService = playerService;
            this._cityService = cityService;
        }

        public ActionResult Travel()
        {
            return View(new AirportViewModel());
        }
        
        [HttpPost]
        public ActionResult Travel(AirportViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                PlayerEntity currentPlayer = this._playerService.GetCurrent();
                City selectedCity = this._cityService.GetCityFromName(model.SelectedCity);

                this._playerService.TravelToCity(currentPlayer, selectedCity);
                
                return RedirectToAction("", "MainGame");
            }
        }
        
        protected ViewResult View(AirportViewModel model)
        {
            var player = this._playerService.GetCurrent();
            var connectedCities = this._cityService.GetConnectedCities(player.City);

            model.Cities = ViewUtil.ToOptionList(connectedCities, city => city.Name);

            return base.View(model);
        }
    }
}