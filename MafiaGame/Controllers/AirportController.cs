using MafiaGame.Models;
using MafiaGame.Services;
using MafiaGame.Util;
using MafiaGame.ViewModels;
using System.Web.Mvc;

namespace MafiaGame.Controllers.Activities
{
    public class AirportController : Controller
    {
        private IPlayerService _playerService;
        private ICityService _cityService;

        public AirportController(IPlayerService playerService, ICityService cityService)
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
                // TODO: move this logic to a service
                PlayerEntity player = this._playerService.GetCurrent();
                player.City = this._cityService.GetCityFromName(model.SelectedCity);

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