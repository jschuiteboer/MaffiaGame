using MafiaGame.Models;
using MafiaGame.Services;
using MafiaGame.ViewModels;
using System.Collections.Generic;
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
            return View(new AirportViewModel {
                Cities = this.GetCityList(),
            });
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
                PlayerEntity player = this._playerService.GetCurrent();
                player.City = this._cityService.GetCityFromName(model.SelectedCity);

                return RedirectToAction("", "MainGame");
            }
        }

        private List<SelectListItem> GetCityList()
        {
            var startingCities = new List<SelectListItem>();
            var cityNames = this._cityService.GetCityNames();

            foreach (var name in cityNames)
            {
                startingCities.Add(new SelectListItem { Text = name });
            }

            return startingCities;
        }
    }
}